using MoreShipUpgrades.Configuration;
using MoreShipUpgrades.Managers;
using MoreShipUpgrades.Misc;
using MoreShipUpgrades.Misc.Upgrades;
using MoreShipUpgrades.UI.TerminalNodes;
using MoreShipUpgrades.UpgradeComponents.Interfaces;
using Unity.Netcode;
using UnityEngine;

namespace MoreShipUpgrades.UpgradeComponents.OneTimeUpgrades
{
    public class LightningRod : OneTimeUpgrade, IUpgradeWorldBuilding
    {
        public const string UPGRADE_NAME = "Lightning Rod";
        internal const string WORLD_BUILDING_TEXT = "\n\nService key for the Ship's terminal which allows your crew to legally use the Ship's 'Static Attraction Field' module." +
            " Comes with a list of opt-in maintenance procedures that promise to optimize the module's function and field of influence. This Company-issued document " +
            "is saddled with the uniquely-awkward task of having to ransom a safety feature back to the employee in text while not also admitting to the existence of" +
            " an occupational hazard that was previously denied in court.\n\n";
        public static LightningRod instance;
        StormyWeather StormyWeather;

        // Configuration
        public const string ENABLED_SECTION = $"{UPGRADE_NAME} 업그레이드를 활성화하세요";
        public const bool ENABLED_DEFAULT = true;
        public const string ENABLED_DESCRIPTION = "번개를 배 쪽으로 방향을 바꾸는 장치.";

        public const string PRICE_SECTION = $"{UPGRADE_NAME} Price";
        public const int PRICE_DEFAULT = 1000;

        public const string ACTIVE_SECTION = "Active on Purchase";
        public const bool ACTIVE_DEFAULT = true;
        public const string ACTIVE_DESCRIPTION = $"true인 경우: {UPGRADE_NAME}은 구매 시 활성화됩니다.";

        // Toggle
        public const string ACCESS_DENIED_MESSAGE = $"아직 이 명령어를 사용할 수 없습니다. '{UPGRADE_NAME}'을 구매하세요.\n";
        public const string TOGGLE_ON_MESSAGE = $"{UPGRADE_NAME}이 활성화되었습니다. 이제 번개가 함선으로 향하게 됩니다.\n";
        public const string TOGGLE_OFF_MESSAGE = $"{UPGRADE_NAME} 기능이 비활성화되었습니다. 이제 번개가 함선으로 향하지 않습니다.\n";

        // distance
        public const string DIST_SECTION = $"{UPGRADE_NAME}의 유효 거리.";
        public const float DIST_DEFAULT = 175f;
        public const string DIST_DESCRIPTION = "번개 막대가 가까울수록 번개의 방향을 바꿀 가능성이 높아집니다.";

        public const string UPGRADE_MODE_SECTION = $"{UPGRADE_NAME}의 현재 업그레이드 모드";
        public const UpgradeMode UPGRADE_MODE_DEFAULT = UpgradeMode.EffectiveRange;
        public const string UPGRADE_MODE_DESCRIPTION = "지원되는 값:\n" +
                                                        "EffectiveRange: 물체가 함선에 가까울수록 해당 물체로 향하는 번개가 함선으로 방향이 바뀔 가능성이 높아집니다.\n" +
                                                        "AlwaysRerouteItem: 아이템이 번개에 맞을 위치에 놓이면, 번개는 대신 배로 방향이 바뀝니다.\n" +
                                                        "AlwaysRerouteRandom: (아이템을 대상으로 하는 번개가 아닌) 무작위 번개가 발생할 때마다, 그 번개는 배로 방향이 바뀝니다.\n" +
                                                        "AlwaysRerouteAll: 번개가 발생할 때마다, 그 번개는 배 쪽으로 방향이 바뀔 것입니다.\n";

        public static UpgradeMode CurrentUpgradeMode
        {
            get
            {
                return GetConfiguration().LightningRodConfiguration.AlternativeMode;
            }
        }

        public bool LightningIntercepted { get; internal set; }
        public override bool CanInitializeOnStart => GetConfiguration().LightningRodConfiguration.Price.Value <= 0;

        public enum UpgradeMode
        {
            EffectiveRange,
            AlwaysRerouteItem,
            AlwaysRerouteRandom,
            AlwaysRerouteAll
        }

