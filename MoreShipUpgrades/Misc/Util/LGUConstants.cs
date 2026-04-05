using MoreShipUpgrades.Managers;
using MoreShipUpgrades.UpgradeComponents.Commands;
using MoreShipUpgrades.UpgradeComponents.Items;
using MoreShipUpgrades.UpgradeComponents.OneTimeUpgrades;
using MoreShipUpgrades.UpgradeComponents.OneTimeUpgrades.Enemies;
using MoreShipUpgrades.UpgradeComponents.OneTimeUpgrades.Items;
using MoreShipUpgrades.UpgradeComponents.OneTimeUpgrades.Player;
using MoreShipUpgrades.UpgradeComponents.OneTimeUpgrades.Ship;
using MoreShipUpgrades.UpgradeComponents.OneTimeUpgrades.Store;
using MoreShipUpgrades.UpgradeComponents.TierUpgrades;
using MoreShipUpgrades.UpgradeComponents.TierUpgrades.AttributeUpgrades;
using MoreShipUpgrades.UpgradeComponents.TierUpgrades.Enemies;
using MoreShipUpgrades.UpgradeComponents.TierUpgrades.Items;
using MoreShipUpgrades.UpgradeComponents.TierUpgrades.Items.Jetpack;
using MoreShipUpgrades.UpgradeComponents.TierUpgrades.Items.RadarBooster;
using MoreShipUpgrades.UpgradeComponents.TierUpgrades.Items.Shotgun;
using MoreShipUpgrades.UpgradeComponents.TierUpgrades.Items.WeedKiller;
using MoreShipUpgrades.UpgradeComponents.TierUpgrades.Items.Zapgun;
using MoreShipUpgrades.UpgradeComponents.TierUpgrades.Player;
using MoreShipUpgrades.UpgradeComponents.TierUpgrades.Ship;
using MoreShipUpgrades.UpgradeComponents.TierUpgrades.Store;
using UnityEngine;

namespace MoreShipUpgrades.Misc.Util
{
    internal static class LguConstants
    {
        #region General

        #region Characters
        internal const char WHITE_SPACE = ' ';
        #endregion

        #region Hex Colors

        internal const string HEXADECIMAL_RED = "#FF0000";
        internal const string HEXADECIMAL_DARK_RED = "#8B0000";
        internal const string HEXADECIMAL_WHITE = "#FFFFFF";
        internal const string HEXADECIMAL_GREEN = "#00FF00";
        internal const string HEXADECIMAL_DARK_GREEN = "#026440";
        internal const string HEXADECIMAL_GREY = "#666666";

        #endregion

        #endregion

        #region Keybinds

        internal const string DROP_ALL_ITEMS_WHEELBARROW_KEYBIND_NAME = "Drop all items from wheelbarrow";
        internal const string DROP_ALL_ITEMS_WHEELBARROW_DEFAULT_KEYBIND = "<Mouse>/middleButton";

        internal const string TOGGLE_NIGHT_VISION_KEYBIND_NAME = "Toggle NVG";
        internal const string TOGGLE_NIGHT_VISION_DEFAULT_KEYBIND = "<Keyboard>/leftAlt";

        internal const string MOVE_CURSOR_UP_KEYBIND_NAME = "Move Cursor Up in Lategame Upgrades Store";
        internal const string MOVE_CURSOR_UP_DEFAULT_KEYBIND = "<Keyboard>/w";

        internal const string MOVE_CURSOR_DOWN_KEYBIND_NAME = "Move Cursor Down in Lategame Upgrades Store";
        internal const string MOVE_CURSOR_DOWN_DEFAULT_KEYBIND = "<Keyboard>/s";

        internal const string EXIT_STORE_KEYBIND_NAME = "Exit Lategame Upgrades Store";
        internal const string EXIT_STORE_DEFAULT_KEYBIND = "<Keyboard>/escape";

        internal const string NEXT_PAGE_KEYBIND_NAME = "Next Page in Lategame Upgrades Store";
        internal const string NEXT_PAGE_DEFAULT_KEYBIND = "<Keyboard>/d";

        internal const string PREVIOUS_PAGE_KEYBIND_NAME = "Previous Page in Lategame Upgrades Store";
        internal const string PREVIOUS_PAGE_DEFAULT_KEYBIND = "<Keyboard>/a";

        internal const string SUBMIT_PROMPT_KEYBIND_NAME = "Submit Prompt in Lategame Upgrades Store";
        internal const string SUBMIT_PROMPT_DEFAULT_KEYBIND = "<Keyboard>/enter";

        #endregion

        #region Plugin Configuration

        #region Randomize Available Upgrades

        internal const string RANDOMIZE_UPGRADES_SECTION = "_Randomize Upgrades_";

        internal const string RANDOMIZE_UPGRADES_ENABLED_KEY = "랜덤 업그레이드 활성화";
        internal const bool RANDOMIZE_UPGRADES_ENABLED_DEFAULT = false;
        internal const string RANDOMIZE_UPGRADES_ENABLED_DESCRIPTION = "업그레이드는 선택한 이벤트별로 무작위로 결정되며, 상점에서 구매 가능한 업그레이드 항목도 함께 제공됩니다.";

        internal const string RANDOMIZE_UPGRADES_AMOUNT_KEY = "업그레이드 횟수";
        internal const int RANDOMIZE_UPGRADES_AMOUNT_DEFAULT = 5;
        internal const string RANDOMIZE_UPGRADES_AMOUNT_DESCRIPTION = "상점에 항상 표시될 업그레이드 수량(허용될 경우).";

        internal const string RANDOMIZE_UPGRADES_ALWAYS_SHOW_PURCHASED_KEY = "구매한 업그레이드 표시";
        internal const bool RANDOMIZE_UPGRADES_ALWAYS_SHOW_PURCHASED_DEFAULT = true;
        internal const string RANDOMIZE_UPGRADES_ALWAYS_SHOW_PURCHASED_DESCRIPTION = "구매한 업그레이드는 상점에 항상 표시되지만, 지정된 수량의 무작위 업그레이드에는 이러한 업그레이드가 포함되지 않습니다.";

        internal const string RANDOMIZE_UPGRADES_CHANGE_UPGRADES_EVENT_KEY = "업그레이드 이벤트 무작위화";
        internal const RandomizeUpgradeManager.RandomizeUpgradeEvents RANDOMIZE_UPGRADES_CHANGE_UPGRADES_EVENT_DEFAULT = RandomizeUpgradeManager.RandomizeUpgradeEvents.PerQuota;
        internal const string RANDOMIZE_UPGRADES_CHANGE_UPGRADES_EVENT_DESCRIPTION = "상점에서 무작위 업그레이드 변경을 유발하는 이벤트입니다.";

        #endregion

        #region Item Progression

        internal const string ITEM_PROGRESSION_SECTION = "_Item Progression Route_";

        internal const string ALTERNATIVE_ITEM_PROGRESSION_KEY = "아이템 진행 활성화";
        internal const bool ALTERNATIVE_ITEM_PROGRESSION_DEFAULT = false;
        internal const string ALTERNATIVE_ITEM_PROGRESSION_DESCRIPTION = "아이템 업그레이드 \n" +
                                                                        "true이라면, 회수한 아이템은 함선 업그레이드에 사용할 수 있습니다.";

        internal const string ITEM_PROGRESSION_MODE_KEY = "아이템 진행 모드";
        internal const ItemProgressionManager.CollectionModes ITEM_PROGRESSION_MODE_DEFAULT = ItemProgressionManager.CollectionModes.CustomScrap;
        internal const string ITEM_PROGRESSION_MODE_DESCRIPTION = "아이템 진행 모드\n" +
                                                                "Supported Modes: \n" +
                                                                "CustomScrap: 지정된 폐기물은 관련 업그레이드 수준에 반영됩니다.\n" +
                                                                "UniqueScrap: 모든 폐기물(사양은 무시됨)은 무작위로 할당되는 업그레이드 레벨에 반영됩니다.\n" +
                                                                "NearestValue: 각 할당량 종료 시, 수집한 스크랩 총량 중 가장 가까운 값(소수점 이하 버림)에 해당하는 무작위 업그레이드를 부여합니다.\n" +
                                                                "ChancePerScrap: 판매된 스크랩 하나당, 설정된 확률로 무작위/저렴한/최저 등급 업그레이드를 획득합니다.\n" +
                                                                "Apparatice: 기기 판매가 성공적으로 완료되면 항상 업그레이드 혜택을 받으세요.";

        internal const string ITEM_PROGRESSION_CONTRIBUTION_MULTIPLIER_KEY = "아이템 진행 배율";
        internal const float ITEM_PROGRESSION_CONTRIBUTION_MULTIPLIER_DEFAULT = 0.85f;
        internal const string ITEM_PROGRESSION_CONTRIBUTION_MULTIPLIER_DESCRIPTION = "아이템 진행 기여도 배율\n" +
                                                                                    "업그레이드에 기여하는 고철 가치에 대한 승수입니다.";

        internal const string SCRAP_UPGRADE_CHANCE_KEY = "스크랩 업그레이드 확률";
        internal const float SCRAP_UPGRADE_CHANCE_DEFAULT = 0.05f;
        internal const string SCRAP_UPGRADE_CHANCE_DESCRIPTION = "업그레이드 확률 계산\n" +
                                                                "아이템 진행 모드가 '분쇄당 확률'로 설정된 경우에만 사용됩니다.\n" +
                                                                "X -> (X * 100) %";

        internal const string SCRAP_UPGRADE_MODE_KEY = "업그레이드 확률 우선순위";
        internal const ItemProgressionManager.ChancePerScrapModes SCRAP_UPGRADE_MODE_DEFAULT = ItemProgressionManager.ChancePerScrapModes.LowestLevel;
        internal const string SCRAP_UPGRADE_MODE_DESCRIPTION = "업그레이드 확률 우선순위\n" +
                                                            "아이템 진행 모드가 '분쇄당 확률'로 설정된 경우에만 사용됩니다.\n" +
                                                            "Acceptable Values:\n무작위 선택: 적용할 업그레이드를 무작위로 선택합니다.\n" +
                                                            "Cheapest: 가장 저렴한 업그레이드 옵션을 선택하여 신청하세요.\n" +
                                                            "Lowest Tier: 적용할 업그레이드를 가장 낮은 레벨로 선택하세요.";

        internal const string ITEM_PROGRESSION_BLACKLISTED_ITEMS_KEY = "블랙리스트 품목";
        internal const string ITEM_PROGRESSION_BLACKLISTED_ITEMS_DEFAULT = "Clipboard";
        internal const string ITEM_PROGRESSION_BLACKLISTED_ITEMS_DESCRIPTION = "아이템 업그레이드에 사용할 수 없는 블랙리스트 아이템입니다. 아이템 업그레이드 모드가 '고유 스크랩'으로 설정된 경우에만 사용됩니다. 이 아이템들은 어떤 업그레이드에도 기여하지 않습니다.";

        internal const string ITEM_PROGRESSION_BLACKLIST_ITEMS_ENTRY_DELIMITER = ",";

        internal const string ITEM_PROGRESSION_APPARATICE_ITEMS_KEY = "Apparatus Items";
        internal const string ITEM_PROGRESSION_APPARATICE_ITEMS_DEFAULT = $"Apparatus{ITEM_PROGRESSION_APPARATICE_ITEMS_ATTRIBUTE_DELIMITER}1{ITEM_PROGRESSION_APPARATICE_ITEMS_ENTRY_DELIMITER}ExampleItemName{ITEM_PROGRESSION_APPARATICE_ITEMS_ATTRIBUTE_DELIMITER}2";
        internal const string ITEM_PROGRESSION_APPARATICE_ITEMS_DESCRIPTION = "\"장비\"로 간주되는 품목으로, 회사에 판매되면 일정량의 업그레이드를 제공합니다.\n" +
                                                                            "항목 이름은 스캔 노드에 표시되는 이름이거나 내부 이름입니다.\n" +
                                                                            "이 목록은 아이템 진행 모드가 '장치'로 설정된 경우에만 유효합니다.";

        internal const string ITEM_PROGRESSION_NO_PURCHASE_UPGRADES_KEY = "Non-Purchaseable Upgrades";
        internal const bool ITEM_PROGRESSION_NO_PURCHASE_UPGRADES_DEFAULT = false;
        internal const string ITEM_PROGRESSION_NO_PURCHASE_UPGRADES_DESCRIPTION = "상점에서 업그레이드 아이템을 구매할 수 없도록 하고, 획득까지 얼마나 남았는지 확인하는 용도로만 사용할 수 있게 합니다. 아이템 진행 모드가 활성화된 경우에만 유효합니다.";

        internal const string ITEM_PROGRESSION_ALWAYS_SHOW_ITEMS_KEY = "Always Show Contribution Items";
        internal const bool ITEM_PROGRESSION_ALWAYS_SHOW_ITEMS_DEFAULT = false;
        internal const string ITEM_PROGRESSION_ALWAYS_SHOW_ITEMS_DESCRIPTION = "업그레이드 전에 판매되었는지 여부와 관계없이 각 업그레이드와 관련된 모든 항목을 표시합니다.";

        internal const string ITEM_PROGRESSION_APPARATICE_ITEMS_ENTRY_DELIMITER = ",";
        internal const string ITEM_PROGRESSION_APPARATICE_ITEMS_ATTRIBUTE_DELIMITER = "@";

        internal const string ITEM_PROGRESSION_ITEMS_KEY = "Contribution Items";
        internal const string ITEM_PROGRESSION_ITEMS_DEFAULT = "";
        internal const string ITEM_PROGRESSION_ITEMS_DESCRIPTION = "판매 시 업그레이드 구매에 기여하는 아이템입니다. 스캔 노드의 이름 또는 ItemProperties.itemName을 여기에 삽입할 수 있습니다.";

        #endregion

        #region Miscellaneous

        internal const string MISCELLANEOUS_SECTION = "_Misc_";

        internal const string SHARE_ALL_UPGRADES_KEY = "Convert all upgrades to be shared.";
        internal const bool SHARE_ALL_UPGRADES_DEFAULT = true;
        internal const string SHARE_ALL_UPGRADES_DESCRIPTION = "true로 설정하면 다른 모든 업그레이드의 개인/공유 옵션을 무시하고 모든 업그레이드를 공유 상태로 설정합니다.";

        internal const string SALE_PERCENT_KEY = "Chance of upgrades going on sale";
        internal const float SALE_PERCENT_DEFAULT = 0.85f;
        internal const string SALE_PERCENT_DESCRIPTION = "0.85 = 업그레이드가 할인될 확률 15%.";

        internal const string KEEP_UPGRADES_AFTER_FIRED_KEY = "Keep upgrades after quota failure";
        internal const bool KEEP_UPGRADES_AFTER_FIRED_DEFAULT = false;
        internal const string KEEP_UPGRADES_AFTER_FIRED_DESCRIPTION = "true로 설정하면 회사에 해고된 후에도 업그레이드를 유지합니다.";

        internal const string SHOW_UPGRADES_CHAT_KEY = "Show upgrades being loaded in chat";
        internal const bool SHOW_UPGRADES_CHAT_DEFAULT = true;
        internal const string SHOW_UPGRADES_CHAT_DESCRIPTION = "활성화되면 업그레이드를 처음 불러올 때 채팅 메시지가 표시됩니다.";

        internal const string SALE_APPLY_ONCE_KEY = "Apply upgrade sale on one purchase";
        internal const bool SALE_APPLY_ONCE_DEFAULT = false;
        internal const string SALE_APPLY_ONCE_DESCRIPTION = "업그레이드가 할인 중일 때 첫 구매에만 할인을 적용합니다. 이후 추가 구매에는 할인이 적용되지 않습니다.";

        internal const string SHOW_WORLD_BUILDING_TEXT_KEY = "Show World Building text in Upgrade information";
        internal const bool SHOW_WORLD_BUILDING_TEXT_DEFAULT = false;
        internal const string SHOW_WORLD_BUILDING_TEXT_DESCRIPTION = "업그레이드 정보를 볼 때 실용적인 정보와 함께 세계관 설명 텍스트를 표시할지 여부를 설정합니다.";

        internal const string BUYABLE_UPGRADES_ONCE_KEY = "Limited Buyable Upgrades";
        internal const bool BUYABLE_UPGRADES_ONCE_DEFAULT = false;
        internal const string BUYABLE_UPGRADES_ONCE_DESCRIPTION = "활성화하면 처음 구매한 업그레이드는 이후 해당 플레이어만 구매할 수 있습니다. 개인 업그레이드에만 해당됩니다.";

        internal const string SHOW_LOCKED_UPGRADES_KEY = "Show Locked Upgrades";
        internal const bool SHOW_LOCKED_UPGRADES_DEFAULT = true;
        internal const string SHOW_LOCKED_UPGRADES_DESCRIPTION = "비활성화하면 다른 승무원이 구매 권한을 가진 잠긴 업그레이드가 상점에 표시되지 않습니다.";
        #endregion

        #region Name Overrides
        internal const string OVERRIDE_NAMES_SECTION = "Name Overrides";

        internal const string OVERRIDE_NAMES_ENABLED_KEY = "Override Upgrade Names";
        internal const bool OVERRIDE_NAMES_ENABLED_DEFAULT = true;
        internal const string OVERRIDE_NAMES_ENABLED_DESCRIPTION = "이 기능을 활성화하면 각 업그레이드의 이름이 이 섹션에 정의된 이름으로 바뀝니다.";

        internal const string OVERRIDE_NAME_KEY_FORMAT = "{0}의 변경된 이름";

        public static string GetDefaultName(string name)
        {
            switch (name)
            {
                // [신체] 카테고리
                case "Effective Bandaids": return "[신체] 고성능 밴드";
                case "Medical Nanobots": return "[신체] 나노봇 수복";
                case "Quick Hands": return "[신체] 빠른 손놀림";
                case "Carbon Kneejoints": return "[신체] 카본 무릎";
                case "Rubber Boots": return "[신체] 고무 장화";
                case "Oxygen Canisters": return "[신체] 산소통 확장";
                case "Hiking Boots": return "[신체] 등산화";
                case "Traction Boots": return "[신체] 접지 부츠";
                case "Mechanical Arms": return "[신체] 보조 기계팔";
                case "Scavenger Instincts": return "[상점] 청소부 본능";
                case "Reinforced Boots": return "[신체] 강철 장화";
                case "Deeper Pockets": return "[신체] 깊은 주머니";
                case "Back Muscles": return "[신체] 등 근육 강화";
                case "Night Vision": return "[아이템] 야간 투시"; // 기존 [아이템]에서 [신체]로 통합 권장
                case "Protein Powder": return "[신체] 단백질 보충";
                case "Bigger Lungs": return "[신체] 폐활량 확장";
                case "Climbing Gloves": return "[신체] 등반 장갑";
                case "Running Shoes": return "[신체] 런닝화";
                case "Stimpack": return "[신체] 스팀팩";
                case "Strong Legs": return "[신체] 하체 강화";
                case "Sick Beats": return "[신체] 붐박스 비트";

                // [함선] 카테고리
                case "Scrap Keeper": return "[함선] 스크랩 보존";
                case "Particle Infuser": return "[함선] 입자 주입기";
                case "Fusion Matter": return "[함선] 세포 융합";
                case "Landing Thrusters": return "[함선] 착륙 분사";
                case "Charging Booster": return "[함선] 차징 부스터";
                case "Discombobulator": return "[함선] 신경 교란기";
                case "Efficient Engines": return "[함선] 효율적 엔진";
                case "Shutter Batteries": return "[함선] 셔터 배터리";
                case "Quantum Disruptor": return "[함선] 양자 교란기";
                case "Fast Encryption": return "[함선] 빠른 암호화";
                case "Drop Pod Thrusters": return "[함선] 로켓 배송";
                case "Lightning Rod": return "[함선] 피뢰침";
                case "Sigurd Access": return "[함선] 시구르드 기록";

                // [아이템/샷건] 카테고리
                case "Silver Bullets": return "[샷건] 은빛 탄환";
                case "Long Barrel": return "[샷건] 롱 배럴";
                case "Hollow Point": return "[샷건] 할로우 포인트";
                case "Sleight of Hand": return "[샷건] 손기술";
                case "Jetpack Thrusters": return "[아이템] 제트팩 노즐";
                case "Jet Fuel": return "[아이템] 제트팩 연료";
                case "Weed Genetic Manipulation": return "[아이템] 제초제 개량";
                case "Aluminium Coils": return "[아이템] 알루미늄 코일";
                case "Better Scanner": return "[아이템] 광역 스캐너";
                case "Lithium Batteries": return "[아이템] 리튬 배터리";
                case "Locksmith": return "[아이템] 열쇠공";
                case "Walkie GPS": return "[아이템] 무전기 GPS";

                // [상점/적] 카테고리
                case "Midas Touch": return "[상점] 미다스의 손";
                case "Life Insurance": return "[상점] 사망 보험";
                case "Bargain Connections": return "[상점] 바겐 세일";
                case "Market Influence": return "[상점] 시장 영향력";
                case "Lethal Deals": return "[상점] 상점 할인";
                case "Fedora Suit": return "[적] 페도라 슈트";
                case "Clay Glasses": return "[적] 투시 안경";
                case "Beekeeper": return "[적] 양봉업자";
                case "Hunter": return "[적] 몬스터 사냥꾼";
                case "Malware Broadcaster": return "[적] 멀웨어 전파";
                case "Baby Pacifier": return "[적] 아기 쪽쪽이";
                case "Item Duplicator": return "[아이템] 1+1 행사상품";
                case "Smarter Lockpick": return "[적] 스마트 자물쇠따기";

                default: return name;
            }
        }

