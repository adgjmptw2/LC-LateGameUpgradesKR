using MoreShipUpgrades.API;
using MoreShipUpgrades.Configuration;
using MoreShipUpgrades.Configuration.Upgrades.Interfaces.TierUpgrades;
using MoreShipUpgrades.Managers;
using MoreShipUpgrades.Misc;
using MoreShipUpgrades.Misc.Upgrades;
using MoreShipUpgrades.UI.TerminalNodes;
using MoreShipUpgrades.UpgradeComponents.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoreShipUpgrades.UpgradeComponents.TierUpgrades.Enemies
{
    class Hunter : TierUpgrade, IUpgradeWorldBuilding
    {
        private static readonly LguLogger logger = new(UPGRADE_NAME);
        internal static Hunter Instance;

        public const string UPGRADE_NAME = "Hunter";
        public const string PRICES_DEFAULT = "500,600,700";
        internal const string WORLD_BUILDING_TEXT = "\n\nOn-the-job training program that teaches your crew how to properly collect lab-ready samples of blood," +
            " skin, and organ tissue from entities found within the facility. These samples are valuable to The Company. Used to be a part of the standard onboarding procedure," +
            " but was made opt-in only in 2005 to cut onboarding costs.\n\n";

        static readonly Dictionary<string, string> monsterNames = new()
            {
            { "hoarding", "수집 벌레" },
            { "hoarding bug", "수집 벌레" },
            { "snare", "덫 벼룩" },
            { "flea", "덫 벼룩" },
            { "snare flea", "덫 벼룩" },
            { "centipede", "덫 벼룩" },
            { "bunker spider", "벙커 거미" },
            { "bunker", "벙커 거미" },
            { "bunk", "벙커 거미" },
            { "spider", "벙커 거미" },
            { "baboon hawk", "개코원숭이 매" },
            { "baboon", "개코원숭이 매" },
            { "hawk", "개코원숭이 매" },
            { "flowerman", "브레켄" },
            { "bracken", "브라켄" },
            { "crawler", "하프/덤퍼" },
            { "half", "하프/덤퍼" },
            { "thumper", "하프/덤퍼" },
            { "mouthdog", "눈먼 개" },
            { "eyeless dog", "눈먼 개" },
            { "eyeless", "눈먼 개" },
            { "dog", "눈먼 개" },
            { "tulip snake", "튤립 뱀" },
            { "slowersnake", "튤립 뱀" },
            { "flower snake", "튤립 뱀" },
            { "snake", "튤립 뱀" },
            { "forest giant", "숲의 거인" },
            { "forest keeper", "숲의 거인" },
            { "forestgiant", "숲의 거인" },
            { "forestkeeper", "숲의 거인" },
            { "manticoil", "만티코일" },
            { "manti coil", "만티코일" },
            { "bird", "만티코일" },
            { "puffer", "포자 도마뱀" },
            { "sporelizard", "포자 도마뱀" },
            { "spore lizard", "포자 도마뱀" },
            { "lizard", "포자 도마뱀" },
            { "fox", "납치 여우" },
            { "kidnapper fox", "납치 여우" },
            { "kidnapperfox", "납치 여우" },
            { "bush wolf", "납치 여우" },
            { "bushwolf", "납치 여우" },
            { "wolf", "납치 여우" },
            { "maneater", "식인귀" },
            { "cave dweller", "식인귀" },
            { "cavedweller", "식인귀" },
            { "baby", "식인귀" },
            { "babyeater", "식인귀" },
            { "giant sapsucker", "자이언트 키위" },
            { "giant kiwi", "자이언트 키위" },
            { "woodpecker", "자이언트 키위" },
            { "giantkiwi", "자이언트 키위" },
            };

        /**
         * A mapping from monster names to the Hunter level required to harvest them.
         * This mapping uses the value from the above list, translating from any key in the list
         */
        static private Dictionary<string, int> levels;

        public static void SetupLevels()
        {
            levels = [];
            string[] tiersList = GetConfiguration().HunterConfiguration.TierCollection.Value.ToLower().Split('-');
            for (int level = 0; level < tiersList.Length; ++level)
            {
                foreach (string monster in tiersList[level].Split(',').Select(x => x.Trim().ToLower()))
                {
                    if (monsterNames.TryGetValue(monster, out string fullName))
                    {
                        if (levels.ContainsKey(fullName))
                        {
                            logger.LogError($"{fullName} appears twice in samples config! Appearing now as {monster}");
                        }
                        else
                        {
                            logger.LogInfo($"{fullName} set to be harvestable at level {level + 1}");
                            levels[fullName] = level;
                        }
                    }
                    else
                    {
                        logger.LogError($"Unrecognized enemy name: {monster}");
                    }
                }
            }
            foreach (string moddedMonster in HunterSamples.moddedLevels.Keys)
            {
                levels[moddedMonster] = HunterSamples.moddedLevels[moddedMonster];
                monsterNames[moddedMonster.ToLower()] = moddedMonster;
            }
        }

        public static bool CanHarvest(string shortName)
        {
            if (!monsterNames.TryGetValue(shortName.ToLower(), out string monsterName))
            {
                logger.LogDebug($"{shortName} is not harvestable");
                return false;
            }

            if (levels.TryGetValue(monsterName, out int harvestLevel))
            {
                logger.LogDebug($"{monsterName} can be harvested at level {harvestLevel + 1}");
                return harvestLevel <= GetUpgradeLevel(UPGRADE_NAME);
            }

            logger.LogDebug($"{monsterName} cannot be harvested at any level");
            return false;
        }
        void Awake()
        {
            upgradeName = UPGRADE_NAME;
            overridenUpgradeName = GetConfiguration().HunterConfiguration.OverrideName;
            Instance = this;
        }

        public static string GetHunterInfo(int level, int price)
        {
            string monsterList = string.Join(", ",
                levels.Where(item => item.Value == level)
                .Select(item => item.Key));

            return string.Format(AssetBundleHandler.GetInfoFromJSON(UPGRADE_NAME),
                level + 1, GetUpgradePrice(price, GetConfiguration().HunterConfiguration.PurchaseMode), monsterList);
        }

        public string GetWorldBuildingText(bool shareStatus = false)
        {
            return WORLD_BUILDING_TEXT;
        }

        public override string GetDisplayInfo(int initialPrice = -1, int maxLevels = -1, int[] incrementalPrices = null)
        {
            StringBuilder sb = new();
            sb.Append(GetHunterInfo(0, initialPrice));
            for (int i = 0; i < maxLevels; i++)
                sb.Append(GetHunterInfo(i + 1, incrementalPrices[i]));
            return sb.ToString();
        }
        public override bool CanInitializeOnStart
        {
            get
            {
                ITierUpgradeConfiguration upgradeConfig = GetConfiguration().HunterConfiguration;
                string[] prices = upgradeConfig.Prices.Value.Split(',');
                return prices.Length == 0 || (prices.Length == 1 && (prices[0].Length == 0 || prices[0] == "0"));
            }
        }

        public new static (string, string[]) RegisterScrapToUpgrade()
        {
            return (UPGRADE_NAME, GetConfiguration().HunterConfiguration.ItemProgressionItems.Value.Split(","));
        }
        public new static void RegisterUpgrade()
        {
            SetupGenericPerk<Hunter>(UPGRADE_NAME);
        }
        public new static CustomTerminalNode RegisterTerminalNode()
        {
            SetupLevels();
            return UpgradeBus.Instance.SetupMultiplePurchaseableTerminalNode(UPGRADE_NAME, GetConfiguration().HunterConfiguration);
        }
    }
}
