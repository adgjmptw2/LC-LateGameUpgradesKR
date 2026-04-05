using MoreShipUpgrades.Managers;
using System;

namespace MoreShipUpgrades.UI.TerminalNodes
{
    /// <summary>
    /// Handler that changes the contents of the "help" terminal node
    /// </summary>
    internal static class HelpTerminalNode
    {
        static bool addedHelp = false;
        const string TRADING_HELP_COMMAND = ">LGU TRADE / TRADE PLAYER CREDITS / TRADE\n 플레이어 간 플레이어 크레딧 거래를 허용합니다.\n\n";
        const string CONVERT_HELP_COMMAND = ">CONVERT / PC\n회사 크레딧을 플레이어 크레딧으로, 또는 그 반대로 변환할 수 있습니다.\n\n";
        const string INTERNS_HELP_COMMAND = ">INTERNS / INTERN\n레이더에서 선택한 플레이어를 새로운 직원과 함께 부활시킵니다. 부활할 때마다 {0} 크레딧이 소모됩니다.\n\n";

        const string CONTRACT_HELP_COMMAND = ">CONTRACT [moon]\n지정된 행성을 떠날 때까지 지속되는, 상당한 가치를 지닌 고철 아이템에 대한 무작위 계약을 제공합니다.\n각 계약마다 {0} 크레딧이 소모되며 현재 계약이 만료될 때까지 다른 계약을 체결할 수 없습니다.\n달이 지정되면 {1} 회사 크레딧의 비용으로 해당 달에 대한 계약이 생성됩니다.\n\n";
        const string ATK_HELP_COMMAND = ">ATK / INITATTACK\n일정 시간 동안 주변 적들을 기절시킵니다. 디스콤보뷸레이터를 구매했을 때만 사용 가능합니다.\n\n";
        const string CD_HELP_COMMAND = ">CD / COOLDOWN\n함선 기절 능력의 현재 재사용 대기시간을 표시합니다. 디스콤보뷸레이터를 구매했을 때만 적용됩니다.\n\n";
        const string INFO_CONTRACT_HELP_COMMAND = ">CONTRACT INFO\n각 계약과 관련된 모든 정보 및 계약 체결 방법을 표시합니다.\n\n";

        /// <summary>
        /// Prepares the "help" terminal node to add information related to LGU-related commands such as "Scrap Insurance", "Interns", etc.
        /// </summary>
        internal static void SetupLGUHelpCommand(TerminalNode helpNode = null)
        {
            if (helpNode == null)
            {
                helpNode = LguTerminalNode.GetHelpTerminalNode();
            }
            if (addedHelp) return;
            helpNode.displayText += ">LATEGAME\nLategame-Upgrades 모드와 관련된 정보를 표시합니다.\n\n";
            addedHelp = true;
        }
        /// <summary>
        /// Adds information related to the Discombobulator's commands to the given terminal node
        /// </summary>
        public static string HandleHelpDiscombobulator()
        {
            if (UpgradeBus.Instance.PluginConfiguration.DiscombobulatorUpgradeConfiguration.Enabled.Value)
            {
                return ATK_HELP_COMMAND + CD_HELP_COMMAND;
            }
            return "";
        }
        /// <summary>
        /// Adds information related to the contract's commands to the given terminal node
        /// </summary>
        public static string HandleHelpContract()
        {
            if (UpgradeBus.Instance.PluginConfiguration.ContractsConfiguration.Enabled.Value)
            {
                return string.Format(CONTRACT_HELP_COMMAND + INFO_CONTRACT_HELP_COMMAND, UpgradeBus.Instance.PluginConfiguration.ContractsConfiguration.RandomPrice.Value, UpgradeBus.Instance.PluginConfiguration.ContractsConfiguration.SpecifyPrice.Value);
            }
            return "";
        }
        /// <summary>
        /// Adds information related to the intern's command to the given terminal node
        /// </summary>
        public static string HandleHelpInterns()
        {
            if (UpgradeBus.Instance.PluginConfiguration.INTERN_ENABLED.Value)
            {
                return string.Format(INTERNS_HELP_COMMAND, UpgradeBus.Instance.PluginConfiguration.INTERN_PRICE.Value);
            }
            return "";
        }

        internal static string HandleAlternateCurrency()
        {
            if (CurrencyManager.Enabled)
            {
                return CONVERT_HELP_COMMAND + TRADING_HELP_COMMAND;
            }
            return "";
        }
    }
}
