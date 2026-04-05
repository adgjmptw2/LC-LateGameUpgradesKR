using MoreShipUpgrades.Configuration;
using MoreShipUpgrades.Configuration.Upgrades.Interfaces.TierUpgrades;
using MoreShipUpgrades.Managers;
using MoreShipUpgrades.Misc.Upgrades;
using MoreShipUpgrades.Misc.Util;
using MoreShipUpgrades.UI.TerminalNodes;
using MoreShipUpgrades.UpgradeComponents.Interfaces;
using System;
using UnityEngine;

namespace MoreShipUpgrades.UpgradeComponents.TierUpgrades
{
    internal class ShutterBatteries : TierUpgrade, IUpgradeWorldBuilding
    {
        public const string UPGRADE_NAME = "Shutter Batteries";
        public const string PRICES_DEFAULT = "300,200,300,400";

        public const string ENABLED_SECTION = $"{UPGRADE_NAME} 활성화";
        public const string ENABLED_DESCRIPTION = "문이 닫혀 있을 수 있는 시간을 늘려줍니다.";

        public const string PRICE_SECTION = $"{UPGRADE_NAME}의 가격";
        public const int PRICE_DEFAULT = 300;

        public const string INITIAL_SECTION = "초기 배터리 부스트";
        public const float INITIAL_DEFAULT = 5f;
        public const string INITIAL_DESCRIPTION = "최초 구매 시 도어록용 초기 배터리 부스터";

        public const string INCREMENTAL_SECTION = "점진적 배터리 부스트";
        public const float INCREMENTAL_DEFAULT = 5f;
        public const string INCREMENTAL_DESCRIPTION = "구매 후 도어록용 배터리 용량 증량";

        internal const string WORLD_BUILDING_TEXT = "\n\nService package of maintenance procedures for your Ship's Proprietary Emergency Lockout Door System, the two-button monitor you control the Ship's airlock from while moonside. Opting into all of the procedures will improve the uptime of the lockout function, which may improve your department's Fatality Record Over Time by up to 11%.\n\n";

        public string GetWorldBuildingText(bool shareStatus = false)
        {
            return WORLD_BUILDING_TEXT;
        }
        void Awake()
        {
            upgradeName = UPGRADE_NAME;
            overridenUpgradeName = GetConfiguration().ShutterBatteriesConfiguration.OverrideName;
        }
        public override string GetDisplayInfo(int initialPrice = -1, int maxLevels = -1, int[] incrementalPrices = null)
        {
            static float infoFunction(int level)
            {
                ITierEffectUpgradeConfiguration<float> config = GetConfiguration().ShutterBatteriesConfiguration;
                return config.InitialEffect.Value + (level * config.IncrementalEffect.Value);
            }
            const string infoFormat = "LVL {0} - {1} - 문이 닫힌 상태를 유지하는 유압 용량을 {2} 단위만큼 증가시킵니다.\n";
            return Tools.GenerateInfoForUpgrade(infoFormat, initialPrice, incrementalPrices, infoFunction, purchaseMode: GetConfiguration().ShutterBatteriesConfiguration.PurchaseMode);
        }
        public override bool CanInitializeOnStart
        {
            get
            {
                ITierEffectUpgradeConfiguration<float> upgradeConfig = GetConfiguration().ShutterBatteriesConfiguration;
                string[] prices = upgradeConfig.Prices.Value.Split(',');
                return prices.Length == 0 || (prices.Length == 1 && (prices[0].Length == 0 || prices[0] == "0"));
            }
        }
        public static float GetAdditionalDoorTime(float defaultValue)
        {
            ITierEffectUpgradeConfiguration<float> config = GetConfiguration().ShutterBatteriesConfiguration;
            if (!config.Enabled) return defaultValue;
            if (!GetActiveUpgrade(UPGRADE_NAME)) return defaultValue;
            float additionalValue = config.InitialEffect + (GetUpgradeLevel(UPGRADE_NAME) * config.IncrementalEffect);
            return Mathf.Clamp(defaultValue + additionalValue, defaultValue, float.MaxValue);
        }

        public new static (string, string[]) RegisterScrapToUpgrade()
        {
            return (UPGRADE_NAME, GetConfiguration().ShutterBatteriesConfiguration.ItemProgressionItems.Value.Split(","));
        }
        public new static void RegisterUpgrade()
        {
            SetupGenericPerk<ShutterBatteries>(UPGRADE_NAME);
        }
        public new static CustomTerminalNode RegisterTerminalNode()
        {
            return UpgradeBus.Instance.SetupMultiplePurchaseableTerminalNode(UPGRADE_NAME, GetConfiguration().ShutterBatteriesConfiguration);
        }
    }
}