        void Awake()
        {
            instance = this;
            upgradeName = UPGRADE_NAME;
            overridenUpgradeName = GetConfiguration().LightningRodConfiguration.OverrideName;
        }

        public static void TryInterceptLightning(ref StormyWeather __instance, ref GrabbableObject ___targetingMetalObject)
        {
            bool intercepted = false;
            switch(CurrentUpgradeMode)
            {
                case UpgradeMode.EffectiveRange:
                    {
                        if (___targetingMetalObject == null)
                        {
                            intercepted = false;
                            break;
                        }
                        Terminal terminal = UpgradeBus.Instance.GetTerminal();
                        float dist = Vector3.Distance(___targetingMetalObject.transform.position, terminal.transform.position);

                        if (dist > GetConfiguration().LightningRodConfiguration.Effect.Value) return;

                        dist /= GetConfiguration().LightningRodConfiguration.Effect.Value;
                        float prob = 1 - dist;
                        float rand = Random.value;
                        intercepted = rand < prob;
                        break;
                    }
                case UpgradeMode.AlwaysRerouteItem:
                    {
                        intercepted = ___targetingMetalObject != null;
                        break;
                    }
                case UpgradeMode.AlwaysRerouteRandom:
                    {
                        intercepted = ___targetingMetalObject == null;
                        break;
                    }
                case UpgradeMode.AlwaysRerouteAll:
                    {
                        intercepted = true;
                        break;
                    }
            }

            if (intercepted)
            {
                __instance.staticElectricityParticle.Stop();
                instance.LightningIntercepted = true;
                instance.CoordinateInterceptionClientRpc();
            }
        }
        public static void RerouteLightningBolt(ref Vector3 strikePosition, ref StormyWeather __instance)
        {
            Terminal terminal = UpgradeBus.Instance.GetTerminal();
            strikePosition = terminal.transform.position;
            instance.LightningIntercepted = false;
            __instance.staticElectricityParticle.gameObject.SetActive(true);
        }
        [ClientRpc]
        public void CoordinateInterceptionClientRpc()
        {
            LightningIntercepted = true;
            if (StormyWeather == null) StormyWeather = FindObjectOfType<StormyWeather>(true);
            StormyWeather.staticElectricityParticle.gameObject.SetActive(false);
        }

        public string GetWorldBuildingText(bool shareStatus = false)
        {
            return WORLD_BUILDING_TEXT;
        }

        public override string GetDisplayInfo(int price = -1)
        {
            return CurrentUpgradeMode switch
            {
                UpgradeMode.EffectiveRange => string.Format(AssetBundleHandler.GetInfoFromJSON(UPGRADE_NAME), GetUpgradePrice(price, GetConfiguration().LightningRodConfiguration.PurchaseMode), GetConfiguration().LightningRodConfiguration.Effect.Value),
                UpgradeMode.AlwaysRerouteItem => $"${GetUpgradePrice(price, GetConfiguration().LightningRodConfiguration.PurchaseMode)} - 금속 물체를 향하는 모든 번개를 선박의 피뢰침으로 방향을 바꿉니다.",
                UpgradeMode.AlwaysRerouteRandom => $"${GetUpgradePrice(price, GetConfiguration().LightningRodConfiguration.PurchaseMode)} - 목표물을 지정하지 않은 모든 번개를 함선의 피뢰침으로 향하게 합니다.",
                UpgradeMode.AlwaysRerouteAll => $"${GetUpgradePrice(price, GetConfiguration().LightningRodConfiguration.PurchaseMode)} - 모든 종류의 번개를 배의 피뢰침으로 향하게 합니다.",
                _ => string.Empty,
            };
        }
        public new static (string, string[]) RegisterScrapToUpgrade()
        {
            return (UPGRADE_NAME, GetConfiguration().LightningRodConfiguration.ItemProgressionItems.Value.Split(","));
        }
        public new static void RegisterUpgrade()
        {
            SetupGenericPerk<LightningRod>(UPGRADE_NAME);
        }
        public new static CustomTerminalNode RegisterTerminalNode()
        {
            return UpgradeBus.Instance.SetupOneTimeTerminalNode(UPGRADE_NAME,GetConfiguration().LightningRodConfiguration);
        }

        internal void ResetValues()
        {
            StormyWeather = null;
        }
    }
}