        internal static readonly string EFFECTIVE_BANDAIDS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, EffectiveBandaids.UPGRADE_NAME);
        internal static readonly string MEDICAL_NANOBOTS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, MedicalNanobots.UPGRADE_NAME);
        internal static readonly string SCRAP_KEEPER_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, ScrapKeeper.UPGRADE_NAME);
        internal static readonly string PARTICLE_INFUSER_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, ParticleInfuser.UPGRADE_NAME);
        internal static readonly string SILVER_BULLETS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, SilverBullets.UPGRADE_NAME);
        internal static readonly string FUSION_MATTER_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, FusionMatter.UPGRADE_NAME);
        internal static readonly string LONG_BARREL_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, LongBarrel.UPGRADE_NAME);
        internal static readonly string HOLLOW_POINT_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, HollowPoint.UPGRADE_NAME);
        internal static readonly string JETPACK_THRUSTERS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, JetpackThrusters.UPGRADE_NAME);
        internal static readonly string JET_FUEL_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, JetFuel.UPGRADE_NAME);
        internal static readonly string QUICK_HANDS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, QuickHands.UPGRADE_NAME);
        internal static readonly string MIDAS_TOUCH_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, MidasTouch.UPGRADE_NAME);
        internal static readonly string CARBON_KNEEJOINTS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, CarbonKneejoints.UPGRADE_NAME);
        internal static readonly string LIFE_INSURANCE_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, LifeInsurance.UPGRADE_NAME);
        internal static readonly string RUBBER_BOOTS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, RubberBoots.UPGRADE_NAME);
        internal static readonly string OXYGEN_CANISTERS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, OxygenCanisters.UPGRADE_NAME);
        internal static readonly string SLEIGHT_OF_HAND_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, SleightOfHand.UPGRADE_NAME);
        internal static readonly string HIKING_BOOTS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, HikingBoots.UPGRADE_NAME);
        internal static readonly string TRACTION_BOOTS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, TractionBoots.UPGRADE_NAME);
        internal static readonly string FEDORA_SUIT_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, FedoraSuit.UPGRADE_NAME);
        internal static readonly string WEED_GENETIC_MANIPULATION_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, WeedGeneticManipulation.UPGRADE_NAME);
        internal static readonly string CLAY_GLASSES_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, ClayGlasses.UPGRADE_NAME);
        internal static readonly string MECHANICAL_ARMS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, MechanicalArms.UPGRADE_NAME);
        internal static readonly string SCAVENGER_INSTINCTS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, ScavengerInstincts.UPGRADE_NAME);
        internal static readonly string LANDING_THRUSTERS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, LandingThrusters.UPGRADE_NAME);
        internal static readonly string REINFORCED_BOOTS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, ReinforcedBoots.UPGRADE_NAME);
        internal static readonly string DEEPER_POCKETS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, DeepPockets.UPGRADE_NAME);
        internal static readonly string ALUMINIUM_COILS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, AluminiumCoils.UPGRADE_NAME);
        internal static readonly string BACK_MUSCLES_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, BackMuscles.UPGRADE_NAME);
        internal static readonly string BARGAIN_CONNECTIONS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, BargainConnections.UPGRADE_NAME);
        internal static readonly string BEEKEEPER_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, Beekeeper.UPGRADE_NAME);
        internal static readonly string BETTER_SCANNER_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, BetterScanner.UPGRADE_NAME);
        internal static readonly string CHARGING_BOOSTER_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, ChargingBooster.UPGRADE_NAME);
        internal static readonly string DISCOMBOBULATOR_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, Discombobulator.UPGRADE_NAME);
        internal static readonly string EFFICIENT_ENGINES_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, EfficientEngines.UPGRADE_NAME);
        internal static readonly string HUNTER_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, Hunter.UPGRADE_NAME);
        internal static readonly string LITHIUM_BATTERIES_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, LithiumBatteries.UPGRADE_NAME);
        internal static readonly string MARKET_INFLUENCE_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, MarketInfluence.UPGRADE_NAME);
        internal static readonly string NIGHT_VISION_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, NightVision.UPGRADE_NAME);
        internal static readonly string PROTEIN_POWDER_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, ProteinPowder.UPGRADE_NAME);
        internal static readonly string BIGGER_LUNGS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, BiggerLungs.UPGRADE_NAME);
        internal static readonly string CLIMBING_GLOVES_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, ClimbingGloves.UPGRADE_NAME);
        internal static readonly string SHUTTER_BATTERIES_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, ShutterBatteries.UPGRADE_NAME);
        internal static readonly string QUANTUM_DISRUPTOR_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, QuantumDisruptor.UPGRADE_NAME);
        internal static readonly string RUNNING_SHOES_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, RunningShoes.UPGRADE_NAME);
        internal static readonly string STIMPACK_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, Stimpack.UPGRADE_NAME);
        internal static readonly string STRONG_LEGS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, StrongLegs.UPGRADE_NAME);
        internal static readonly string FAST_ENCRYPTION_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, FastEncryption.UPGRADE_NAME);
        internal static readonly string DROP_POD_THRUSTERS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, FasterDropPod.UPGRADE_NAME);
        internal static readonly string LETHAL_DEALS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, LethalDeals.UPGRADE_NAME);
        internal static readonly string LIGHTNING_ROD_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, LightningRod.UPGRADE_NAME);
        internal static readonly string LOCKSMITH_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, LockSmith.UPGRADE_NAME);
        internal static readonly string MALWARE_BROADCASTER_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, MalwareBroadcaster.UPGRADE_NAME);
        internal static readonly string SICK_BEATS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, SickBeats.UPGRADE_NAME);
        internal static readonly string SIGURD_ACCESS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, Sigurd.UPGRADE_NAME);
        internal static readonly string WALKIE_GPS_OVERRIDE_NAME_KEY = string.Format(OVERRIDE_NAME_KEY_FORMAT, WalkieGPS.UPGRADE_NAME);

        #endregion

        #region Contracts
        internal const string CONTRACTS_SECTION = "계약";

        internal const string ENABLE_CONTRACTS_KEY = "계약/임무 구매 기능을 활성화합니다.";
        internal const bool ENABLE_CONTRACTS_DEFAULT = true;

        internal const string CONTRACT_PROVIDE_RANDOM_ONLY_KEY = "키워드에 대한 무작위 계약";
        internal const bool CONTRACT_PROVIDE_RANDOM_ONLY_DEFAULT = false;
        internal const string CONTRACT_PROVIDE_RANDOM_ONLY_DESCRIPTION = "이 기능을 활성화하면, '계약'을 입력할 때 가능한 경우 자동으로 임의의 계약이 할당됩니다. (기존 방식과 동일합니다.)";

        internal const string CONTRACT_FREE_MOONS_ONLY_KEY = "무료 위성에서만 무작위 계약";
        internal const bool CONTRACT_FREE_MOONS_ONLY_DEFAULT = true;
        internal const string CONTRACT_FREE_MOONS_ONLY_DESCRIPTION = "true이라면, \"contract\" 이 명령어는 무료 위성에서만 계약을 생성합니다.";

        internal const string CONTRACT_PRICE_KEY = "임의 계약의 가격";
        internal const int CONTRACT_PRICE_DEFAULT = 500;

        internal const string CONTRACT_SPECIFY_PRICE_KEY = "특정 위성 계약의 가격";
        internal const int CONTRACT_SPECIFY_PRICE_DEFAULT = 750;

        internal const string CONTRACT_BUG_REWARD_KEY = "해충 방제 계약 보상의 가치";
        internal const int CONTRACT_BUG_REWARD_DEFAULT = CONTRACT_PRICE_DEFAULT;

        internal const string CONTRACT_EXORCISM_REWARD_KEY = "퇴마 계약 보상의 가치";
        internal const int CONTRACT_EXORCISM_REWARD_DEFAULT = CONTRACT_PRICE_DEFAULT;

        internal const string CONTRACT_DEFUSAL_REWARD_KEY = "해체 계약 보상의 가치";
        internal const int CONTRACT_DEFUSAL_REWARD_DEFAULT = CONTRACT_PRICE_DEFAULT;

        internal const string CONTRACT_EXTRACTION_REWARD_KEY = "채굴 계약 보상의 가치";
        internal const int CONTRACT_EXTRACTION_REWARD_DEFAULT = CONTRACT_PRICE_DEFAULT;

        internal const string CONTRACT_DATA_REWARD_KEY = "데이터 계약 보상의 가치";
        internal const int CONTRACT_DATA_REWARD_DEFAULT = CONTRACT_PRICE_DEFAULT;

        internal const string EXTERMINATION_BUG_SPAWNS_KEY = "저장성 벌레 산란 수";
        internal const int EXTERMINATION_BUG_SPAWNS_DEFAULT = 20;
        internal const string EXTERMINATION_BUG_SPAWNS_DESCRIPTION = "해충 박멸 계약 중에 얼마나 많은 벌레가 생성될까요?";

        internal const string EXORCISM_GHOST_SPAWN_KEY = "드레스 걸 / 덤퍼 스폰 번호";
        internal const int EXORCISM_GHOST_SPAWN_DEFAULT = 3;
        internal const string EXORCISM_GHOST_SPAWN_DESCRIPTION = "퇴마 계약 실패 시 유령/괴물이 몇 마리나 소환되나요?";

        internal const string EXTRACTION_SCAVENGER_WEIGHT_KEY = "추출된 인체의 무게";
        internal const float EXTRACTION_SCAVENGER_WEIGHT_DEFAULT = 2.5f;
        internal const string EXTRACTION_SCAVENGER_WEIGHT_DESCRIPTION = "1을 빼고 100을 곱합니다 (2.5 = 150파운드).";

        internal const string EXTRACTION_SCAVENGER_SOUND_VOLUME_KEY = "청소부 음성 클립의 볼륨";
        internal const float EXTRACTION_SCAVENGER_SOUND_VOLUME_DEFAULT = 0.25f;
        internal const string EXTRACTION_SCAVENGER_SOUND_VOLUME_DESCRIPTION = "0.0 - 1.0";

        internal const string CONTRACT_FAR_FROM_MAIN_KEY = "멀리 떨어진 곳에 주요 오브젝트를 생성합니다.";
        internal const bool CONTRACT_FAR_FROM_MAIN_DEFAULT = true;
        internal const string CONTRACT_FAR_FROM_MAIN_DESCRIPTION = "이 설정이 true이면 계약 대상 오브젝트는 정문에서 최대한 멀리 떨어진 곳에 생성되려고 시도합니다. false이면 임의의 위치에 생성됩니다.";

        internal const string EXTRACTION_MEDKIT_AMOUNT_KEY = "추출 계약에서 생성될 수 있는 구급상자의 수량";
        internal const int EXTRACTION_MEDKIT_AMOUNT_DEFAULT = 3;

        internal const string CONTRACT_DATA_ENABLED_KEY = "데이터 계약 활성화";
        internal const bool CONTRACT_DATA_ENABLED_DEFAULT = true;
        internal const string CONTRACT_DATA_ENABLED_DESCRIPTION = "데이터 계약을 원하지 않으면 이 값을 false로 설정하세요.";

        internal const string CONTRACT_EXTRACTION_ENABLED_KEY = "추출 계약 활성화";
        internal const bool CONTRACT_EXTRACTION_ENABLED_DEFAULT = true;
        internal const string CONTRACT_EXTRACTION_ENABLED_DESCRIPTION = "채굴 계약을 원하지 않으면 이 항목을 false으로 설정하세요.";

        internal const string CONTRACT_EXORCISM_ENABLED_KEY = "퇴마 계약을 활성화하세요";
        internal const bool CONTRACT_EXORCISM_ENABLED_DEFAULT = true;
        internal const string CONTRACT_EXORCISM_ENABLED_DESCRIPTION = "퇴마 계약을 원하지 않으시면 이 항목을 false으로 표시하세요.";

        internal const string CONTRACT_DEFUSAL_ENABLED_KEY = "계약 해제를 활성화합니다";
        internal const bool CONTRACT_DEFUSAL_ENABLED_DEFAULT = true;
        internal const string CONTRACT_DEFUSAL_ENABLED_DESCRIPTION = "계약 해제를 원하지 않으면 이 항목을 false으로 설정하세요.";

        internal const string CONTRACT_EXTERMINATION_ENABLED_KEY = "해충 방제 계약을 활성화하세요";
        internal const bool CONTRACT_EXTERMINATION_ENABLED_DEFAULT = true;
        internal const string CONTRACT_EXTERMINATION_ENABLED_DESCRIPTION = "해충 방제 계약을 원하지 않으시면 이 항목을 false으로 표시하세요.";

        internal const string CONTRACT_QUOTA_MULTIPLIER_KEY = "계약 전리품에 적용되는 배율은 현재 적용된 할당량에 따라 달라집니다.";
        internal const int CONTRACT_QUOTA_MULTIPLIER_DEFAULT = 25;
        internal const string CONTRACT_QUOTA_MULTIPLIER_DESCRIPTION = "0 = 할당량 값은 전리품의 가치에 영향을 미치지 않습니다.\n100 = 할당량 값은 전리품 가치에 전액 추가됩니다.";
        #endregion

        #region Interns

        internal const string INTERNS_ENABLED_KEY = "인턴 채용을 활성화하세요";
        internal const bool INTERNS_ENABLED_DEFAULT = true;
        internal const string INTERNS_ENABLED_DESCRIPTION = "플레이어를 부활시키려면 일정 금액의 크레딧을 지불하세요.";

        internal const string INTERNS_PRICE_KEY = $"{Interns.NAME} 가격";
        internal const int INTERNS_PRICE_DEFAULT = 1000;
        internal const string INTERNS_PRICE_DESCRIPTION = "인턴 고용 기본 가격.";

        #endregion

        #region Items

        internal const string ITEM_SCAN_NODE_KEY_FORMAT = "{0}의 스캔 노드를 활성화합니다.";
        internal const bool ITEM_SCAN_NODE_DEFAULT = true;
        internal const string ITEM_SCAN_NODE_DESCRIPTION = "스캔 시 항목에 스캔 노드가 표시됩니다.";

        #region Medkit

        internal const string MEDKIT_ENABLED_KEY = $"{Medkit.ITEM_NAME} 항목을 활성화하세요";
        internal const bool MEDKIT_ENABLED_DEFAULT = true;
        internal const string MEDKIT_ENABLED_DESCRIPTION = $"{Medkit.ITEM_NAME}을 구매하여 스스로를 치료할 수 있습니다.";

        internal const string MEDKIT_PRICE_KEY = $"{Medkit.ITEM_NAME} 가격";
        internal const int MEDKIT_PRICE_DEFAULT = 300;
        internal const string MEDKIT_PRICE_DESCRIPTION = $"{Medkit.ITEM_NAME}의 기본 가격입니다.";

        internal const string MEDKIT_HEAL_AMOUNT_KEY = "치유량";
        internal const int MEDKIT_HEAL_AMOUNT_DEFAULT = 20;
        internal const string MEDKIT_HEAL_AMOUNT_DESCRIPTION = $"{Medkit.ITEM_NAME}이 당신을 치료하는 양입니다.";

        internal const string MEDKIT_USES_KEY = "사용횟수";
        internal const int MEDKIT_USES_DEFAULT = 3;
        internal const string MEDKIT_USES_DESCRIPTION = $"{Medkit.ITEM_NAME}으로 치료할 수 있는 횟수입니다.";

        internal static readonly string MEDKIT_SCAN_NODE_KEY = string.Format(ITEM_SCAN_NODE_KEY_FORMAT, Medkit.ITEM_NAME);
        #endregion

        #endregion

        #region Upgrades

        internal const string ENABLED_FORMAT = "{0} 업그레이드 활성화";
        internal const string PRICE_FORMAT = "{0} 업그레이드 가격";

        #region Smarter Lockpick
        internal const string SMARTER_LOCKPICK_ENABLED_DESCRIPTION = "자물쇠 따개 아이템의 효율을 높여 문을 더 빠르게 열 수 있도록 하는 등급 업그레이드입니다.";

        internal const string SMARTER_LOCKPICK_INITIAL_INCREASE_KEY = "초기 효율성 증가";
        internal const int SMARTER_LOCKPICK_INITIAL_INCREASE_DEFAULT = 100;
        internal const string SMARTER_LOCKPICK_INITIAL_INCREASE_DESCRIPTION = "자물쇠 따기 도구의 문 열기 효율 초기 증가율(%), 자물쇠 따기에 필요한 시간 단축";

        internal const string SMARTER_LOCKPICK_INCREMENTAL_INCREASE_KEY = "점진적 효율성 증가";
        internal const int SMARTER_LOCKPICK_INCREMENTAL_INCREASE_DEFAULT = 100;
        internal const string SMARTER_LOCKPICK_INCREMENTAL_INCREASE_DESCRIPTION = "자물쇠 따기 도구의 문 열기 효율 증가율(%), 자물쇠 따기에 필요한 시간 단축";
		#endregion

		#region Effective Bandaids

		internal const string EFFECTIVE_BANDAIDS_ENABLED_KEY = $"{EffectiveBandaids.UPGRADE_NAME} 업그레이드를 활성화하세요";
        internal const bool EFFECTIVE_BANDAIDS_ENABLED_DEFAULT = true;
        internal const string EFFECTIVE_BANDAIDS_ENABLED_DESCRIPTION = "체력 회복량을 증가시키는 티어 업그레이드입니다.";

        internal const string EFFECTIVE_BANDAIDS_PRICE_KEY = $"{EffectiveBandaids.UPGRADE_NAME} 업그레이드 가격";
        internal const int EFFECTIVE_BANDAIDS_PRICE_DEFAULT = 250;

        internal const string EFFECTIVE_BANDAIDS_INITIAL_HEALTH_REGEN_AMOUNT_INCREASE_KEY = "초기 체력 회복량 증가";
        internal const int EFFECTIVE_BANDAIDS_INITIAL_HEALTH_REGEN_AMOUNT_INCREASE_DEFAULT = 1;
        internal const string EFFECTIVE_BANDAIDS_INITIAL_HEALTH_REGEN_AMOUNT_INCREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 체력 회복 중 초기 체력 증가량.";

        internal const string EFFECTIVE_BANDAIDS_INCREMENTAL_HEALTH_REGEN_AMOUNT_INCREASE_KEY = "체력 회복량 점진적 증가";
        internal const int EFFECTIVE_BANDAIDS_INCREMENTAL_HEALTH_REGEN_AMOUNT_INCREASE_DEFAULT = 1;
        internal const string EFFECTIVE_BANDAIDS_INCREMENTAL_HEALTH_REGEN_AMOUNT_INCREASE_DESCRIPTION = "업그레이드 레벨을 추가로 구매할 때 체력 회복량 증가";

        #endregion

        #region Medical Nanobots

        internal const string MEDICAL_NANOBOTS_ENABLED_KEY = $"{MedicalNanobots.UPGRADE_NAME} 업그레이드를 활성화하세요";
        internal const bool MEDICAL_NANOBOTS_ENABLED_DEFAULT = true;
        internal const string MEDICAL_NANOBOTS_ENABLED_DESCRIPTION = "체력 회복 한도를 증가시키는 티어 업그레이드입니다.";

        internal const string MEDICAL_NANOBOTS_PRICE_KEY = $"{MedicalNanobots.UPGRADE_NAME} 업그레이드 가격";
        internal const int MEDICAL_NANOBOTS_PRICE_DEFAULT = 300;

        internal const string MEDICAL_NANOBOTS_INITIAL_HEALTH_REGEN_CAP_INCREASE_KEY = "초기 체력 회복 한도 증가";
        internal const int MEDICAL_NANOBOTS_INITIAL_HEALTH_REGEN_CAP_INCREASE_DEFAULT = 50;
        internal const string MEDICAL_NANOBOTS_INITIAL_HEALTH_REGEN_CAP_INCREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 체력 회복 한도의 초기 증가율(%).";

        internal const string MEDICAL_NANOBOTS_INCREMENTAL_HEALTH_REGEN_CAP_INCREASE_KEY = "점진적 체력 회복 한도 증가";
        internal const int MEDICAL_NANOBOTS_INCREMENTAL_HEALTH_REGEN_CAP_INCREASE_DEFAULT = 50;
        internal const string MEDICAL_NANOBOTS_INCREMENTAL_HEALTH_REGEN_CAP_INCREASE_DESCRIPTION = "추가 업그레이드 레벨 구매 시 체력 회복 한도의 점진적 증가율(%)";

        #endregion

        #region Scrap Keeper

        internal const string SCRAP_KEEPER_ENABLED_KEY = $"{ScrapKeeper.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool SCRAP_KEEPER_ENABLED_DEFAULT = true;
        internal const string SCRAP_KEEPER_ENABLED_DESCRIPTION = "팀 전멸 시 스크랩 아이템을 유지할 확률을 부여하는 티어 업그레이드입니다.";

        internal const string SCRAP_KEEPER_PRICE_KEY = $"{ScrapKeeper.UPGRADE_NAME} 업그레이드 가격";
        internal const int SCRAP_KEEPER_PRICE_DEFAULT = 1000;

        internal const string SCRAP_KEEPER_INITIAL_KEEP_SCRAP_CHANCE_INCREASE_KEY = "초기 스크랩 보존 확률 증가";
        internal const int SCRAP_KEEPER_INITIAL_KEEP_SCRAP_CHANCE_INCREASE_DEFAULT = 25;
        internal const string SCRAP_KEEPER_INITIAL_KEEP_SCRAP_CHANCE_INCREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 스크랩 아이템 보존 확률의 초기 증가율(%)";

        internal const string SCRAP_KEEPER_INCREMENTAL_KEEP_SCRAP_CHANCE_INCREASE_KEY = "점진적 스크랩 보존 확률 증가";
        internal const int SCRAP_KEEPER_INCREMENTAL_KEEP_SCRAP_CHANCE_INCREASE_DEFAULT = 25;
        internal const string SCRAP_KEEPER_INCREMENTAL_KEEP_SCRAP_CHANCE_INCREASE_DESCRIPTION = "추가 업그레이드 레벨 구매 시 스크랩 아이템 보존 확률의 점진적 증가율(%)";

        #endregion

        #region Particle Infuser

        internal const string PARTICLE_INFUSER_ENABLED_KEY = $"{ParticleInfuser.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool PARTICLE_INFUSER_ENABLED_DEFAULT = true;
        internal const string PARTICLE_INFUSER_ENABLED_DESCRIPTION = "텔레포터의 순간이동 속도를 증가시키는 티어 업그레이드입니다.";

        internal const string PARTICLE_INFUSER_PRICE_KEY = $"{ParticleInfuser.UPGRADE_NAME} 업그레이드 가격";
        internal const int PARTICLE_INFUSER_PRICE_DEFAULT = 650;

        internal const string PARTICLE_INFUSER_INITIAL_TELEPORT_SPEED_INCREASE_KEY = "초기 순간이동 속도 증가";
        internal const int PARTICLE_INFUSER_INITIAL_TELEPORT_SPEED_INCREASE_DEFAULT = 20;
        internal const string PARTICLE_INFUSER_INITIAL_TELEPORT_SPEED_INCREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 텔레포터 속도의 초기 증가율(%)";

        internal const string PARTICLE_INFUSER_INCREMENTAL_TELEPORT_SPEED_INCREASE_KEY = "점진적 순간이동 속도 증가";
        internal const int PARTICLE_INFUSER_INCREMENTAL_TELEPORT_SPEED_INCREASE_DEFAULT = 10;
        internal const string PARTICLE_INFUSER_INCREMENTAL_TELEPORT_SPEED_INCREASE_DESCRIPTION = "추가 업그레이드 레벨 구매 시 텔레포터 속도의 점진적 증가율(%)";

        #endregion

        #region Silver Bullets

        internal const string SILVER_BULLETS_ENABLED_KEY = $"{SilverBullets.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool SILVER_BULLETS_ENABLED_DEFAULT = true;
        internal const string SILVER_BULLETS_ENABLED_DESCRIPTION = "샷건으로 유령 소녀 개체를 처치할 수 있게 해주는 1회성 업그레이드입니다.";

        internal const string SILVER_BULLETS_PRICE_KEY = $"{SilverBullets.UPGRADE_NAME} 업그레이드 가격";
        internal const int SILVER_BULLETS_PRICE_DEFAULT = 500;

        #endregion

        #region Fusion Matter

        internal const string FUSION_MATTER_ENABLED_KEY = $"{FusionMatter.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool FUSION_MATTER_ENABLED_DEFAULT = true;
        internal const string FUSION_MATTER_ENABLED_DESCRIPTION = "순간이동 시 지정된 아이템을 함께 가져갈 수 있도록 해주는 티어 업그레이드입니다(양방향 모두 적용).";

        internal const string FUSION_MATTER_PRICE_KEY = $"{FusionMatter.UPGRADE_NAME} 업그레이드 가격";
        internal const int FUSION_MATTER_PRICE_DEFAULT = 500;

        internal const string FUSION_MATTER_TIERS_KEY = "Fusion Matter Tiers";
        internal static readonly string FUSION_MATTER_TIERS_DEFAULT = $"key{FUSION_MATTER_ITEM_DELIMITER} flashlight{FUSION_MATTER_ITEM_DELIMITER} walkie-talkie{FUSION_MATTER_TIER_DELIMITER}" +
            $"shovel{FUSION_MATTER_ITEM_DELIMITER} pro-flashlight{FUSION_MATTER_TIER_DELIMITER}" +
            $"belt bag{FUSION_MATTER_ITEM_DELIMITER} radar-booster";
        internal static readonly string FUSION_MATTER_TIERS_DESCRIPTION = "List of items that will be kept in the player's inventory once reached a certain level of the upgrade. You can include names shown in their scan nodes or the names shown in the Company store.\n" +
            $"\'{FUSION_MATTER_ITEM_DELIMITER}\' is used to separate items in a tier.\n" +
            $"\'{FUSION_MATTER_TIER_DELIMITER}\' is used to separate tiers of the upgrade";

        internal const char FUSION_MATTER_TIER_DELIMITER = '@';
        internal const char FUSION_MATTER_ITEM_DELIMITER = ',';

        #endregion

        #region Long Barrel

        internal const string LONG_BARREL_ENABLED_KEY = $"{LongBarrel.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool LONG_BARREL_ENABLED_DEFAULT = true;
        internal const string LONG_BARREL_ENABLED_DESCRIPTION = "샷건의 전체 사거리와 유효 데미지 사거리를 증가시키는 티어 업그레이드입니다.";

        internal const string LONG_BARREL_PRICE_KEY = $"{LongBarrel.UPGRADE_NAME} 업그레이드 가격";
        internal const int LONG_BARREL_PRICE_DEFAULT = 500;

        internal const string LONG_BARREL_INITIAL_SHOTGUN_RANGE_INCREASE_KEY = "초기 샷건 사거리 증가";
        internal const int LONG_BARREL_INITIAL_SHOTGUN_RANGE_INCREASE_DEFAULT = 10;
        internal const string LONG_BARREL_INITIAL_SHOTGUN_RANGE_INCREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 샷건 사거리의 초기 증가율(%)";

        internal const string LONG_BARREL_INCREMENTAL_SHOTGUN_RANGE_INCREASE_KEY = "점진적 샷건 사거리 증가";
        internal const int LONG_BARREL_INCREMENTAL_SHOTGUN_RANGE_INCREASE_DEFAULT = 10;
        internal const string LONG_BARREL_INCREMENTAL_SHOTGUN_RANGE_INCREASE_DESCRIPTION = "추가 업그레이드 레벨 구매 시 샷건 사거리의 점진적 증가율(%)";

        #endregion

        #region Hollow Point

        internal const string HOLLOW_POINT_ENABLED_KEY = $"{HollowPoint.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool HOLLOW_POINT_ENABLED_DEFAULT = true;
        internal const string HOLLOW_POINT_ENABLED_DESCRIPTION = "샷건의 데미지를 증가시키는 티어 업그레이드입니다.";

        internal const string HOLLOW_POINT_PRICE_KEY = $"{HollowPoint.UPGRADE_NAME} 업그레이드 가격";
        internal const int HOLLOW_POINT_PRICE_DEFAULT = 750;

        internal const string HOLLOW_POINT_INITIAL_SHOTGUN_DAMAGE_INCREASE_KEY = "초기 샷건 데미지 증가";
        internal const int HOLLOW_POINT_INITIAL_SHOTGUN_DAMAGE_INCREASE_DEFAULT = 1;
        internal const string HOLLOW_POINT_INITIAL_SHOTGUN_DAMAGE_INCREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 샷건의 초기 데미지 증가량";

        internal const string HOLLOW_POINT_INCREMENTAL_SHOTGUN_DAMAGE_INCREASE_KEY = "점진적 샷건 데미지 증가";
        internal const int HOLLOW_POINT_INCREMENTAL_SHOTGUN_DAMAGE_INCREASE_DEFAULT = 1;
        internal const string HOLLOW_POINT_INCREMENTAL_SHOTGUN_DAMAGE_INCREASE_DESCRIPTION = "추가 업그레이드 레벨 구매 시 샷건의 점진적 데미지 증가량";

        #endregion

        #region Jetpack Thrusters

        internal const string JETPACK_THRUSTERS_ENABLED_KEY = $"{JetpackThrusters.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool JETPACK_THRUSTERS_ENABLED_DEFAULT = true;
        internal const string JETPACK_THRUSTERS_ENABLED_DESCRIPTION = "비행 중 제트팩의 최대 속도를 증가시키는 티어 업그레이드입니다.";

        internal const string JETPACK_THRUSTERS_PRICE_KEY = $"{JetpackThrusters.UPGRADE_NAME} 업그레이드 가격";
        internal const int JETPACK_THRUSTERS_PRICE_DEFAULT = 300;

        internal const string JETPACK_THRUSTERS_INITIAL_MAXIMUM_POWER_INCREASE_KEY = "초기 최대 속도 증가";
        internal const int JETPACK_THRUSTERS_INITIAL_MAXIMUM_POWER_INCREASE_DEFAULT = 20;
        internal const string JETPACK_THRUSTERS_INITIAL_MAXIMUM_POWER_INCREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 비행 중 제트팩 최대 속도의 초기 증가율(%)";

        internal const string JETPACK_THRUSTERS_INCREMENTAL_MAXIMUM_POWER_INCREASE_KEY = "점진적 최대 속도 증가";
        internal const int JETPACK_THRUSTERS_INCREMENTAL_MAXIMUM_POWER_INCREASE_DEFAULT = 20;
        internal const string JETPACK_THRUSTERS_INCREMENTAL_MAXIMUM_POWER_INCREASE_DESCRIPTION = "추가 업그레이드 레벨 구매 시 비행 중 제트팩 최대 속도의 점진적 증가율(%)";

        #endregion

        #region Jet Fuel

        internal const string JET_FUEL_ENABLED_KEY = $"{JetFuel.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool JET_FUEL_ENABLED_DEFAULT = true;
        internal const string JET_FUEL_ENABLED_DESCRIPTION = "비행 중 제트팩의 가속도를 증가시키는 티어 업그레이드입니다.";

        internal const string JET_FUEL_PRICE_KEY = $"{JetFuel.UPGRADE_NAME} 업그레이드 가격";
        internal const int JET_FUEL_PRICE_DEFAULT = 400;

        internal const string JET_FUEL_INITIAL_ACCELERATION_INCREASE_KEY = "초기 가속도 증가";
        internal const int JET_FUEL_INITIAL_ACCELERATION_INCREASE_DEFAULT = 20;
        internal const string JET_FUEL_INITIAL_ACCELERATION_INCREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 제트팩 가속도의 초기 증가율(%)";

        internal const string JET_FUEL_INCREMENTAL_ACCELERATION_INCREASE_KEY = "점진적 가속도 증가";
        internal const int JET_FUEL_INCREMENTAL_ACCELERATION_INCREASE_DEFAULT = 20;
        internal const string JET_FUEL_INCREMENTAL_ACCELERATION_INCREASE_DESCRIPTION = "추가 업그레이드 레벨 구매 시 제트팩 가속도의 점진적 증가율(%)";

        #endregion

        #region Quick Hands

        internal const string QUICK_HANDS_ENABLED_KEY = $"{QuickHands.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool QUICK_HANDS_ENABLED_DEFAULT = true;
        internal const string QUICK_HANDS_ENABLED_DESCRIPTION = "플레이어의 상호작용 속도를 증가시키는 티어 업그레이드입니다.";

        internal const string QUICK_HANDS_PRICE_KEY = $"{QuickHands.UPGRADE_NAME} 업그레이드 가격";
        internal const int QUICK_HANDS_PRICE_DEFAULT = 100;

        internal const string QUICK_HANDS_INITIAL_INTERACTION_SPEED_INCREASE_KEY = "초기 상호작용 속도 증가";
        internal const int QUICK_HANDS_INITIAL_INTERACTION_SPEED_INCREASE_DEFAULT = 20;
        internal const string QUICK_HANDS_INITIAL_INTERACTION_SPEED_INCREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 상호작용 속도의 초기 증가율(%)";

        internal const string QUICK_HANDS_INCREMENTAL_INTERACTION_SPEED_INCREASE_KEY = "점진적 상호작용 속도 증가";
        internal const int QUICK_HANDS_INCREMENTAL_INTERACTION_SPEED_INCREASE_DEFAULT = 20;
        internal const string QUICK_HANDS_INCREMENTAL_INTERACTION_SPEED_INCREASE_DESCRIPTION = "추가 업그레이드 레벨 구매 시 상호작용 속도의 점진적 증가율(%)";

        #endregion

        #region Midas Touch

        internal const string MIDAS_TOUCH_ENABLED_KEY = $"{MidasTouch.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool MIDAS_TOUCH_ENABLED_DEFAULT = true;
        internal const string MIDAS_TOUCH_ENABLED_DESCRIPTION = "위성에서 발견되는 스크랩의 가치를 증가시키는 티어 업그레이드입니다.";

        internal const string MIDAS_TOUCH_PRICE_KEY = $"{MidasTouch.UPGRADE_NAME} 업그레이드 가격";
        internal const int MIDAS_TOUCH_PRICE_DEFAULT = 1000;

        internal const string MIDAS_TOUCH_INITIAL_SCRAP_VALUE_INCREASE_KEY = "초기 스크랩 가치 증가";
        internal const int MIDAS_TOUCH_INITIAL_SCRAP_VALUE_INCREASE_DEFAULT = 20;
        internal const string MIDAS_TOUCH_INITIAL_SCRAP_VALUE_INCREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 위성 스크랩 가치의 초기 증가율(%)";

        internal const string MIDAS_TOUCH_INCREMENTAL_SCRAP_VALUE_INCREASE_KEY = "점진적 스크랩 가치 증가";
        internal const int MIDAS_TOUCH_INCREMENTAL_SCRAP_VALUE_INCREASE_DEFAULT = 20;
        internal const string MIDAS_TOUCH_INCREMENTAL_SCRAP_VALUE_INCREASE_DESCRIPTION = "추가 업그레이드 레벨 구매 시 위성 스크랩 가치의 점진적 증가율(%)";

        #endregion

        #region Carbon Kneejoints

        internal const string CARBON_KNEEJOINTS_ENABLED_KEY = $"{CarbonKneejoints.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool CARBON_KNEEJOINTS_ENABLED_DEFAULT = true;
        internal const string CARBON_KNEEJOINTS_ENABLED_DESCRIPTION = "웅크리기 시 이동 속도 감소를 줄여주는 티어 업그레이드입니다.";

        internal const string CARBON_KNEEJOINTS_PRICE_KEY = $"{CarbonKneejoints.UPGRADE_NAME} 업그레이드 가격";
        internal const int CARBON_KNEEJOINTS_PRICE_DEFAULT = 100;

        internal const string CARBON_KNEEJOINTS_INITIAL_CROUCH_DEBUFF_DECREASE_KEY = "초기 웅크리기 이동 속도 패널티 감소";
        internal const int CARBON_KNEEJOINTS_INITIAL_CROUCH_DEBUFF_DECREASE_DEFAULT = 20;
        internal const string CARBON_KNEEJOINTS_INITIAL_CROUCH_DEBUFF_DECREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 웅크리기 중 이동 속도 감소량의 초기 감소율(%)";

        internal const string CARBON_KNEEJOINTS_INCREMENTAL_CROUCH_DEBUFF_DECREASE_KEY = "점진적 웅크리기 이동 속도 패널티 감소";
        internal const int CARBON_KNEEJOINTS_INCREMENTAL_CROUCH_DEBUFF_DECREASE_DEFAULT = 20;
        internal const string CARBON_KNEEJOINTS_INCREMENTAL_CROUCH_DEBUFF_DECREASE_DESCRIPTION = "추가 업그레이드 레벨 구매 시 웅크리기 중 이동 속도 감소량의 점진적 감소율(%)";

        #endregion

        #region Life Insurance

        internal const string LIFE_INSURANCE_ENABLED_KEY = $"{LifeInsurance.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool LIFE_INSURANCE_ENABLED_DEFAULT = true;
        internal const string LIFE_INSURANCE_ENABLED_DESCRIPTION = "위성을 떠날 때 시신을 두고 가는 경우 발생하는 크레딧 손실을 줄여주는 티어 업그레이드입니다.";

        internal const string LIFE_INSURANCE_PRICE_KEY = $"{LifeInsurance.UPGRADE_NAME} 업그레이드 가격";
        internal const int LIFE_INSURANCE_PRICE_DEFAULT = 200;

        internal const string LIFE_INSURANCE_INITIAL_COST_PERCENTAGE_DECREASE_KEY = "초기 크레딧 손실 감소";
        internal const int LIFE_INSURANCE_INITIAL_COST_PERCENTAGE_DECREASE_DEFAULT = 20;
        internal const string LIFE_INSURANCE_INITIAL_COST_PERCENTAGE_DECREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 크레딧 손실의 초기 감소율(%)";

        internal const string LIFE_INSURANCE_INCREMENTAL_COST_PERCENTAGE_DECREASE_KEY = "점진적 크레딧 손실 감소";
        internal const int LIFE_INSURANCE_INCREMENTAL_COST_PERCENTAGE_DECREASE_DEFAULT = 20;
        internal const string LIFE_INSURANCE_INCREMENTAL_COST_PERCENTAGE_DECREASE_DESCRIPTION = "추가 업그레이드 레벨 구매 시 크레딧 손실의 점진적 감소율(%)";

        #endregion

        #region Rubber Boots

        internal const string RUBBER_BOOTS_ENABLED_KEY = $"{RubberBoots.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool RUBBER_BOOTS_ENABLED_DEFAULT = true;
        internal const string RUBBER_BOOTS_ENABLED_DESCRIPTION = "물 표면 위를 걸을 때의 이동 방해를 줄여주는 티어 업그레이드입니다.";

        internal const string RUBBER_BOOTS_PRICE_KEY = $"{RubberBoots.UPGRADE_NAME} 업그레이드 가격";
        internal const int RUBBER_BOOTS_PRICE_DEFAULT = 50;

        internal const string RUBBER_BOOTS_INITIAL_MOVEMENT_HINDERANCE_DECREASE_KEY = "초기 이동 방해 감소";
        internal const int RUBBER_BOOTS_INITIAL_MOVEMENT_HINDERANCE_DECREASE_DEFAULT = 20;
        internal const string RUBBER_BOOTS_INITIAL_MOVEMENT_HINDERANCE_DECREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 물 표면 위 이동 방해의 초기 감소율(%)";

        internal const string RUBBER_BOOTS_INCREMENTAL_MOVEMENT_HINDERANCE_DECREASE_KEY = "점진적 이동 방해 감소";
        internal const int RUBBER_BOOTS_INCREMENTAL_MOVEMENT_HINDERANCE_DECREASE_DEFAULT = 20;
        internal const string RUBBER_BOOTS_INCREMENTAL_MOVEMENT_HINDERANCE_DECREASE_DESCRIPTION = "추가 업그레이드 레벨 구매 시 물 표면 위 이동 방해의 점진적 감소율(%)";

        #endregion

        #region Oxygen Canisters

        internal const string OXYGEN_CANISTERS_ENABLED_KEY = $"{OxygenCanisters.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool OXYGEN_CANISTERS_ENABLED_DEFAULT = true;
        internal const string OXYGEN_CANISTERS_ENABLED_DESCRIPTION = "수중에서 산소 소모 속도를 줄여주는 티어 업그레이드입니다.";

        internal const string OXYGEN_CANISTERS_PRICE_KEY = $"{OxygenCanisters.UPGRADE_NAME} 업그레이드 가격";
        internal const int OXYGEN_CANISTERS_PRICE_DEFAULT = 100;

        internal const string OXYGEN_CANISTERS_INITIAL_OXYGEN_CONSUMPTION_DECREASE_KEY = "초기 산소 소모 감소";
        internal const int OXYGEN_CANISTERS_INITIAL_OXYGEN_CONSUMPTION_DECREASE_DEFAULT = 20;
        internal const string OXYGEN_CANISTERS_INITIAL_OXYGEN_CONSUMPTION_DECREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 산소 소모량의 초기 감소율(%)";

        internal const string OXYGEN_CANISTERS_INCREMENTAL_OXYGEN_CONSUMPTION_DECREASE_KEY = "점진적 산소 소모 감소";
        internal const int OXYGEN_CANISTERS_INCREMENTAL_OXYGEN_CONSUMPTION_DECREASE_DEFAULT = 20;
        internal const string OXYGEN_CANISTERS_INCREMENTAL_OXYGEN_CONSUMPTION_DECREASE_DESCRIPTION = "추가 업그레이드 레벨 구매 시 산소 소모량의 점진적 감소율(%)";

        #endregion

        #region Sleight of Hand

        internal const string SLEIGHT_OF_HAND_ENABLED_KEY = $"{SleightOfHand.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool SLEIGHT_OF_HAND_ENABLED_DEFAULT = true;
        internal const string SLEIGHT_OF_HAND_ENABLED_DESCRIPTION = "샷건 재장전 시간을 줄여주는 티어 업그레이드입니다.";

        internal const string SLEIGHT_OF_HAND_PRICE_KEY = $"{SleightOfHand.UPGRADE_NAME} 업그레이드 가격";
        internal const int SLEIGHT_OF_HAND_PRICE_DEFAULT = 100;

        internal const string SLEIGHT_OF_HAND_INITIAL_INCREASE_KEY = "초기 재장전 속도 증가";
        internal const int SLEIGHT_OF_HAND_INITIAL_INCREASE_DEFAULT = 25;
        internal const string SLEIGHT_OF_HAND_INITIAL_INCREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 재장전 속도의 초기 증가율(%)";

        internal const string SLEIGHT_OF_HAND_INCREMENTAL_INCREASE_KEY = "점진적 재장전 속도 증가";
        internal const int SLEIGHT_OF_HAND_INCREMENTAL_INCREASE_DEFAULT = 25;
        internal const string SLEIGHT_OF_HAND_INCREMENTAL_INCREASE_DESCRIPTION = "추가 업그레이드 레벨 구매 시 재장전 속도의 점진적 증가율(%)";

        #endregion

        #region Hiking Boots

        internal const string HIKING_BOOTS_ENABLED_KEY = $"{HikingBoots.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool HIKING_BOOTS_ENABLED_DEFAULT = true;
        internal const string HIKING_BOOTS_ENABLED_DESCRIPTION = "오르막 경사를 오를 때의 페널티를 줄여주는 티어 업그레이드입니다.";

        internal const string HIKING_BOOTS_PRICE_KEY = $"{HikingBoots.UPGRADE_NAME} 업그레이드 가격";
        internal const int HIKING_BOOTS_PRICE_DEFAULT = 75;

        internal const string HIKING_BOOTS_INITIAL_DECREASE_KEY = "초기 오르막 경사 패널티 감소";
        internal const int HIKING_BOOTS_INITIAL_DECREASE_DEFAULT = 25;
        internal const string HIKING_BOOTS_INITIAL_DECREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 오르막 경사 패널티의 초기 감소율(%)";

        internal const string HIKING_BOOTS_INCREMENTAL_DECREASE_KEY = "점진적 오르막 경사 패널티 감소";
        internal const int HIKING_BOOTS_INCREMENTAL_DECREASE_DEFAULT = 25;
        internal const string HIKING_BOOTS_INCREMENTAL_DECREASE_DESCRIPTION = "추가 업그레이드 레벨 구매 시 오르막 경사 패널티의 점진적 감소율(%)";

        #endregion

        #region Traction Boots

        internal const string TRACTION_BOOTS_ENABLED_KEY = $"{TractionBoots.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool TRACTION_BOOTS_ENABLED_DEFAULT = true;
        internal const string TRACTION_BOOTS_ENABLED_DESCRIPTION = "플레이어 이동 시 지면 접지력을 증가시키는 티어 업그레이드입니다.";

        internal const string TRACTION_BOOTS_PRICE_KEY = $"{TractionBoots.UPGRADE_NAME} 업그레이드 가격";
        internal const int TRACTION_BOOTS_PRICE_DEFAULT = 100;

        internal const string TRACTION_BOOTS_INITIAL_INCREASE_KEY = "초기 접지력 증가";
        internal const int TRACTION_BOOTS_INITIAL_INCREASE_DEFAULT = 25;
        internal const string TRACTION_BOOTS_INITIAL_INCREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 플레이어 보행력에 적용되는 배율(%)";

        internal const string TRACTION_BOOTS_INCREMENTAL_INCREASE_KEY = "점진적 접지력 증가";
        internal const int TRACTION_BOOTS_INCREMENTAL_INCREASE_DEFAULT = 25;
        internal const string TRACTION_BOOTS_INCREMENTAL_INCREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 플레이어 보행력에 적용되는 초기값에 추가되는 배율(%).";

        #endregion

        #region Fedora Suit

        internal const string FEDORA_SUIT_ENABLED_KEY = $"{FedoraSuit.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool FEDORA_SUIT_ENABLED_DEFAULT = true;
        internal const string FEDORA_SUIT_ENABLED_DESCRIPTION = "혼자 있을 때 집사(Butler) 적이 적대적으로 반응하지 않게 해주는 1회성 업그레이드입니다. (직접 공격 시에는 여전히 적대적으로 반응합니다)";

        internal const string FEDORA_SUIT_PRICE_KEY = $"{FedoraSuit.UPGRADE_NAME} 업그레이드 가격";
        internal const int FEDORA_SUIT_PRICE_DEFAULT = 750;

        #endregion

        #region Weed Genetic Manipulation

        internal const string WEED_GENETIC_MANIPULATION_ENABLED_KEY = $"{WeedGeneticManipulation.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool WEED_GENETIC_MANIPULATION_ENABLED_DEFAULT = true;
        internal const string WEED_GENETIC_MANIPULATION_ENABLED_DESCRIPTION = "잡초 제거제(Weed Killer)의 식물 제거 효율을 향상시키는 티어 업그레이드입니다.";

        internal const string WEED_GENETIC_MANIPULATION_PRICE_KEY = $"{WeedGeneticManipulation.UPGRADE_NAME} 업그레이드 가격";
        internal const int WEED_GENETIC_MANIPULATION_PRICE_DEFAULT = 100;

        internal const string WEED_GENETIC_INITIAL_EFFECTIVENESS_INCREASE_KEY = "초기 효율 증가";
        internal const int WEED_GENETIC_INITIAL_EFFECTIVENESS_INCREASE_DEFAULT = 75;
        internal const string WEED_GENETIC_INITIAL_EFFECTIVENESS_INCREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 잡초 제거제의 식물 제거 효율 초기 증가량(%)";

        internal const string WEED_GENETIC_INCREMENTAL_EFFECTIVENESS_INCREASE_KEY = "점진적 효율 증가";
        internal const int WEED_GENETIC_INCREMENTAL_EFFECTIVENESS_INCREASE_DEFAULT = 50;
        internal const string WEED_GENETIC_INCREMENTAL_EFFECTIVENESS_INCREASE_DESCRIPTION = "추가 업그레이드 레벨 구매 시 잡초 제거제의 식물 제거 효율 점진적 증가량(%)";

        #endregion

        #region Clay Glasses

        internal const string CLAY_GLASSES_ENABLED_KEY = $"{ClayGlasses.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool CLAY_GLASSES_ENABLED_DEFAULT = true;
        internal const string CLAY_GLASSES_ENABLED_DESCRIPTION = "점토 외과의(Clay Surgeon) 개체를 발견할 수 있는 거리를 증가시키는 티어 업그레이드입니다.";

        internal const string CLAY_GLASSES_PRICE_KEY = $"{ClayGlasses.UPGRADE_NAME} 업그레이드 가격";
        internal const int CLAY_GLASSES_PRICE_DEFAULT = 200;

        internal const string CLAY_GLASSES_DISTANCE_INITIAL_INCREASE_KEY = "초기 거리 증가";
        internal const float CLAY_GLASSES_DISTANCE_INITIAL_INCREASE_DEFAULT = 10f;
        internal const string CLAY_GLASSES_DISTANCE_INITIAL_INCREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 점토 외과의를 발견할 수 있는 거리 증가량";

        internal const string CLAY_GLASSES_DISTANCE_INCREMENTAL_INCREASE_KEY = "점진적 거리 증가";
        internal const float CLAY_GLASSES_DISTANCE_INCREMENTAL_INCREASE_DEFAULT = 5f;
        internal const string CLAY_GLASSES_DISTANCE_INCREMENTAL_INCREASE_DESCRIPTION = "추가 업그레이드 레벨 구매 시 점토 외과의를 발견할 수 있는 거리 증가량";

        #endregion

        #region Hunter

        internal const string HUNTER_ENABLED_KEY = $"{Hunter.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool HUNTER_ENABLED_DEFAULT = true;
        internal const string HUNTER_ENABLED_DESCRIPTION = "죽은 적으로부터 샘플을 수집하여 판매할 수 있습니다.";

        internal const string HUNTER_PRICE_KEY = $"{Hunter.UPGRADE_NAME} 업그레이드 가격";
        internal const int HUNTER_PRICE_DEFAULT = 700;

        internal const string HUNTER_SAMPLE_TIERS_KEY = "각 티어별 샘플 드롭 목록";
        internal const string HUNTER_SAMPLE_TIERS_DEFAULT = "Hoarding Bug, Centipede, Spore Lizard-Bunker Spider, Baboon hawk, Tulip Snake, Kidnapper Fox-Flowerman, MouthDog, Crawler, Manticoil, Maneater-Forest Giant";
        internal const string HUNTER_SAMPLE_TIERS_DESCRIPTION = "헌터 업그레이드의 어느 티어부터 각 샘플이 드롭되는지 지정합니다. 각 티어는 대시('-')로 구분하고, 몬스터 목록은 쉼표(',')로 구분합니다.\n" +
                                                                "지원 적: Hoarding Bug, Centipede (Snare Flea), Bunker Spider, Baboon Hawk, Crawler (Half/Thumper), " +
                                                                "Flowerman (Bracken), MouthDog (Eyeless Dog), Forest Giant, Tulip Snake, Manticoil, Kidnapper Fox, Spore Lizard.";

        internal const string MINIMUM_SAMPLE_VALUE_FORMAT = "Minimum scrap value of a {0} sample";
        internal const string MAXIMUM_SAMPLE_VALUE_FORMAT = "Maximum scrap value of a {0} sample";

        #region Snare Flea

        internal static readonly string SNARE_FLEA_SAMPLE_MINIMUM_VALUE_KEY = string.Format(MINIMUM_SAMPLE_VALUE_FORMAT, "Snare Flea");
        internal const int SNARE_FLEA_SAMPLE_MINIMUM_VALUE_DEFAULT = 35;

        internal static readonly string SNARE_FLEA_SAMPLE_MAXIMUM_VALUE_KEY = string.Format(MAXIMUM_SAMPLE_VALUE_FORMAT, "Snare Flea");
        internal const int SNARE_FLEA_SAMPLE_MAXIMUM_VALUE_DEFAULT = 60;

        #endregion

        #region Bunker Spider

        internal static readonly string BUNKER_SPIDER_SAMPLE_MINIMUM_VALUE_KEY = string.Format(MINIMUM_SAMPLE_VALUE_FORMAT, "Bunker Spider");
        internal const int BUNKER_SPIDER_SAMPLE_MINIMUM_VALUE_DEFAULT = 65;

        internal static readonly string BUNKER_SPIDER_SAMPLE_MAXIMUM_VALUE_KEY = string.Format(MAXIMUM_SAMPLE_VALUE_FORMAT, "Bunker Spider");
        internal const int BUNKER_SPIDER_SAMPLE_MAXIMUM_VALUE_DEFAULT = 95;

        #endregion

        #region Hoarding Bug

        internal static readonly string HOARDING_BUG_SAMPLE_MINIMUM_VALUE_KEY = string.Format(MINIMUM_SAMPLE_VALUE_FORMAT, "Hoarding Bug");
        internal const int HOARDING_BUG_SAMPLE_MINIMUM_VALUE_DEFAULT = 45;

        internal static readonly string HOARDING_BUG_SAMPLE_MAXIMUM_VALUE_KEY = string.Format(MAXIMUM_SAMPLE_VALUE_FORMAT, "Hoarding Bug");
        internal const int HOARDING_BUG_SAMPLE_MAXIMUM_VALUE_DEFAULT = 75;

        #endregion

        #region Bracken

        internal static readonly string BRACKEN_SAMPLE_MINIMUM_VALUE_KEY = string.Format(MINIMUM_SAMPLE_VALUE_FORMAT, "Bracken");
        internal const int BRACKEN_SAMPLE_MINIMUM_VALUE_DEFAULT = 80;

        internal static readonly string BRACKEN_SAMPLE_MAXIMUM_VALUE_KEY = string.Format(MAXIMUM_SAMPLE_VALUE_FORMAT, "Bracken");
        internal const int BRACKEN_SAMPLE_MAXIMUM_VALUE_DEFAULT = 125;

        #endregion

        #region Eyeless Dog

        internal static readonly string EYELESS_DOG_SAMPLE_MINIMUM_VALUE_KEY = string.Format(MINIMUM_SAMPLE_VALUE_FORMAT, "Eyeless Dog");
        internal const int EYELESS_DOG_SAMPLE_MINIMUM_VALUE_DEFAULT = 100;

        internal static readonly string EYELESS_DOG_SAMPLE_MAXIMUM_VALUE_KEY = string.Format(MAXIMUM_SAMPLE_VALUE_FORMAT, "Eyeless Dog");
        internal const int EYELESS_DOG_SAMPLE_MAXIMUM_VALUE_DEFAULT = 150;

        #endregion

        #region Baboon Hawk

        internal static readonly string BABOON_HAWK_SAMPLE_MINIMUM_VALUE_KEY = string.Format(MINIMUM_SAMPLE_VALUE_FORMAT, "Baboon Hawk");
        internal const int BABOON_HAWK_SAMPLE_MINIMUM_VALUE_DEFAULT = 75;

        internal static readonly string BABOON_HAWK_SAMPLE_MAXIMUM_VALUE_KEY = string.Format(MAXIMUM_SAMPLE_VALUE_FORMAT, "Baboon Hawk");
        internal const int BABOON_HAWK_SAMPLE_MAXIMUM_VALUE_DEFAULT = 115;

        #endregion

        #region Half

        internal static readonly string THUMPER_SAMPLE_MINIMUM_VALUE_KEY = string.Format(MINIMUM_SAMPLE_VALUE_FORMAT, "Half");
        internal const int THUMPER_SAMPLE_MINIMUM_VALUE_DEFAULT = 80;

        internal static readonly string THUMPER_SAMPLE_MAXIMUM_VALUE_KEY = string.Format(MAXIMUM_SAMPLE_VALUE_FORMAT, "Half");
        internal const int THUMPER_SAMPLE_MAXIMUM_VALUE_DEFAULT = 125;

        #endregion

        #region Forest Giant

        internal static readonly string FOREST_KEEPER_SAMPLE_MINIMUM_VALUE_KEY = string.Format(MINIMUM_SAMPLE_VALUE_FORMAT, "Forest Keeper");
        internal const int FOREST_KEEPER_SAMPLE_MINIMUM_VALUE_DEFAULT = 80;

        internal static readonly string FOREST_KEEPER_SAMPLE_MAXIMUM_VALUE_KEY = string.Format(MAXIMUM_SAMPLE_VALUE_FORMAT, "Forest Keeper");
        internal const int FOREST_KEEPER_SAMPLE_MAXIMUM_VALUE_DEFAULT = 125;

        #endregion

        #region Manticoil

        internal static readonly string MANTICOIL_SAMPLE_MINIMUM_VALUE_KEY = string.Format(MINIMUM_SAMPLE_VALUE_FORMAT, "Manticoil");
        internal const int MANTICOIL_SAMPLE_MINIMUM_VALUE_DEFAULT = 40;

        internal static readonly string MANTICOIL_SAMPLE_MAXIMUM_VALUE_KEY = string.Format(MAXIMUM_SAMPLE_VALUE_FORMAT, "Manticoil");
        internal const int MANTICOIL_SAMPLE_MAXIMUM_VALUE_DEFAULT = 75;

        #endregion

        #region Tulip Snake

        internal static readonly string TULIP_SNAKE_SAMPLE_MINIMUM_VALUE_KEY = string.Format(MINIMUM_SAMPLE_VALUE_FORMAT, "Tulip Snake");
        internal const int TULIP_SNAKE_SAMPLE_MINIMUM_VALUE_DEFAULT = 30;

        internal static readonly string TULIP_SNAKE_SAMPLE_MAXIMUM_VALUE_KEY = string.Format(MAXIMUM_SAMPLE_VALUE_FORMAT, "Tulip Snake");
        internal const int TULIP_SNAKE_SAMPLE_MAXIMUM_VALUE_DEFAULT = 50;

        #endregion

        #region Kidnapper Fox

        internal static readonly string KIDNAPPER_FOX_SAMPLE_MINIMUM_VALUE_KEY = string.Format(MINIMUM_SAMPLE_VALUE_FORMAT, "Kidnapper Fox");
        internal const int KIDNAPPER_FOX_SAMPLE_MINIMUM_VALUE_DEFAULT = 60;

        internal static readonly string KIDNAPPER_FOX_SAMPLE_MAXIMUM_VALUE_KEY = string.Format(MAXIMUM_SAMPLE_VALUE_FORMAT, "Kidnapper Fox");
        internal const int KIDNAPPER_FOX_SAMPLE_MAXIMUM_VALUE_DEFAULT = 80;

        #endregion

        #region Spore Lizard

        internal static readonly string SPORE_LIZARD_SAMPLE_MINIMUM_VALUE_KEY = string.Format(MINIMUM_SAMPLE_VALUE_FORMAT, "Spore Lizard");
        internal const int SPORE_LIZARD_SAMPLE_MINIMUM_VALUE_DEFAULT = 30;

        internal static readonly string SPORE_LIZARD_SAMPLE_MAXIMUM_VALUE_KEY = string.Format(MAXIMUM_SAMPLE_VALUE_FORMAT, "Spore Lizard");
        internal const int SPORE_LIZARD_SAMPLE_MAXIMUM_VALUE_DEFAULT = 50;

        #endregion

        #region Maneater

        internal static readonly string MANEATER_SAMPLE_MINIMUM_VALUE_KEY = string.Format(MINIMUM_SAMPLE_VALUE_FORMAT, "Maneater");
        internal const int MANEATER_SAMPLE_MINIMUM_VALUE_DEFAULT = 80;

        internal static readonly string MANEATER_SAMPLE_MAXIMUM_VALUE_KEY = string.Format(MAXIMUM_SAMPLE_VALUE_FORMAT, "Maneater");
        internal const int MANEATER_SAMPLE_MAXIMUM_VALUE_DEFAULT = 120;

		#endregion

		#region Giant Sapsucker

		internal static readonly string GIANT_SAPSUCKER_SAMPLE_MINIMUM_VALUE_KEY = string.Format(MINIMUM_SAMPLE_VALUE_FORMAT, "Giant Sapsucker");
		internal const int GIANT_SAPSUCKER_SAMPLE_MINIMUM_VALUE_DEFAULT = 110;

		internal static readonly string GIANT_SAPSUCKER_SAMPLE_MAXIMUM_VALUE_KEY = string.Format(MAXIMUM_SAMPLE_VALUE_FORMAT, "Giant Sapsucker");
		internal const int GIANT_SAPSUCKER_SAMPLE_MAXIMUM_VALUE_DEFAULT = 160;

		#endregion

		#endregion

		#region Night Vision

		internal const string NIGHT_VISION_ENABLED_KEY = $"{NightVision.SIMPLE_UPGRADE_NAME} 업그레이드 활성화";
        internal const bool NIGHT_VISION_ENABLED_DEFAULT = true;
        internal const string NIGHT_VISION_ENABLED_DESCRIPTION = "켜고 끌 수 있는 야간 투시 장비입니다.";

        internal const string NIGHT_VISION_PRICE_KEY = $"{NightVision.SIMPLE_UPGRADE_NAME} 업그레이드 가격";
        internal const int NIGHT_VISION_PRICE_DEFAULT = 380;

        internal const string NIGHT_VISION_BATTERY_MAX_KEY = $"{NightVision.SIMPLE_UPGRADE_NAME} 배터리 최대 용량";
        internal const float NIGHT_VISION_BATTERY_MAX_DEFAULT = 10f;
        internal const string NIGHT_VISION_BATTERY_MAX_DESCRIPTION = "기본 설정에서 업그레이드 전 배터리 소모 및 충전 시간(초)입니다. 값을 높이면 배터리 수명이 늘어납니다.";

        internal const string NIGHT_VISION_DRAIN_SPEED_KEY = "야간 투시 배터리 소모 배율";
        internal const float NIGHT_VISION_DRAIN_SPEED_DEFAULT = 1f;
        internal const string NIGHT_VISION_DRAIN_SPEED_DESCRIPTION = "시간 변화량에 곱해집니다. 낮출수록 배터리 수명이 늘어납니다.";

        internal const string NIGHT_VISION_REGEN_SPEED_KEY = "야간 투시 배터리 충전 배율";
        internal const float NIGHT_VISION_REGEN_SPEED_DEFAULT = 1f;
        internal const string NIGHT_VISION_REGEN_SPEED_DESCRIPTION = "시간 변화량에 곱해집니다. 높일수록 배터리 충전 속도가 빨라집니다.";

        internal const string NIGHT_VISION_COLOR_KEY = $"{NightVision.SIMPLE_UPGRADE_NAME} 색상";
        internal const string NIGHT_VISION_COLOR_DEFAULT = HEXADECIMAL_GREEN + "FF";
        internal const string NIGHT_VISION_COLOR_DESCRIPTION = $"{NightVision.SIMPLE_UPGRADE_NAME} 조명이 방출하는 색상입니다.";

        internal const string NIGHT_VISION_UI_TEXT_COLOR_KEY = $"{NightVision.SIMPLE_UPGRADE_NAME} UI 텍스트 색상";
        internal const string NIGHT_VISION_UI_TEXT_COLOR_DEFAULT = HEXADECIMAL_WHITE + "FF";
        internal const string NIGHT_VISION_UI_TEXT_COLOR_DESCRIPTION = $"{NightVision.SIMPLE_UPGRADE_NAME} UI 텍스트에 사용되는 색상입니다.";

        internal const string NIGHT_VISION_UI_BAR_COLOR_KEY = $"{NightVision.SIMPLE_UPGRADE_NAME} UI 바 색상";
        internal const string NIGHT_VISION_UI_BAR_COLOR_DEFAULT = HEXADECIMAL_GREEN + "FF";
        internal const string NIGHT_VISION_UI_BAR_COLOR_DESCRIPTION = $"{NightVision.SIMPLE_UPGRADE_NAME} UI 배터리 바에 사용되는 색상입니다.";

        internal const string NIGHT_VISION_RANGE_KEY = $"{NightVision.SIMPLE_UPGRADE_NAME} 범위";
        internal const float NIGHT_VISION_RANGE_DEFAULT = 2000f;
        internal const string NIGHT_VISION_RANGE_DESCRIPTION = $"{NightVision.SIMPLE_UPGRADE_NAME}의 빛이 도달하는 거리와 유사한 개념입니다.";

        internal const string NIGHT_VISION_RANGE_INCREMENT_KEY = $"{NightVision.SIMPLE_UPGRADE_NAME} 범위 증가량";
        internal const float NIGHT_VISION_RANGE_INCREMENT_DEFAULT = 0f;
        internal const string NIGHT_VISION_RANGE_INCREMENT_DESCRIPTION = "업그레이드마다 범위에 이 값만큼 추가됩니다.";

        internal const string NIGHT_VISION_INTENSITY_KEY = $"{NightVision.SIMPLE_UPGRADE_NAME} 밝기";
        internal const float NIGHT_VISION_INTENSITY_DEFAULT = 1000f;
        internal const string NIGHT_VISION_INTENSITY_DESCRIPTION = $"{NightVision.SIMPLE_UPGRADE_NAME}의 밝기와 유사한 개념입니다.";

        internal const string NIGHT_VISION_INTENSITY_INCREMENT_KEY = $"{NightVision.SIMPLE_UPGRADE_NAME} 밝기 증가량";
        internal const float NIGHT_VISION_INTENSITY_INCREMENT_DEFAULT = 0f;
        internal const string NIGHT_VISION_INTENSITY_INCREMENT_DESCRIPTION = "업그레이드마다 밝기에 이 값만큼 추가됩니다.";

        internal const string NIGHT_VISION_STARTUP_KEY = $"{NightVision.SIMPLE_UPGRADE_NAME} 초기 소모 비용";
        internal const float NIGHT_VISION_STARTUP_DEFAULT = 0.1f;
        internal const string NIGHT_VISION_STARTUP_DESCRIPTION = "켤 때 소모되는 배터리 비율입니다. (0.1 = 10%)";

        internal const string NIGHT_VISION_EXHAUST_KEY = $"{NightVision.SIMPLE_UPGRADE_NAME} 방전 지속 시간";
        internal const float NIGHT_VISION_EXHAUST_DEFAULT = 2f;
        internal const string NIGHT_VISION_EXHAUST_DESCRIPTION = $"{NightVision.SIMPLE_UPGRADE_NAME}가 완전히 방전된 후 유지되는 시간(초)입니다.";

        internal const string NIGHT_VISION_DRAIN_INCREMENT_KEY = $"{NightVision.SIMPLE_UPGRADE_NAME} 배터리 소모 감소량";
        internal const float NIGHT_VISION_DRAIN_INCREMENT_DEFAULT = 0.15f;
        internal const string NIGHT_VISION_DRAIN_INCREMENT_DESCRIPTION = "업그레이드마다 소모 속도에 적용됩니다.";

        internal const string NIGHT_VISION_REGEN_INCREMENT_KEY = $"{NightVision.SIMPLE_UPGRADE_NAME} 배터리 충전 증가량";
        internal const float NIGHT_VISION_REGEN_INCREMENT_DEFAULT = 0.40f;
        internal const string NIGHT_VISION_REGEN_INCREMENT_DESCRIPTION = "업그레이드마다 충전 속도에 적용됩니다.";

        internal const string NIGHT_VISION_BATTERY_INCREMENT_KEY = $"{NightVision.SIMPLE_UPGRADE_NAME} 배터리 수명 증가량";
        internal const float NIGHT_VISION_BATTERY_INCREMENT_DEFAULT = 2f;
        internal const string NIGHT_VISION_BATTERY_INCREMENT_DESCRIPTION = $"업그레이드마다 {NightVision.SIMPLE_UPGRADE_NAME} 배터리 최대 충전량에 적용됩니다.";

        internal const string LOSE_NIGHT_VISION_ON_DEATH_KEY = $"사망 시 {NightVision.SIMPLE_UPGRADE_NAME} 분실";
        internal const bool LOSE_NIGHT_VISION_ON_DEATH_DEFAULT = true;
        internal const string LOSE_NIGHT_VISION_ON_DEATH_DESCRIPTION = $"true이면 사망 시 {NightVision.SIMPLE_UPGRADE_NAME}가 비활성화되며, 새 고글이 필요하게 됩니다.";

        internal const string NIGHT_VISION_DROP_ON_DEATH_KEY = $"사망 시 {NightVisionGoggles.ITEM_NAME} 드롭";
        internal const bool NIGHT_VISION_DROP_ON_DEATH_DEFAULT = true;
        internal const string NIGHT_VISION_DROP_ON_DEATH_DESCRIPTION = $"true이면, 사망 후 {NightVision.SIMPLE_UPGRADE_NAME}를 잃게 될 때 시신 위에 {NightVisionGoggles.ITEM_NAME}를 떨어뜨립니다.";
        #endregion

        #region Mechanical Arms

        internal const string MECHANICAL_ARMS_ENABLED_KEY = $"{MechanicalArms.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool MECHANICAL_ARMS_ENABLED_DEFAULT = true;
        internal const string MECHANICAL_ARMS_ENABLED_DESCRIPTION = "물체 잡기, 문 열고 닫기 등 오브젝트와의 상호작용 범위를 늘려주는 티어 업그레이드입니다.";

        internal const string MECHANICAL_ARMS_PRICE_KEY = $"{MechanicalArms.UPGRADE_NAME} 업그레이드 가격";
        internal const int MECHANICAL_ARMS_PRICE_DEFAULT = 300;

        internal const string MECHANICAL_ARMS_INITIAL_RANGE_INCREASE_KEY = "초기 범위 증가";
        internal const float MECHANICAL_ARMS_INITIAL_RANGE_INCREASE_DEFAULT = 1f;
        internal const string MECHANICAL_ARMS_INITIAL_RANGE_INCREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 증가하는 상호작용 범위(Unity 단위)";

        internal const string MECHANICAL_ARMS_INCREMENTAL_RANGE_INCREASE_KEY = "점진적 범위 증가";
        internal const float MECHANICAL_ARMS_INCREMENTAL_RANGE_INCREASE_DEFAULT = 1f;
        internal const string MECHANICAL_ARMS_INCREMENTAL_RANGE_INCREASE_DESCRIPTION = "추가 업그레이드 구매 시 증가하는 상호작용 범위(Unity 단위)";

        #endregion

        #region Scavenger Instincts

        internal const string SCAVENGER_INSTINCTS_ENABLED_KEY = $"{ScavengerInstincts.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool SCAVENGER_INSTINCTS_ENABLED_DEFAULT = true;
        internal const string SCAVENGER_INSTINCTS_ENABLED_DESCRIPTION = "주어진 레벨에서 스폰될 수 있는 스크랩의 양을 증가시키는 티어 업그레이드입니다.";

        internal const string SCAVENGER_INSTINCTS_PRICE_KEY = $"{ScavengerInstincts.UPGRADE_NAME} 업그레이드 가격";
        internal const int SCAVENGER_INSTINCTS_PRICE_DEFAULT = 800;

        internal const string SCAVENGER_INSTINCTS_INITIAL_AMOUNT_SCRAP_INCREASE_KEY = "초기 스크랩 스폰 증가량";
        internal const int SCAVENGER_INSTINCTS_INITIAL_AMOUNT_SCRAP_INCREASE_DEFAULT = 4;
        internal const string SCAVENGER_INSTINCTS_INITIAL_AMOUNT_SCRAP_INCREASE_DESCRIPTION = "처음 구매 시 해당 레벨에서 추가로 스폰될 수 있는 스크랩 수량";

        internal const string SCAVENGER_INSTINCTS_INCREMENTAL_AMOUNT_SCRAP_INCREASE_KEY = "점진적 스크랩 스폰 증가량";
        internal const int SCAVENGER_INSTINCTS_INCREMENTAL_AMOUNT_SCRAP_INCREASE_DEFAULT = 2;
        internal const string SCAVENGER_INSTINCTS_INCREMENTAL_AMOUNT_SCRAP_INCREASE_DESCRIPTION = "추가 업그레이드 구매 시 해당 레벨에서 추가로 스폰될 수 있는 스크랩 수량";

        #endregion

        #region Landing Thrusters

        internal const string LANDING_THRUSTERS_ENABLED_KEY = $"{LandingThrusters.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool LANDING_THRUSTERS_ENABLED_DEFAULT = true;
        internal const string LANDING_THRUSTERS_ENABLED_DESCRIPTION = "위성 간 이동 시 함선의 착륙 및 출발 속도를 증가시키는 티어 업그레이드입니다.";

        internal const string LANDING_THURSTERS_PRICE_KEY = $"{LandingThrusters.UPGRADE_NAME} 업그레이드 가격";
        internal const int LANDING_THRUSTERS_PRICE_DEFAULT = 300;

        internal const string LANDING_THRUSTERS_INITIAL_SPEED_INCREASE_KEY = "초기 속도 증가";
        internal const int LANDING_THRUSTERS_INITIAL_SPEED_INCREASE_DEFAULT = 25;
        internal const string LANDING_THRUSTERS_INITIAL_SPEED_INCREASE_DESCRIPTION = "업그레이드를 처음 구매할 때 함선 속도에 추가되는 초기 증가량(%)";

        internal const string LANDING_THRUSTERS_INCREMENTAL_SPEED_INCREASE_KEY = "점진적 속도 증가";
        internal const int LANDING_THRUSTERS_INCREMENTAL_SPEED_INCREASE_DEFAULT = 25;
        internal const string LANDING_THRUSTERS_INCREMENTAL_SPEED_INCREASE_DESCRIPTION = "추가 업그레이드 구매 시 함선 속도에 추가되는 점진적 증가량(%)";

        internal const string LANDING_THRUSTERS_AFFECT_LANDING_KEY = "착륙 시퀀스 속도에 영향";
        internal const bool LANDING_THRUSTERS_AFFECT_LANDING_DEFAULT = true;
        internal const string LANDING_THRUSTERS_AFFECT_LANDING_DESCRIPTION = "true이면 위성 착륙 시 함선 속도에 효과가 적용됩니다.";

        internal const string LANDING_THRUSTERS_AFFECT_DEPARTING_KEY = "출발 시퀀스 속도에 영향";
        internal const bool LANDING_THRUSTERS_AFFECT_DEPARTING_DEFAULT = true;
        internal const string LANDING_THRUSTERS_AFFECT_DEPARTING_DESCRIPTION = "true이면 위성 출발 시 함선 속도에 효과가 적용됩니다.";

        #endregion

        #region Reinforced Boots

        internal const string REINFORCED_BOOTS_ENABLED_KEY = $"{ReinforcedBoots.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool REINFORCED_BOOTS_ENABLED_DEFAULT = true;
        internal const string REINFORCED_BOOTS_ENABLED_DESCRIPTION = "높은 곳에서 떨어질 때 받는 데미지를 줄여주는 티어 업그레이드입니다.";

        internal const string REINFORCED_BOOTS_PRICE_KEY = $"{ReinforcedBoots.UPGRADE_NAME} 업그레이드 가격";
        internal const int REINFORCED_BOOTS_PRICE_DEFAULT = 250;

        internal const string REINFORCED_BOOTS_INITIAL_DAMAGE_REDUCTION_KEY = "초기 데미지 감소";
        internal const int REINFORCED_BOOTS_INITIAL_DAMAGE_REDUCTION_DEFAULT = 25;
        internal const string REINFORCED_BOOTS_INITIAL_DAMAGE_REDUCTION_DESCRIPTION = "업그레이드를 처음 구매할 때 높은 곳에서 낙하 시 받는 데미지 감소율(%)";

        internal const string REINFORCED_BOOTS_INCREMENTAL_DAMAGE_REDUCTION_KEY = "점진적 데미지 감소";
        internal const int REINFORCED_BOOTS_INCREMENTAL_DAMAGE_REDUCTION_DEFAULT = 10;
        internal const string REINFORCED_BOOTS_INCREMENTAL_DAMAGE_REDUCTION_DESCRIPTION = "추가 업그레이드 구매 시 높은 곳에서 낙하 시 받는 데미지 감소율(%)";

        #endregion

        #region Deeper Pockets

        internal const string DEEPER_POCKETS_ENABLED_KEY = $"{DeepPockets.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool DEEPER_POCKETS_ENABLED_DEFAULT = true;
        internal const string DEEPER_POCKETS_ENABLED_DESCRIPTION = "인벤토리에 두 손 아이템을 하나 이상 보관할 수 있게 해주는 티어 업그레이드입니다.";

        internal const string DEEPER_POCKETS_PRICE_KEY = $"{DeepPockets.UPGRADE_NAME} 업그레이드 가격";
        internal const int DEEPER_POCKETS_PRICE_DEFAULT = 500;

        internal const string DEEPER_POCKETS_INITIAL_TWO_HANDED_AMOUNT_KEY = "초기 운반 용량 증가";
        internal const int DEEPER_POCKETS_INITIAL_TWO_HANDED_AMOUNT_DEFAULT = 1;
        internal const string DEEPER_POCKETS_INITIAL_TWO_HANDED_AMOUNT_DESCRIPTION = "업그레이드를 처음 구매할 때 플레이어의 두 손 운반 용량 증가량";

        internal const string DEEPER_POCKETS_INCREMENTAL_TWO_HANDED_AMOUNT_KEY = "점진적 운반 용량 증가";
        internal const int DEEPER_POCKETS_INCREMENTAL_TWO_HANDED_AMOUNT_DEFAULT = 1;
        internal const string DEEPER_POCKETS_INCREMENTAL_TWO_HANDED_AMOUNT_DESCRIPTION = "업그레이드 레벨 증가 시 플레이어의 두 손 운반 용량 증가량";

        internal const string DEEPER_POCKETS_ALLOW_WHEELBARROWS_KEY = "손수레를 깊은 주머니에 수납 허용";
        internal const bool DEEPER_POCKETS_ALLOW_WHEELBARROWS_DEFAULT = true;
        internal const string DEEPER_POCKETS_ALLOW_WHEELBARROWS_DESCRIPTION = "손수레와 쇼핑 카트를 깊은 주머니에 수납할 수 있는지 여부";

        #endregion 

        #region Aluminium Coils

        internal const string ALUMINIUM_COILS_ENABLED_KEY = $"{AluminiumCoils.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool ALUMINIUM_COILS_ENABLED_DEFAULT = true;
        internal const string ALUMINIUM_COILS_ENABLED_DESCRIPTION = "전기 충격건 미니게임의 난이도를 낮춰 더 쉽게 다룰 수 있게 해주는 티어 업그레이드입니다.";

        internal const string ALUMINIUM_COILS_PRICE_KEY = $"{AluminiumCoils.UPGRADE_NAME} 업그레이드 가격";
        internal const int ALUMINIUM_COILS_PRICE_DEFAULT = 750;

        internal const string ALUMINIUM_COILS_INITIAL_DIFFICULTY_MULTIPLIER_KEY = "미니게임 난이도 배율에 적용되는 초기 배율(%)";
        internal const int ALUMINIUM_COILS_INITIAL_DIFFICULTY_MULTIPLIER_DEFAULT = 25;
        internal const string ALUMINIUM_COILS_INITIAL_DIFFICULTY_MULTIPLIER_DESCRIPTION = "100%를 초과하면 전기 충격건 미니게임 추적에 어려움이 없어집니다.";

        internal const string ALUMINIUM_COILS_INCREMENTAL_DIFFICULTY_MULTIPLIER_KEY = "미니게임 난이도 배율에 적용되는 점진적 배율(%)";
        internal const int ALUMINIUM_COILS_INCREMENTAL_DIFFICULTY_MULTIPLIER_DEFAULT = 10;
        internal const string ALUMINIUM_COILS_INCREMENTAL_DIFFICULTY_MULTIPLIER_DESCRIPTION = ALUMINIUM_COILS_INITIAL_DIFFICULTY_MULTIPLIER_DESCRIPTION;

        internal const string ALUMINIUM_COILS_INITIAL_STUN_TIMER_KEY = "전기 충격건 사용 시 적 기절 타이머에 추가되는 초기값";
        internal const float ALUMINIUM_COILS_INITIAL_STUN_TIMER_DEFAULT = 1f;

        internal const string ALUMINIUM_COILS_INCREMENTAL_STUN_TIMER_KEY = "전기 충격건 사용 시 적 기절 타이머에 추가되는 점진적 값";
        internal const float ALUMINIUM_COILS_INCREMENTAL_STUN_TIMER_DEFAULT = 1f;

        internal const string ALUMINIUM_COILS_INITIAL_RANGE_KEY = "적을 기절시키는 전기 충격건 사거리에 추가되는 초기값";
        internal const float ALUMINIUM_COILS_INITIAL_RANGE_DEFAULT = 2f;

        internal const string ALUMINIUM_COILS_INCREMENTAL_RANGE_KEY = "적을 기절시키는 전기 충격건 사거리에 추가되는 점진적 값";
        internal const float ALUMINIUM_COILS_INCREMENTAL_RANGE_DEFAULT = 1f;

        internal const string ALUMINIUM_COILS_INITIAL_COOLDOWN_KEY = "전기 충격건 쿨다운에 적용되는 초기 배율(%)";
        internal const int ALUMINIUM_COILS_INITIAL_COOLDOWN_DEFAULT = 10;
        internal const string ALUMINIUM_COILS_INITIAL_COOLDOWN_DESCRIPTION = "100%를 초과하면 전기 충격건 사용 후 쿨다운이 없어집니다.";

        internal const string ALUMINIUM_COILS_INCREMENTAL_COOLDOWN_KEY = "전기 충격건 쿨다운에 적용되는 점진적 배율";
        internal const int ALUMINIUM_COILS_INCREMENTAL_COOLDOWN_DEFAULT = 10;
        internal const string ALUMINIUM_COILS_INCREMENTAL_COOLDOWN_DESCRIPTION = ALUMINIUM_COILS_INITIAL_COOLDOWN_DESCRIPTION;

        #endregion

        #region Back Muscles

        internal const string BACK_MUSCLES_ENABLED_KEY = $"{BackMuscles.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool BACK_MUSCLES_ENABLED_DEFAULT = true;
        internal const string BACK_MUSCLES_ENABLED_DESCRIPTION = "운반 무게를 줄여줍니다.";

        internal const string BACK_MUSCLES_PRICE_KEY = $"{BackMuscles.UPGRADE_NAME} 업그레이드 가격";
        internal const int BACK_MUSCLES_PRICE_DEFAULT = 715;

        internal const string BACK_MUSCLES_INITIAL_WEIGHT_MULTIPLIER_KEY = "운반 무게 배율";
        internal const float BACK_MUSCLES_INITIAL_WEIGHT_MULTIPLIER_DEFAULT = 0.5f;
        internal const string BACK_MUSCLES_INITIAL_WEIGHT_MULTIPLIER_DESCRIPTION = "운반 무게에 이 값이 곱해집니다.";

        internal const string BACK_MUSCLES_INCREMENTAL_WEIGHT_MULTIPLIER_KEY = "운반 무게 감소 증가량";
        internal const float BACK_MUSCLES_INCREMENTAL_WEIGHT_MULTIPLIER_DEFAULT = 0.1f;
        internal const string BACK_MUSCLES_INCREMENTAL_WEIGHT_MULTIPLIER_DESCRIPTION = "업그레이드마다 위의 계수에서 이 값이 차감됩니다.";

        internal const string BACK_MUSCLES_UPGRADE_MODE_KEY = $"{BackMuscles.UPGRADE_NAME} 업그레이드 모드";
        internal const BackMuscles.UpgradeMode BACK_MUSCLES_UPGRADE_MODE_DEFAULT = BackMuscles.UpgradeMode.ReduceWeight;
        internal const string BACK_MUSCLES_UPGRADE_MODE_DESCRIPTION = "업그레이드 구매 시 적용되는 모드:\n" +
            "ReduceWeight (아이템을 집을 때 전체 무게 감소), " +
            "ReduceCarryInfluence (달리기 시 운반 무게 영향 감소), " +
            "ReduceStrain (달리기 중 스태미나 소모에 대한 운반 무게 영향 감소),";

        #endregion

        #region Bargain Connections

        internal const string BARGAIN_CONNECTIONS_ENABLED_KEY = $"{BargainConnections.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool BARGAIN_CONNECTIONS_ENABLED_DEFAULT = true;
        internal const string BARGAIN_CONNECTIONS_ENABLED_DESCRIPTION = "상점에서 할인될 수 있는 아이템 수를 증가시키는 티어 업그레이드입니다.";

        internal const string BARGAIN_CONNECTIONS_PRICE_KEY = $"{BargainConnections.UPGRADE_NAME} 가격";
        internal const int BARGAIN_CONNECTIONS_PRICE_DEFAULT = 200;

        internal const string BARGAIN_CONNECTIONS_INITIAL_AMOUNT_KEY = "할인 가능한 아이템 수 초기 추가량";
        internal const int BARGAIN_CONNECTIONS_INITIAL_AMOUNT_DEFAULT = 3;

        internal const string BARGAIN_CONNECTIONS_INCREMENTAL_AMOUNT_KEY = "할인 가능한 아이템 수 점진적 추가량";
        internal const int BARGAIN_CONNECTIONS_INCREMENTAL_AMOUNT_DEFAULT = 2;

        #endregion

        #region Beekeeper

        internal const string BEEKEEPER_ENABLED_KEY = $"{Beekeeper.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool BEEKEEPER_ENABLED_DEFAULT = true;
        internal const string BEEKEEPER_ENABLED_DESCRIPTION = "벌과 말벌로부터 받는 데미지를 줄여줍니다.";

        internal const string BEEKEEPER_PRICE_KEY = $"{Beekeeper.UPGRADE_NAME} 업그레이드 가격";
        internal const int BEEKEEPER_PRICE_DEFAULT = 450;

        internal const string BEEKEEPER_DAMAGE_MULTIPLIER_KEY = "받는 데미지에 곱해지는 배율(정수로 반올림)";
        internal const float BEEKEEPER_DAMAGE_MULTIPLIER_DEFAULT = 0.64f;
        internal const string BEEKEEPER_DAMAGE_MULTIPLIER_DESCRIPTION = "벌집에서 받는 벌 데미지는 10, 집사의 데미지는 40 (혼자일 경우 20)입니다.";

        internal const string BEEKEEPER_DAMAGE_INCREMENTAL_MULTIPLIER_KEY = "레벨당 추가 데미지 감소율(%)";
        internal const float BEEKEEPER_DAMAGE_INCREMENTAL_MULTIPLIER_DEFAULT = 0.15f;
        internal const string BEEKEEPER_DAMAGE_INCREMENTAL_MULTIPLIER_DESCRIPTION = $"{Beekeeper.UPGRADE_NAME}을 업그레이드할 때마다 위의 기본 배율에서 이 값이 차감됩니다.";

        internal const string BEEKEEPER_HIVE_MULTIPLIER_KEY = "벌집 가치 증가 배율";
        internal const float BEEKEEPER_HIVE_MULTIPLIER_DEFAULT = 1.5f;
        internal const string BEEKEEPER_HIVE_MULTIPLIER_DESCRIPTION = "최고 레벨 도달 시 벌집 가치에 적용되는 배율";

        #endregion

        #region Better Scanner

        internal const string BETTER_SCANNER_ENABLED_KEY = $"{BetterScanner.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool BETTER_SCANNER_ENABLED_DEFAULT = true;
        internal const string BETTER_SCANNER_ENABLED_DESCRIPTION = "스캔 거리 증가, 시야(LOS) 불필요.";

        internal const string BETTER_SCANNER_PRICE_KEY = $"{BetterScanner.UPGRADE_NAME} 업그레이드 가격";
        internal const int BETTER_SCANNER_PRICE_DEFAULT = 650;

        internal const string BETTER_SCANNER_OUTSIDE_NODE_DISTANCE_INCREASE_KEY = "함선 및 입구 노드 거리 증가";
        internal const float BETTER_SCANNER_OUTSIDE_NODE_DISTANCE_INCREASE_DEFAULT = 150f;
        internal const string BETTER_SCANNER_OUTSIDE_NODE_DISTANCE_INCREASE_DESCRIPTION = "함선과 입구를 스캔할 수 있는 추가 거리.";

        internal const string BETTER_SCANNER_NODE_DISTANCE_INCREASE_KEY = "노드 거리 증가";
        internal const float BETTER_SCANNER_NODE_DISTANCE_INCREASE_DEFAULT = 20f;
        internal const string BETTER_SCANNER_NODE_DISTANCE_INCREASE_DESCRIPTION = "다른 노드를 스캔할 수 있는 추가 거리.";

        internal const string BETTER_SCANNER_SECOND_TIER_PRICE_KEY = $"{BetterScanner.UPGRADE_NAME} 2단계 가격";
        internal const int BETTER_SCANNER_SECOND_TIER_PRICE_DEFAULT = 500;
        internal const string BETTER_SCANNER_SECOND_TIER_PRICE_DESCRIPTION = "이 티어에서 함선 스캔 명령어가 해금됩니다.";

        internal const string BETTER_SCANNER_THIRD_TIER_PRICE_KEY = $"{BetterScanner.UPGRADE_NAME} 3단계 가격";
        internal const int BETTER_SCANNER_THIRD_TIER_PRICE_DEFAULT = 800;
        internal const string BETTER_SCANNER_THIRD_TIER_PRICE_DESCRIPTION = "이 티어에서 벽 너머 스캔이 해금됩니다.";

        internal const string BETTER_SCANNER_ENEMIES_THROUGH_WALLS_KEY = "최종 업그레이드 시 벽 너머 적 스캔";
        internal const bool BETTER_SCANNER_ENEMIES_THROUGH_WALLS_DEFAULT = false;
        internal const string BETTER_SCANNER_ENEMIES_THROUGH_WALLS_DESCRIPTION = "true이면 최종 업그레이드 시 벽 너머 스크랩과 적 모두 스캔합니다.";

        internal const string BETTER_SCANNER_VERBOSE_ENEMIES_KEY = "`scan enemies` 명령어 상세 출력";
        internal const bool BETTER_SCANNER_VERBOSE_ENEMIES_DEFAULT = true;
        internal const string BETTER_SCANNER_VERBOSE_ENEMIES_DESCRIPTION = "false이면 `scan enemies`는 외부/내부 적 수만 반환하고, true이면 각 적 종류별 수를 반환합니다.";

        #endregion

        #region Bigger Lungs

        internal const string BIGGER_LUNGS_ENABLED_KEY = $"{BiggerLungs.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool BIGGER_LUNGS_ENABLED_DEFAULT = true;
        internal const string BIGGER_LUNGS_ENABLED_DESCRIPTION = "스태미나 증가.";

        internal const string BIGGER_LUNGS_PRICE_KEY = $"{BiggerLungs.UPGRADE_NAME} 업그레이드 가격";
        internal const int BIGGER_LUNGS_PRICE_DEFAULT = 600;

        internal const string BIGGER_LUNGS_INITIAL_SPRINT_TIME_KEY = "업그레이드 해금 시 달리기 시간";
        internal const float BIGGER_LUNGS_INITIAL_SPRINT_TIME_DEFAULT = 6f;
        internal const string BIGGER_LUNGS_INITIAL_SPRINT_TIME_DESCRIPTION = "업그레이드 해금 시 획득하는 달리기 시간입니다.\n기본(바닐라) 값은 11f입니다.";

        internal const string BIGGER_LUNGS_INCREMENTAL_SPRINT_TIME_KEY = "달리기 시간 증가량";
        internal const float BIGGER_LUNGS_INCREMENTAL_SPRINT_TIME_DEFAULT = 1.25f;
        internal const string BIGGER_LUNGS_INCREMENTAL_SPRINT_TIME_DESCRIPTION = "업그레이드 레벨 증가 시 획득하는 달리기 시간입니다.";

        internal const string BIGGER_LUNGS_STAMINA_APPLY_LEVEL_KEY = $"스태미나 회복 적용이 시작되는 {BiggerLungs.UPGRADE_NAME} 레벨";
        internal const int BIGGER_LUNGS_STAMINA_APPLY_LEVEL_DEFAULT = 1;
        internal const string BIGGER_LUNGS_STAMINA_APPLY_LEVEL_DESCRIPTION = "해당 레벨에 도달하면 효과가 적용되기 시작합니다.";

        internal const string BIGGER_LUNGS_INITIAL_STAMINA_REGEN_KEY = "스태미나 회복 증가";
        internal const float BIGGER_LUNGS_INITIAL_STAMINA_REGEN_DEFAULT = 1.05f;
        internal const string BIGGER_LUNGS_INITIAL_STAMINA_REGEN_DESCRIPTION = "플레이어의 스태미나 회복 속도에 영향을 줍니다.";

        internal const string BIGGER_LUNGS_INCREMENTAL_STAMINA_REGEN_KEY = "점진적 스태미나 회복 증가";
        internal const float BIGGER_LUNGS_INCREMENTAL_STAMINA_REGEN_DEFAULT = 0.05f;
        internal const string BIGGER_LUNGS_INCREMENTAL_STAMINA_REGEN_DESCRIPTION = "초기 배율에 추가됩니다.";

        internal const string BIGGER_LUNGS_JUMP_STAMINA_DECREASE_APPLY_LEVEL_KEY = $"점프 시 스태미나 소모 감소가 적용되는 {BiggerLungs.UPGRADE_NAME} 레벨";
        internal const int BIGGER_LUNGS_JUMP_STAMINA_DECREASE_APPLY_LEVEL_DEFAULT = 2;
        internal const string BIGGER_LUNGS_JUMP_STAMINA_DECREASE_APPLY_LEVEL_DESCRIPTION = "해당 레벨에 도달하면 효과가 적용되기 시작합니다.";

        internal const string BIGGER_LUNGS_INITIAL_JUMP_STAMINA_DECREASE_KEY = "점프 시 스태미나 소모 감소";
        internal const float BIGGER_LUNGS_INITIAL_JUMP_STAMINA_DECREASE_DEFAULT = 0.90f;
        internal const string BIGGER_LUNGS_INITIAL_JUMP_STAMINA_DECREASE_DESCRIPTION = "기본(바닐라) 점프 소모 비용에 곱해집니다.";

        internal const string BIGGER_LUNGS_INCREMENTAL_JUMP_STAMINA_DECREASE_KEY = "점프 시 스태미나 소모 점진적 감소";
        internal const float BIGGER_LUNGS_INCREMENTAL_JUMP_STAMINA_DECREASE_DEFAULT = 0.05f;
        internal const string BIGGER_LUNGS_INCREMENTAL_JUMP_STAMINA_DECREASE_DESCRIPTION = "초기 배율에 추가됩니다. (즉, 인수를 줄임)";

        #endregion

        #region Charging Booster

        internal const string CHARGING_BOOSTER_ENABLED_KEY = $"{ChargingBooster.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool CHARGING_BOOSTER_ENABLED_DEFAULT = true;
        internal const string CHARGING_BOOSTER_ENABLED_DESCRIPTION = "레이더 부스터에서 아이템을 충전할 수 있게 해주는 티어 업그레이드입니다.";

        internal const string CHARGING_BOOSTER_PRICE_KEY = $"{ChargingBooster.UPGRADE_NAME} 업그레이드 가격";
        internal const int CHARGING_BOOSTER_PRICE_DEFAULT = 300;

        internal const string CHARGING_BOOSTER_PRICES_DEFAULT = "300,250,300,400";

        internal const string CHARGING_BOOSTER_COOLDOWN_KEY = "레이더 부스터 충전소 사용 시 쿨다운(초)";
        internal const float CHARGING_BOOSTER_COOLDOWN_DEFAULT = 90f;

        internal const string CHARGING_BOOSTER_INCREMENTAL_COOLDOWN_DECREASE_KEY = "업그레이드 레벨 증가 시 점진적 쿨다운 감소량";
        internal const float CHARGING_BOOSTER_INCREMENTAL_COOLDOWN_DECREASE_DEFAULT = 10f;

        internal const string CHARGING_BOOSTER_CHARGE_PERCENTAGE_KEY = "레이더 부스터 충전소 사용 시 보유 아이템에 추가되는 충전 비율(%)";
        internal const int CHARGING_BOOSTER_CHARGE_PERCENTAGE_DEFAULT = 50;

        #endregion

        #region Climbing Gloves

        internal const string CLIMBING_GLOVES_ENABLED_KEY = $"{ClimbingGloves.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool CLIMBING_GLOVES_ENABLED_DEFAULT = true;
        internal const string CLIMBING_GLOVES_ENABLED_DESCRIPTION = "사다리 오르는 속도를 증가시키는 티어 업그레이드입니다.";

        internal const string CLIMBING_GLOVES_PRICE_KEY = $"{ClimbingGloves.UPGRADE_NAME} 업그레이드 가격";
        internal const int CLIMBING_GLOVES_PRICE_DEFAULT = 150;

        internal const string CLIMBING_GLOVES_INITIAL_MULTIPLIER_KEY = "플레이어 등반 속도에 추가되는 초기값";
        internal const float CLIMBING_GLOVES_INITIAL_MULTIPLIER_DEFAULT = 1f;
        internal const string CLIMBING_GLOVES_INITIAL_MULTIPLIER_DESCRIPTION = "기본(바닐라) 등반 속도는 4 단위입니다.";

        internal const string CLIMBING_GLOVES_INCREMENTAL_MULTIPLIER_KEY = "플레이어 등반 속도에 추가되는 점진적 값";
        internal const float CLIMBING_GLOVES_INCREMENTAL_MULTIPLIER_DEFAULT = 0.5f;

        #endregion

        #region Discombobulator

        internal const string DISCOMBOBULATOR_ENABLED_KEY = $"{Discombobulator.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool DISCOMBOBULATOR_ENABLED_DEFAULT = true;
        internal const string DISCOMBOBULATOR_ENABLED_DESCRIPTION = "함선 주변의 적을 기절시킵니다.";

        internal const string DISCOMBOBULATOR_PRICE_KEY = $"{Discombobulator.UPGRADE_NAME} 업그레이드 가격";
        internal const int DISCOMBOBULATOR_PRICE_DEFAULT = 450;

        internal const string DISCOMBOBULATOR_COOLDOWN_KEY = $"{Discombobulator.UPGRADE_NAME} 쿨다운";
        internal const float DISCOMBOBULATOR_COOLDOWN_DEFAULT = 120f;

        internal const string DISCOMBOBULATOR_EFFECT_RADIUS_KEY = $"{Discombobulator.UPGRADE_NAME} 효과 범위";
        internal const float DISCOMBOBULATOR_EFFECT_RADIUS_DEFAULT = 40f;

        internal const string DISCOMBOBULATOR_STUN_DURATION_KEY = $"{Discombobulator.UPGRADE_NAME} 기절 지속 시간";
        internal const float DISCOMBOBULATOR_STUN_DURATION_DEFAULT = 7.5f;

        internal const string DISCOMBOBULATOR_NOTIFY_CHAT_KEY = "적 기절 지속 시간 로컬 채팅 알림";
        internal const bool DISCOMBOBULATOR_NOTIFY_CHAT_DEFAULT = true;

        internal const string DISCOMBOBULATOR_INCREMENTAL_STUN_TIME_KEY = $"{Discombobulator.UPGRADE_NAME} 증가량";
        internal const float DISCOMBOBULATOR_INCREMENTAL_STUN_TIME_DEFAULT = 1f;
        internal const string DISCOMBOBULATOR_INCREMENTAL_STUN_TIME_DESCRIPTION = "업그레이드 시 기절 지속 시간에 추가되는 값.";

        internal const string DISCOMBOBULATOR_APPLY_DAMAGE_LEVEL_KEY = "데미지 적용 시작 레벨";
        internal const int DISCOMBOBULATOR_APPLY_DAMAGE_LEVEL_DEFAULT = 2;
        internal const string DISCOMBOBULATOR_APPLY_DAMAGE_LEVEL_DESCRIPTION = $"기절시키는 적에게 데미지를 주기 시작하는 {Discombobulator.UPGRADE_NAME} 레벨";

        internal const string DISCOMBOBULATOR_INITIAL_DAMAGE_KEY = "초기 데미지량";
        internal const int DISCOMBOBULATOR_INITIAL_DAMAGE_DEFAULT = 2;
        internal const string DISCOMBOBULATOR_INITIAL_DAMAGE_DESCRIPTION = "기절 시 데미지가 적용되는 첫 레벨 도달 시 데미지량.\n참고: 눈 없는 개의 체력은 12입니다.";

        internal const string DISCOMBOBULATOR_INCREMENTAL_DAMAGE_KEY = "구매 시 데미지 증가";
        internal const int DISCOMBOBULATOR_INCREMENTAL_DAMAGE_DEFAULT = 1;
        internal const string DISCOMBOBULATOR_INCREMENTAL_DAMAGE_DESCRIPTION = "이후 레벨 구매 시 데미지 증가량";

        #endregion

        #region Drop Pod Thrusters

        internal const string DROP_POD_THRUSTERS_ENABLED_KEY = $"{FasterDropPod.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool DROP_POD_THRUSTERS_ENABLED_DEFAULT = true;
        internal const string DROP_POD_THRUSTERS_ENABLED_DESCRIPTION = "터미널에서 구매한 아이템을 배달하는 드롭 포드가 더 빠르게 착륙하게 합니다.";

        internal const string DROP_POD_THRUSTERS_PRICE_KEY = $"{FasterDropPod.UPGRADE_NAME} 가격";
        internal const int DROP_POD_THRUSTERS_PRICE_DEFAULT = 300;
        internal const string DROP_POD_THRUSTERS_PRICE_DESCRIPTION = $"업그레이드 기본 가격. 0으로 설정하면 구매 없이 {FasterDropPod.UPGRADE_NAME}를 활성화합니다.";

        internal const string DROP_POD_THRUSTERS_TIME_DECREASE_KEY = "이후 아이템 배달 타이머 감소량";
        internal const float DROP_POD_THRUSTERS_TIME_DECREASE_DEFAULT = 20f;

        internal const string DROP_POD_THRUSTERS_FIRST_TIME_DECREASE_KEY = "첫 아이템 배달 타이머 감소량";
        internal const float DROP_POD_THRUSTERS_FIRST_TIME_DECREASE_DEFAULT = 10f;

        internal const string DROP_POD_THRUSTERS_LEAVE_TIMER_KEY = "드롭 포드 퇴장 대기 시간";
        internal const float DROP_POD_THRUSTERS_LEAVE_TIMER_DEFAULT = 0f;
        internal const string DROP_POD_THRUSTERS_LEAVE_TIMER_DESCRIPTION = "아이템 드롭 포드가 열린 후 머무는 시간(초)";

        #endregion

        #region Efficient Engines

        internal const string EFFICIENT_ENGINES_ENABLED_KEY = $"{EfficientEngines.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool EFFICIENT_ENGINES_ENABLED_DEFAULT = true;
        internal const string EFFICIENT_ENGINES_ENABLED_DESCRIPTION = "저렴한 위성 이동을 위해 위성 경로 가격에 할인을 적용하는 티어 업그레이드입니다.";

        internal const string EFFICIENT_ENGINES_PRICE_KEY = $"{EfficientEngines.UPGRADE_NAME} 가격";
        internal const int EFFICIENT_ENGINES_PRICE_DEFAULT = 450;

        internal const string EFFICIENT_ENGINES_INITIAL_MULTIPLIER_KEY = "위성 이동에 적용되는 초기 할인율(%)";
        internal const int EFFICIENT_ENGINES_INITIAL_MULTIPLIER_DEFAULT = 15;

        internal const string EFFICIENT_ENGINES_INCREMENTAL_MULTIPLIER_KEY = "위성 이동에 적용되는 점진적 할인율(%)";
        internal const int EFFICIENT_ENGINES_INCREMENTAL_MULTIPLIER_DEFAULT = 5;

        #endregion

        #region Fast Encryption

        internal const string FAST_ENCRYPTION_ENABLED_KEY = $"{FastEncryption.UPGRADE_NAME} 활성화";
        internal const bool FAST_ENCRYPTION_ENABLED_DEFAULT = true;
        internal const string FAST_ENCRYPTION_ENABLED_DESCRIPTION = "송신기를 업그레이드합니다.";

        internal const string FAST_ENCRYPTION_PRICE_KEY = $"{FastEncryption.UPGRADE_NAME} 가격";
        internal const int FAST_ENCRYPTION_PRICE_DEFAULT = 300;

        #endregion

        #region Lethal Deals

        internal const string LETHAL_DEALS_ENABLED_KEY = $"{LethalDeals.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool LETHAL_DEALS_ENABLED_DEFAULT = true;
        internal const string LETHAL_DEALS_ENABLED_DESCRIPTION = "상점에서 적어도 하나의 아이템이 항상 할인되도록 보장하는 1회성 업그레이드입니다.";

        internal const string LETHAL_DEALS_PRICE_KEY = $"{LethalDeals.UPGRADE_NAME} 가격";
        internal const int LETHAL_DEALS_PRICE_DEFAULT = 300;

        #endregion

        #region Lithium Batteries

        internal const string LITHIUM_BATTERIES_ENABLED_KEY = $"{LithiumBatteries.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool LITHIUM_BATTERIES_ENABLED_DEFAULT = true;
        internal const string LITHIUM_BATTERIES_ENABLED_DESCRIPTION = "아이템 사용 시 배터리 소모 속도를 줄여주는 티어 업그레이드입니다.";

        internal const string LITHIUM_BATTERIES_PRICE_KEY = $"{LithiumBatteries.UPGRADE_NAME} 업그레이드 가격";
        internal const int LITHIUM_BATTERIES_PRICE_DEFAULT = 100;

        internal const string LITHIUM_BATTERIES_INITIAL_MULTIPLIER_KEY = "배터리 사용 속도에 적용되는 초기 배율(%)";
        internal const int LITHIUM_BATTERIES_INITIAL_MULTIPLIER_DEFAULT = 10;
        internal const string LITHIUM_BATTERIES_INITIAL_MULTIPLIER_DESCRIPTION = "100%를 초과하면 아이템의 배터리가 소모되지 않습니다.";

        internal const string LITHIUM_BATTERIES_INCREMENTAL_MULTIPLIER_KEY = "배터리 사용 속도에 적용되는 점진적 배율(%)";
        internal const int LITHIUM_BATTERIES_INCREMENTAL_MULTIPLIER_DEFAULT = 10;
        internal const string LITHIUM_BATTERIES_INCREMENTAL_MULTIPLIER_DESCRIPTION = LITHIUM_BATTERIES_INITIAL_MULTIPLIER_DESCRIPTION;

        #endregion

        #region Locksmith

        internal const string LOCKSMITH_ENABLED_KEY = $"{LockSmith.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool LOCKSMITH_ENABLED_DEFAULT = true;
        internal const string LOCKSMITH_ENABLED_DESCRIPTION = "미니게임을 완료하여 잠긴 문을 열 수 있게 해줍니다.";

        internal const string LOCKSMITH_PRICE_KEY = $"{LockSmith.UPGRADE_NAME} 가격";
        internal const int LOCKSMITH_PRICE_DEFAULT = 640;
        internal const string LOCKSMITH_PRICE_DESCRIPTION = $"{LockSmith.UPGRADE_NAME} 업그레이드의 기본 가격.";
        #endregion

        #region Malware Broadcaster

        internal const string MALWARE_BROADCASTER_ENABLED_KEY = $"{MalwareBroadcaster.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool MALWARE_BROADCASTER_ENABLED_DEFAULT = true;
        internal const string MALWARE_BROADCASTER_ENABLED_DESCRIPTION = "지도 위험 요소를 폭파시킵니다.";

        internal const string MALWARE_BROADCASTER_PRICE_KEY = $"{MalwareBroadcaster.UPGRADE_NAME} 업그레이드 가격";
        internal const int MALWARE_BROADCASTER_PRICE_DEFAULT = 550;

        internal const string MALWARE_BROADCASTER_DESTROY_TRAPS_KEY = "함정 파괴";
        internal const bool MALWARE_BROADCASTER_DESTROY_TRAPS_DEFAULT = true;
        internal const string MALWARE_BROADCASTER_DESTROY_TRAPS_DESCRIPTION = $"false이면 {MalwareBroadcaster.UPGRADE_NAME}는 함정을 파괴하는 대신 오랫동안 비활성화합니다.";

        internal const string MALWARE_BROADCASTER_DISARM_TIME_KEY = "비활성화 지속 시간";
        internal const float MALWARE_BROADCASTER_DISARM_TIME_DEFAULT = 7f;
        internal const string MALWARE_BROADCASTER_DISARM_TIME_DESCRIPTION = "'함정 파괴'가 false일 경우 함정이 비활성화되는 지속 시간입니다.";

        internal const string MALWARE_BROADCASTER_EXPLODE_TRAPS_KEY = "함정 폭발";
        internal const bool MALWARE_BROADCASTER_EXPLODE_TRAPS_DEFAULT = true;
        internal const string MALWARE_BROADCASTER_EXPLODE_TRAPS_DESCRIPTION = "'함정 파괴'가 true여야 합니다! true이면 함정 파괴 시 폭발도 발생합니다.";

        #endregion

        #region Market Influence

        internal const string MARKET_INFLUENCE_ENABLED_KEY = $"{MarketInfluence.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool MARKET_INFLUENCE_ENABLED_DEFAULT = true;
        internal const string MARKET_INFLUENCE_ENABLED_DESCRIPTION = "상점에서 선택한 아이템에 최소 할인율을 보장하는 티어 업그레이드입니다.";

        internal const string MARKET_INFLUENCE_PRICE_KEY = $"{MarketInfluence.UPGRADE_NAME} 가격";
        internal const int MARKET_INFLUENCE_PRICE_DEFAULT = 250;

        internal const string MARKET_INFLUENCE_INITIAL_PERCENTAGE_KEY = "할인 아이템 초기 보장 할인율(%)";
        internal const int MARKET_INFLUENCE_INITIAL_PERCENTAGE_DEFAULT = 10;

        internal const string MARKET_INFLUENCE_INCREMENTAL_PERCENTAGE_KEY = "할인 아이템 점진적 보장 할인율(%)";
        internal const int MARKET_INFLUENCE_INCREMENTAL_PERCENTAGE_DEFAULT = 5;

        #endregion

        #region Running Shoes

        internal const string RUNNING_SHOES_ENABLED_KEY = $"{RunningShoes.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool RUNNING_SHOES_ENABLED_DEFAULT = true;
        internal const string RUNNING_SHOES_ENABLED_DESCRIPTION = "더 빠르게 달립니다.";

        internal const string RUNNING_SHOES_PRICE_KEY = $"{RunningShoes.UPGRADE_NAME} 업그레이드 가격";
        internal const int RUNNING_SHOES_PRICE_DEFAULT = 650;

        internal const string RUNNING_SHOES_INITIAL_MOVEMENT_BOOST_KEY = "업그레이드 해금 시 이동 속도";
        internal const float RUNNING_SHOES_INITIAL_MOVEMENT_BOOST_DEFAULT = 1.4f;
        internal const string RUNNING_SHOES_INITIAL_MOVEMENT_BOOST_DESCRIPTION = "처음 구매 시 플레이어 이동 속도에 추가되는 값.\n기본(바닐라) 값은 4.6f입니다.";

        internal const string RUNNING_SHOES_INCREMENTAL_MOVEMENT_BOOST_KEY = "이동 속도 증가량";
        internal const float RUNNING_SHOES_INCREMENTAL_MOVEMENT_BOOST_DEFAULT = 0.5f;
        internal const string RUNNING_SHOES_INCREMENTAL_MOVEMENT_BOOST_DESCRIPTION = "업그레이드 시 위 값이 증가하는 양.";

        internal const string RUNNING_SHOES_NOISE_REDUCTION_KEY = "소음 감소";
        internal const float RUNNING_SHOES_NOISE_REDUCTION_DEFAULT = 10f;
        internal const string RUNNING_SHOES_NOISE_REDUCTION_DESCRIPTION = "최종 레벨 도달 시 발소리 소음에서 차감되는 거리 단위.";

        #endregion

        #region Quantum Disruptor

        internal const string QUANTUM_DISRUPTOR_ENABLED_KEY = $"{QuantumDisruptor.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool QUANTUM_DISRUPTOR_ENABLED_DEFAULT = true;
        internal const string QUANTUM_DISRUPTOR_ENABLED_DESCRIPTION = "위성 착륙 시 머물 수 있는 시간을 늘려주는 티어 업그레이드입니다.";

        internal const string QUANTUM_DISRUPTOR_PRICE_KEY = $"{QuantumDisruptor.UPGRADE_NAME} 업그레이드 가격";
        internal const int QUANTUM_DISRUPTOR_PRICE_DEFAULT = 1000;

        internal const string QUANTUM_DISRUPTOR_INITIAL_MULTIPLIER_KEY = $"{QuantumDisruptor.UPGRADE_NAME} 업그레이드 해금 시 시간 흐름 감소율(%)";
        internal const int QUANTUM_DISRUPTOR_INITIAL_MULTIPLIER_DEFAULT = 20;

        internal const string QUANTUM_DISRUPTOR_INCREMENTAL_MULTIPLIER_KEY = $"{QuantumDisruptor.UPGRADE_NAME} 레벨 증가 시 시간 흐름 감소율(%)";
        internal const int QUANTUM_DISRUPTOR_INCREMENTAL_MULTIPLIER_DEFAULT = 10;

        internal const string QUANTUM_DISRUPTOR_UPGRADE_MODE_KEY = $"{QuantumDisruptor.UPGRADE_NAME} 모드";
        internal const QuantumDisruptor.UpgradeModes QUANTUM_DISRUPTOR_UPGRADE_MODE_DEFAULT = QuantumDisruptor.UpgradeModes.SlowdownTime;
        internal const string QUANTUM_DISRUPTOR_UPGRADE_MODE_DESCRIPTION = "업그레이드 구매 시 적용되는 모드.\n" +
            "지원 모드: SlowdownTime (위성에서 시간 흐름을 느리게 함), RevertTime (실행 시 시간을 되돌리는 명령어 프롬프트, 위성당 최대 사용 횟수 제한).";

        internal const string QUANTUM_DISRUPTOR_RESET_MODE_KEY = $"{QuantumDisruptor.UPGRADE_NAME} 현재 사용 횟수 초기화 시점";
        internal const QuantumDisruptor.ResetModes QUANTUM_DISRUPTOR_RESET_MODE_DEFAULT = QuantumDisruptor.ResetModes.MoonLanding;
        internal const string QUANTUM_DISRUPTOR_RESET_MODE_DESCRIPTION = "능력 사용 카운터가 초기화되는 시점. RevertTime 모드 선택 시에만 적용됩니다.\n" +
            "지원 값: MoonLanding (위성 착륙마다 카운터 초기화), MoonRerouting (위성 재경로 설정마다 카운터 초기화), NewQuota (새 할당량마다 카운터 초기화)";

        internal const string QUANTUM_DISRUPTOR_USES_DESCRIPTION = "퀀텀 명령어를 실행할 수 있는 횟수. RevertTime 모드 선택 시에만 적용됩니다.";

        internal const string QUANTUM_DISRUPTOR_INITIAL_USES_KEY = $"{QuantumDisruptor.UPGRADE_NAME} 초기 사용 횟수";
        internal const int QUANTUM_DISRUPTOR_INITIAL_USES_DEFAULT = 1;
        internal const string QUANTUM_DISRUPTOR_INITIAL_USES_DESCRIPTION = QUANTUM_DISRUPTOR_USES_DESCRIPTION;

        internal const string QUANTUM_DISRUPTOR_INCREMENTAL_USES_KEY = $"{QuantumDisruptor.UPGRADE_NAME} 점진적 사용 횟수 증가";
        internal const int QUANTUM_DISRUPTOR_INCREMENTAL_USES_DEFAULT = 1;
        internal const string QUANTUM_DISRUPTOR_INCREMENTAL_USES_DESCRIPTION = QUANTUM_DISRUPTOR_USES_DESCRIPTION;

        internal const string QUANTUM_DISRUPTOR_HOURS_REVERT_DESCRIPTION = "퀀텀 명령어 실행 시 되돌릴 시간(시간 단위). RevertTime 모드 선택 시에만 적용됩니다.";

        internal const string QUANTUM_DISRUPTOR_INITIAL_HOURS_ON_REVERT_KEY = $"{QuantumDisruptor.UPGRADE_NAME} 초기 되돌릴 시간(시간)";
        internal const int QUANTUM_DISRUPTOR_INITIAL_HOURS_ON_REVERT_DEFAULT = 1;
        internal const string QUANTUM_DISRUPTOR_INITIAL_HOURS_ON_REVERT_DESCRIPTION = QUANTUM_DISRUPTOR_HOURS_REVERT_DESCRIPTION;

        internal const string QUANTUM_DISRUPTOR_INCREMENTAL_HOURS_ON_REVERT_KEY = $"{QuantumDisruptor.UPGRADE_NAME} 점진적 되돌릴 시간 증가(시간)";
        internal const int QUANTUM_DISRUPTOR_INCREMENTAL_HOURS_ON_REVERT_DEFAULT = 1;
        internal const string QUANTUM_DISRUPTOR_INCREMENTAL_HOURS_ON_REVERT_DESCRIPTION = QUANTUM_DISRUPTOR_HOURS_REVERT_DESCRIPTION;

        #endregion

        #region Sick Beats

        internal const string SICK_BEATS_ENABLED_KEY = $"{SickBeats.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool SICK_BEATS_ENABLED_DEFAULT = true;
        internal const string SICK_BEATS_ENABLED_DESCRIPTION = "근처에서 활성화된 붐박스로부터 버프를 받습니다.";

        internal const string SICK_BEATS_PRICE_KEY = "기본 해금 가격";
        internal const int SICK_BEATS_PRICE_DEFAULT = 500;

        internal const string SICK_BEATS_SPEED_KEY = "속도 부스트 효과 활성화";
        internal const bool SICK_BEATS_SPEED_DEFAULT = true;

        internal const string SICK_BEATS_DAMAGE_KEY = "데미지 부스트 효과 활성화";
        internal const bool SICK_BEATS_DAMAGE_DEFAULT = true;

        internal const string SICK_BEATS_STAMINA_KEY = "스태미나 부스트 효과 활성화";
        internal const bool SICK_BEATS_STAMINA_DEFAULT = false;

        internal const string SICK_BEATS_DEFENSE_KEY = "방어 부스트 효과 활성화";
        internal const bool SICK_BEATS_DEFENSE_DEFAULT = false;

        internal const string SICK_BEATS_DEFENSE_MULTIPLIER_KEY = "방어 부스트 계수";
        internal const float SICK_BEATS_DEFENSE_MULTIPLIER_DEFAULT = 0.5f;
        internal const string SICK_BEATS_DEFENSE_MULTIPLIER_DESCRIPTION = "받는 데미지에 곱해집니다.";

        internal const string SICK_BEATS_STAMINA_MULTIPLIER_KEY = "스태미나 회복 계수";
        internal const float SICK_BEATS_STAMINA_MULTIPLIER_DEFAULT = 1.25f;
        internal const string SICK_BEATS_STAMINA_MULTIPLIER_DESCRIPTION = "스태미나 회복에 곱해집니다.";

        internal const string SICK_BEATS_APPLY_STAMINA_CONSUMPTION_KEY = "스태미나 소모 상황에 스태미나 버프 적용";
        internal const bool SICK_BEATS_APPLY_STAMINA_CONSUMPTION_DEFAULT = false;
        internal const string SICK_BEATS_APPLY_STAMINA_CONSUMPTION_DESCRIPTION = "활성화하면 스태미나가 지속적으로 소모되는 상황에도 스태미나 버프가 적용됩니다.";

        internal const string SICK_BEATS_ADDITIONAL_DAMAGE_KEY = "추가 공격 데미지";
        internal const int SICK_BEATS_ADDITIONAL_DAMAGE_DEFAULT = 1;

        internal const string SICK_BEATS_ADDITIONAL_SPEED_KEY = "속도 부스트 증가량";
        internal const float SICK_BEATS_ADDITIONAL_SPEED_DEFAULT = 1.5f;

        internal const string SICK_BEATS_EFFECT_RADIUS_KEY = "효과 범위";
        internal const float SICK_BEATS_EFFECT_RADIUS_DEFAULT = 15f;
        internal const string SICK_BEATS_EFFECT_RADIUS_DESCRIPTION = "활성화된 붐박스로부터 플레이어에게 효과가 미치는 Unity 단위 반경.";

        internal const string SICK_BEATS_BOOMBOX_ATTRACT_SOUND_KEY = "붐박스 적 유인 소리 토글";
        internal const bool SICK_BEATS_BOOMBOX_ATTRACT_SOUND_DEFAULT = true;
        internal const string SICK_BEATS_BOOMBOX_ATTRACT_SOUND_DESCRIPTION = "업그레이드 구매 후 붐박스가 근처 적을 유인할지 여부";

        #endregion

        #region Sigurd Access

        internal const string SIGURD_ACCESS_ENABLED_KEY = $"{Sigurd.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool SIGURD_ACCESS_ENABLED_DEFAULT = true;
        internal const string SIGURD_ACCESS_ENABLED_DESCRIPTION = "회사가 스크랩을 더 높은 가격에 매입할 확률이 생깁니다.";

        internal const string SIGURD_ACCESS_ENABLED_LAST_DAY_KEY = $"마지막 날 {Sigurd.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool SIGURD_ACCESS_ENABLED_LAST_DAY_DEFAULT = true;
        internal const string SIGURD_ACCESS_ENABLED_LAST_DAY_DESCRIPTION = "마지막 날 스크랩 가치가 100%를 초과할 확률이 생깁니다.";

        internal const string SIGURD_ACCESS_PRICE_KEY = $"{Sigurd.UPGRADE_NAME} 가격";
        internal const int SIGURD_ACCESS_PRICE_DEFAULT = 500;
        internal const string SIGURD_ACCESS_PRICE_DESCRIPTION = $"업그레이드 기본 가격. 0으로 설정하면 구매 없이 {Sigurd.UPGRADE_NAME}를 활성화합니다.";

        internal const string SIGURD_ACCESS_CHANCE_KEY = "업그레이드 발동 확률";
        internal const float SIGURD_ACCESS_CHANCE_DEFAULT = 20f;

        internal const string SIGURD_ACCESS_CHANCE_LAST_DAY_KEY = "마지막 날 업그레이드 발동 확률";
        internal const float SIGURD_ACCESS_CHANCE_LAST_DAY_DEFAULT = 20f;

        internal const string SIGURD_ACCESS_ADDITIONAL_PERCENT_KEY = "확률 증가량";
        internal const float SIGURD_ACCESS_ADDITIONAL_PERCENT_DEFAULT = 20f;

        internal const string SIGURD_ACCESS_ADDITIONAL_PERCENT_LAST_DAY_KEY = "마지막 날 확률 증가량";
        internal const float SIGURD_ACCESS_ADDITIONAL_PERCENT_LAST_DAY_DEFAULT = 20f;

        #endregion

        #region Strong Legs

        internal const string STRONG_LEGS_ENABLED_KEY = $"{StrongLegs.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool STRONG_LEGS_ENABLED_DEFAULT = true;
        internal const string STRONG_LEGS_ENABLED_DESCRIPTION = "더 높이 점프합니다.";

        internal const string STRONG_LEGS_PRICE_KEY = $"{StrongLegs.UPGRADE_NAME} 업그레이드 가격";
        internal const int STRONG_LEGS_PRICE_DEFAULT = 300;

        internal const string STRONG_LEGS_INITIAL_JUMP_FORCE_KEY = "업그레이드 해금 시 점프력";
        internal const float STRONG_LEGS_INITIAL_JUMP_FORCE_DEFAULT = 3f;
        internal const string STRONG_LEGS_INITIAL_JUMP_FORCE_DESCRIPTION = "업그레이드 해금 시 추가되는 점프력.\n기본(바닐라) 값은 13f입니다.";

        internal const string STRONG_LEGS_INCREMENTAL_JUMP_FORCE_KEY = "점프력 증가량";
        internal const float STRONG_LEGS_INCREMENTAL_JUMP_FORCE_DEFAULT = 0.75f;
        internal const string STRONG_LEGS_INCREMENTAL_JUMP_FORCE_DESCRIPTION = "업그레이드 시 위 값이 증가하는 양.";

        #endregion

        #region Walkie GPS

        internal const string WALKIE_GPS_ENABLED_KEY = $"{WalkieGPS.UPGRADE_NAME} 업그레이드 활성화";
        internal const bool WALKIE_GPS_ENABLED_DEFAULT = true;
        internal const string WALKIE_GPS_ENABLED_DESCRIPTION = "무전기를 들고 있으면 위치가 표시됩니다.";

        internal const string WALKIE_GPS_PRICE_KEY = $"{WalkieGPS.UPGRADE_NAME} 가격";
        internal const int WALKIE_GPS_PRICE_DEFAULT = 450;
        internal const string WALKIE_GPS_PRICE_DESCRIPTION = $"{WalkieGPS.UPGRADE_NAME} 업그레이드의 기본 가격.";

		#endregion

		#region Baby Pacifier

		internal const string BABY_PACIFIER_ENABLED_KEY = $"{BabyPacifier.UPGRADE_NAME} 업그레이드 활성화.";
		internal const bool BABY_PACIFIER_ENABLED_DEFAULT = true;
		internal const string BABY_PACIFIER_ENABLED_DESCRIPTION = "아기 식인귀가 울 때 성장 속도를 줄입니다.";

        internal const string BABY_PACIFIER_INITIAL_PERCENTAGE_KEY = "초기 성장 감소율(%)";
        internal const int BABY_PACIFIER_INITIAL_PERCENTAGE_DEFAULT = 15;
        internal const string BABY_PACIFIER_INITIAL_PERCENTAGE_DESCRIPTION = "울 때 식인귀 성장 증가량에서 제거되는 초기 비율(%)";

        internal const string BABY_PACIFIER_INCREMENTAL_PERCENTAGE_KEY = "점진적 성장 감소율(%)";
        internal const int BABY_PACIFIER_INCREMENTAL_PERCENTAGE_DEFAULT = 15;
        internal const string BABY_PACIFIER_INCREMENTAL_PERCENTAGE_DESCRIPTION = "울 때 식인귀 성장 증가량에서 제거되는 점진적 비율(%)";

        #endregion

        #region Item Duplicator

        internal const string ITEM_DUPLICATOR_ENABLED_DESCRIPTION = "회사 상점에서 구매한 아이템을 드롭 포드의 공간을 차지하지 않고 복제할 가능성이 있습니다.";

        internal const string ITEM_DUPLICATOR_INITIAL_PERCENTAGE_KEY = "초기 복제 확률(%)";
        internal const int ITEM_DUPLICATOR_INITIAL_PERCENTAGE_DEFAULT = 30;
        internal const string ITEM_DUPLICATOR_INITIAL_PERCENTAGE_DESCRIPTION = "드롭 포드에서 구매한 아이템이 복제될 초기 확률(%).";

        internal const string ITEM_DUPLICATOR_INCREMENTAL_PERCENTAGE_KEY = "점진적 복제 확률(%)";
        internal const int ITEM_DUPLICATOR_INCREMENTAL_PERCENTAGE_DEFAULT = 15;
        internal const string ITEM_DUPLICATOR_INCREMENTAL_PERCENTAGE_DESCRIPTION = "드롭 포드에서 구매한 아이템이 복제될 점진적 확률(%).";

		#endregion

		#endregion

		#endregion

		#region Alternative Currency

		internal const string ALTERNATIVE_CURRENCY_ALIAS = "PC";

        internal const string ALTERNATIVE_CURRENCY_TOPSECTION = "_Alternative Currency_";

        internal const string ALTERNATIVE_CURRENCY_ENABLED_KEY = "대체 화폐 시스템 활성화";
        internal const bool ALTERNATIVE_CURRENCY_ENABLED_DEFAULT = false;
        internal const string ALTERNATIVE_CURRENCY_ENABLED_DESCRIPTION = "회사 크레딧 외 다른 화폐로 Lategame 업그레이드를 구매할 수 있게 합니다.";

        internal const string ALTERNATIVE_CURRENCY_CREDITS_TO_CURRENCY_RATIO_KEY = "크레딧 대 대체 화폐 비율";
        internal const int ALTERNATIVE_CURRENCY_CREDITS_TO_CURRENCY_RATIO_DEFAULT = 100;
        internal const string ALTERNATIVE_CURRENCY_CREDITS_TO_CURRENCY_RATIO_DESCRIPTION = "업그레이드 구매 시 대체 화폐 1단위의 가치(회사 크레딧 기준).";

        internal const string ALTERNATIVE_CURRENCY_QUOTA_TO_CURRENCY_RATIO_KEY = "할당량 대 대체 화폐 비율";
        internal const int ALTERNATIVE_CURRENCY_QUOTA_TO_CURRENCY_RATIO_DEFAULT = 100;
        internal const string ALTERNATIVE_CURRENCY_QUOTA_TO_CURRENCY_RATIO_DESCRIPTION = "대체 화폐 1단위의 가치(할당량 충족량 기준).";

        internal const string ALTERNATIVE_CURRENCY_CREDITS_TO_CURRENCY_CONVERSION_RATIO_KEY = "크레딧을 대체 화폐로 전환 비율";
        internal const int ALTERNATIVE_CURRENCY_CREDITS_TO_CURRENCY_CONVERSION_RATIO_DEFAULT = 100;
        internal const string ALTERNATIVE_CURRENCY_CREDITS_TO_CURRENCY_CONVERSION_RATIO_DESCRIPTION = "대체 화폐 1단위를 구매하는 데 필요한 회사 크레딧 수.";

        internal const string ALTERNATIVE_CURRENCY_CURRENCY_TO_CREDITS_CONVERSION_RATIO_KEY = "대체 화폐를 크레딧으로 전환 비율";
        internal const int ALTERNATIVE_CURRENCY_CURRENCY_TO_CREDITS_CONVERSION_RATIO_DEFAULT = 100;
        internal const string ALTERNATIVE_CURRENCY_CURRENCY_TO_CREDITS_CONVERSION_RATIO_DESCRIPTION = "대체 화폐 1단위 전환 시 획득하는 회사 크레딧 수.";

        internal static string[] TRADE_PLAYER_CREDITS_COMMAND_PROMPT = ["trade", "trade player credits", "lgu trade"];
        internal static string[] CONVERT_PLAYER_CREDITS_COMMAND_PROMPT = ["convert", "PC"];
		#endregion

		#region LGU Store Interactive UI

		internal const string COLOR_INITIAL_FORMAT = "<color={0}>";
        internal const string COLOR_FINAL_FORMAT = "</color>";
        internal const string DEFAULT_DEACTIVATED_TEXT_COLOUR = HEXADECIMAL_GREY + "55";

        internal static string[] LGU_COMMAND_PROMPTS = ["lgu", "lategame store"];

		#region Main Screen

		internal const string MAIN_SCREEN_TITLE = "Lategame Upgrades";
        internal const string MAIN_SCREEN_TOP_TEXT = "구매할 업그레이드를 선택하세요:";
        internal const string MAIN_SCREEN_TOP_TEXT_NO_ENTRIES = "구매 가능한 업그레이드가 없습니다.";

        internal const string MAIN_SCREEN_INDIVIDUAL_UPGRADES_TEXT = "개인 업그레이드";
        internal const string MAIN_SCREEN_SHARED_UPGRADES_TEXT = "공유 업그레이드";

        #endregion

        #region Upgrade Display

        internal const string NOT_ENOUGH_CREDITS = "이 업그레이드를 구매할 크레딧이 부족합니다.";
        internal const string REACHED_MAX_LEVEL = "이 업그레이드의 최대 레벨에 도달했습니다.";
        internal const string LOCKED_UPGRADE = "이 업그레이드는 다른 승무원에게 할당되었습니다.";
        internal const string PURCHASE_UPGRADE_FORMAT = "이 업그레이드를 {0} 크레딧으로 구매하시겠습니까?";
        internal const string PURCHASE_UPGRADE_ALTERNATE_FORMAT = "이 업그레이드를 플레이어 크레딧 {0}개로 구매하시겠습니까?";

        #endregion

        #region Cursor Display
        internal const char CURSOR = '>';

        internal const string SELECTED_CURSOR_ELEMENT_FORMAT = "<mark={0}><color={1}>{2}</color></mark>";
        internal const string DEFAULT_BACKGROUND_SELECTED_COLOR = HEXADECIMAL_GREEN + "33";
        internal const string DEFAULT_TEXT_SELECTED_COLOR = HEXADECIMAL_WHITE + "FF";

        internal const string GO_BACK_PROMPT = "뒤로";

        internal const string CONFIRM_PROMPT = "확인";
        internal const string CANCEL_PROMPT = "취소";
        #endregion

        #region Screen Display
        internal const int AVAILABLE_CHARACTERS_PER_LINE = 51;
        internal const char TOP_LEFT_CORNER = '╭';
        internal const char TOP_RIGHT_CORNER = '╮';
        internal const char BOTTOM_LEFT_CORNER = '╰';
        internal const char BOTTOM_RIGHT_CORNER = '╯';
        internal const char VERTICAL_LINE = '│';
        internal const char HORIZONTAL_LINE = '─';

        internal const char CONNECTING_TITLE_LEFT = '╢';
        internal const char CONNECTING_TITLE_RIGHT = '╟';
        internal const char TOP_RIGHT_TITLE_CORNER = '╗';
        internal const char TOP_LEFT_TITLE_CORNER = '╔';
        internal const char BOTTOM_RIGHT_TITLE_CORNER = '╝';
        internal const char BOTTOM_LEFT_TITLE_CORNER = '╚';
        internal const char VERTICAL_TITLE_LINE = '║';
        internal const char HORIZONTAL_TITLE_LINE = '═';

        #region Page Display
        internal const int START_PAGE_COUNTER = 30;
        #endregion

        #region Upgrades Display
        internal const int NAME_LENGTH = 17;
        internal const int LEVEL_LENGTH = 7;

        internal const char EMPTY_LEVEL = '○';
        internal const char FILLED_LEVEL = '●';
        #endregion

        #endregion

        #region Colours
        internal static readonly Color Invisible = new(0, 0, 0, 0);
        #endregion

        #endregion

        #region Terminal Nodes

        internal const string DISCOMBOBULATOR_NOT_ACTIVE = "이 명령어에 아직 접근할 수 없습니다. '디스콤보불레이터'를 구매하세요.\n\n";
        internal const string DISCOMBOBULATOR_ON_COOLDOWN_FORMAT = "{0}초 후에 다시 디스콤보불레이트를 사용할 수 있습니다.\n'cooldown' 또는 'cd'를 입력하여 쿨다운을 확인하세요.\n\n";
        internal const string DISCOMBOBULATOR_NO_ENEMIES = "기절한 적이 감지되지 않았습니다.\n\n";
        internal const string DISCOMBULATOR_HIT_ENEMIES = "디스콤보불레이터가 적 {0}마리에게 적중했습니다.\n\n";
        internal const string DISCOMBOBULATOR_DISPLAY_COOLDOWN = "{0}초 후에 다시 디스콤보불레이트를 사용할 수 있습니다.\n\n";
        internal const string DISCOMBOBULATOR_READY = "디스콤보불레이트 준비 완료. 'initattack' 또는 'atk'를 입력하여 실행하세요.\n\n";

        internal const string LGU_SAVE_WIPED = "LGU 저장 데이터가 초기화되었습니다.\n\n";
        internal const string LGU_SAVE_NOT_FOUND = "LGU 저장 데이터를 찾을 수 없습니다!\n\n";

        internal const string FORCE_CREDITS_SUCCESS_FORMAT = "이제 모든 클라이언트의 크레딧이 ${0}이어야 합니다.\n\n";
        internal const string FORCE_CREDITS_HOST_ONLY = "호스트만 이 작업을 수행할 수 있습니다.";
        internal const string FORCE_CREDITS_PARSED_FAIL_FORMAT = "값 {0}을(를) 파싱하는 데 실패했습니다.\n\n";

        internal const string INTERNS_NOT_ENOUGH_CREDITS_FORMAT = "인턴 채용에 {0} 크레딧이 필요하지만 현재 {1} 크레딧만 보유하고 있습니다.\n";
        internal const string INTERNS_PLAYER_ALREADY_ALIVE_FORMAT = "{0}는 아직 살아있으므로 인턴으로 교체할 수 없습니다.\n\n";

        internal const string LOAD_LGU_NO_NAME = "복사하고 싶은 업그레이드/저장 데이터의 사용자 이름을 입력하세요. 예: `load lgu steve`\n";
        internal const string LOAD_LGU_SUCCESS_FORMAT = "{0}의 저장 데이터로 로컬 저장 데이터를 덮어쓰는 중입니다.\n5초 후에 팝업이 표시될 것입니다...\n.\n";
        internal const string LOAD_LGU_FAILURE_FORMAT = "이름 {0}을(를) 찾을 수 없습니다. 다음 이름이 발견되었습니다:\n{1}\n";

        internal const string UNLOAD_LGU_SUCCESS_FORMAT = "{0} 언로딩 중\n\n";

        internal const string SCANNER_LEVEL_REQUIRED = "이 명령어를 사용하려면 베터 스캐너를 2레벨로 업그레이드하세요.\n`info better scanner`를 입력하여 업그레이드를 확인하세요.\n\n";

        internal const string CONTRACT_CANCEL_FAIL = "이 명령어를 실행하려면 계약을 수락한 상태여야 합니다...\n\n";
        internal const string CONTRACT_CANCEL_CONFIRM_PROMPT = "현재 계약을 취소하려면 CONFIRM을 입력하세요. 환불은 불가합니다.\n\n";
        internal const string CONTRACT_FAIL = "설정에서 비활성화되어 있어 계약을 제공할 수 없습니다.\n\n";

        internal const string BRUTEFORCE_USAGE = "연결할 장치의 유효한 주소를 입력하세요!\n\n";

        internal const string CONTRACT_CANCEL_CONFIRM_PROMPT_FAIL = "사용자 입력 확인에 실패했습니다. 계약 취소 요청이 무효화되었습니다.\n\n";
        internal const string CONTRACT_CANCEL_CONFIRM_PROMPT_SUCCESS = "계약을 취소하는 중...\n\n";

        internal const string CONTRACT_SPECIFY_CONFIRM_PROMPT_FAIL = "사용자 입력 확인에 실패했습니다. 지정된 위성 계약 요청이 무효화되었습니다.\n\n";
        internal const string CONTRACT_SPECIFY_CONFIRM_PROMPT_SUCCESS_FORMAT = "{1}에 대한 {0} 계약이 수락되었습니다!{2}";

        internal const string SCRAP_INSURANCE_ALREADY_PURCHASED = "이미 스크랩 보호 보험을 구매했습니다.\n\n";
        internal const string SCRAP_INSURANCE_ONLY_IN_ORBIT = "궤도 비행 중에만 보험을 가입할 수 있습니다.\n\n";
        internal const string SCRAP_INSURANCE_NOT_ENOUGH_CREDITS_FORMAT = "스크랩 보험을 구매할 크레딧이 부족합니다.\n가격: {0}\n현재 크레딧: {1}\n\n";
        internal const string SCRAP_INSURANCE_SUCCESS = "스크랩 보험이 활성화되었습니다.\n다음 탐험에서 팀 전멸 시 스크랩이 보존됩니다.\n\n";

        internal const string LOOKUP_NOT_IN_CONTRACT = "이 명령어를 사용하려면 해체 계약 중이어야 합니다!\n\n";
        internal const string LOOKUP_USAGE = "조회할 시리얼 번호를 입력해야 합니다!\n\n";
        internal const string LOOKUP_CUT_WIRES_FORMAT = "다음 순서로 전선을 절단하세요:\n\n{0}\n\n";
        #endregion

        #region Chat Notifications

        internal const string UPGRADE_LOADED_NOTIFICATION_DEFAULT_COLOR = HEXADECIMAL_RED;
        internal const string UPGRADE_UNLOADED_NOTIFICATION_DEFAULT_COLOR = HEXADECIMAL_RED;

        #endregion

        #region Contracts

        internal const string DEFUSAL_CONTRACT_NAME = "Defusal";
        internal const string EXTRACTION_CONTRACT_NAME = "Extraction";
        internal const string DATA_CONTRACT_NAME = "Data";
        internal const string EXTERMINATOR_CONTRACT_NAME = "Exterminator";
        internal const string EXORCISM_CONTRACT_NAME = "Exorcism";

        internal static string[] CONTRACT_COMMAND_PROMPT = ["contracts", "contract"];

        #endregion
    }
}
