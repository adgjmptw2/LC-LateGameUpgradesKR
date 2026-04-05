using BepInEx.Configuration;
using CSync.Extensions;
using CSync.Lib;
using MoreShipUpgrades.Configuration.Upgrades.Interfaces;
using MoreShipUpgrades.Misc.Util;
using MoreShipUpgrades.UI.TerminalNodes;

namespace MoreShipUpgrades.Configuration.Upgrades.Abstractions
{
    public abstract class UpgradeConfiguration(ConfigFile cfg, string topSection, string enabledDescription) : IUpgradeConfiguration
    {
        [field: SyncedEntryField] public SyncedEntry<bool> Enabled { get; set; } = cfg.BindSyncedEntry(topSection, string.Format(LguConstants.ENABLED_FORMAT, topSection), true, enabledDescription);
        [field: SyncedEntryField] public SyncedEntry<int> MinimumSalePercentage { get; set; } = cfg.BindSyncedEntry(topSection, "최소 세일 비율", 60, "업그레이드 할인 판매 시 달성해야 하는 최소 비율");
        [field: SyncedEntryField] public SyncedEntry<int> MaximumSalePercentage { get; set; } = cfg.BindSyncedEntry(topSection, "최대 세일 비율", 90, "업그레이드 할인 행사 시 달성 가능한 최대 비율");
        [field: SyncedEntryField] public SyncedEntry<string> OverrideName { get; set; } = cfg.BindSyncedEntry(topSection, string.Format(LguConstants.OVERRIDE_NAME_KEY_FORMAT, topSection), LguConstants.GetDefaultName(topSection));
        [field: SyncedEntryField] public SyncedEntry<string> ItemProgressionItems { get; set; } = cfg.BindSyncedEntry(topSection, LguConstants.ITEM_PROGRESSION_ITEMS_KEY, LguConstants.ITEM_PROGRESSION_ITEMS_DEFAULT, LguConstants.ITEM_PROGRESSION_ITEMS_DESCRIPTION);
        [field: SyncedEntryField] public SyncedEntry<PurchaseMode> PurchaseMode { get; set; } = cfg.BindSyncedEntry(topSection, "구매 모드", UI.TerminalNodes.PurchaseMode.Both, "업그레이드가 가능한 구매 방식");
        [field: SyncedEntryField] public SyncedEntry<bool> Refundable { get; set; } = cfg.BindSyncedEntry(topSection, "환불 허용", false, "이 기능이 활성화된 경우, 선택한 업그레이드에서 레벨을 환불할 수 있습니다.");
        [field: SyncedEntryField] public SyncedEntry<int> RefundPercentage { get; set; } = cfg.BindSyncedEntry(topSection, "환불 비율", 100, "환불된 금액 대비 반환된 크레딧 비율(%)");
    }
}
