using InteractiveTerminalAPI.UI;
using InteractiveTerminalAPI.UI.Application;
using InteractiveTerminalAPI.UI.Cursor;
using InteractiveTerminalAPI.UI.Page;
using InteractiveTerminalAPI.UI.Screen;
using MoreShipUpgrades.API;
using MoreShipUpgrades.Managers;
using MoreShipUpgrades.Misc.Util;
using MoreShipUpgrades.UI.Cursor;
using MoreShipUpgrades.UI.TerminalNodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace MoreShipUpgrades.UI.Application
{
    internal class UpgradeStoreApplication : PageApplication<CursorElement>
    {
        const int UPGRADES_PER_PAGE = 12;
        protected override int GetEntriesPerPage<T>(T[] entries)
        {
            return UPGRADES_PER_PAGE;
        }
        public override void Initialization()
        {
            CustomTerminalNode[] filteredNodes = UpgradeApi.GetPurchaseableUpgradeNodes().ToArray();

            if (filteredNodes.Length == 0)
            {
                CursorElement[] elements =
                [
                    CursorElement.Create(name: "나가기", action: () => UnityEngine.Object.Destroy(InteractiveTerminalManager.Instance)),
                ];
                CursorMenu<CursorElement> cursorMenu = CursorMenu<CursorElement>.Create(startingCursorIndex: 0, elements: elements);
                IScreen screen = new BoxedScreen()
                {
                    Title = LguConstants.MAIN_SCREEN_TITLE,
                    elements =
                    [
                        new TextElement()
                        {
                            Text = LguConstants.MAIN_SCREEN_TOP_TEXT_NO_ENTRIES,
                        },
                        new TextElement()
                        {
                            Text = " "
                        },
                        cursorMenu
                    ]
                };
                currentPage = PageCursorElement<CursorElement>.Create(startingPageIndex: 0, elements: [screen], cursorMenus: [cursorMenu]);
                currentCursorMenu = cursorMenu;
                currentScreen = screen;
                return;
            }

            List<CursorElement> cursorElements = [];
            PageCursorElement<CursorElement> sharedPage = GetFilteredUpgradeNodes(ref filteredNodes, ref cursorElements, (x) => x.SharedUpgrade, LguConstants.MAIN_SCREEN_TITLE, LguConstants.MAIN_SCREEN_SHARED_UPGRADES_TEXT);
            PageCursorElement<CursorElement> individualPage = GetFilteredUpgradeNodes(ref filteredNodes, ref cursorElements, (x) => !x.SharedUpgrade && (UpgradeBus.Instance.PluginConfiguration.ShowLockedUpgrades || !UpgradeBus.Instance.lockedUpgrades.Keys.Contains(x)), LguConstants.MAIN_SCREEN_TITLE, LguConstants.MAIN_SCREEN_INDIVIDUAL_UPGRADES_TEXT);

            if (cursorElements.Count > 1)
            {
                CursorElement[] upgradeElements = [.. cursorElements];
                CursorMenu<CursorElement> upgradeCursorMenu = CursorMenu<CursorElement>.Create(startingCursorIndex: 0, elements: upgradeElements);
                IScreen upgradeScreen = new BoxedScreen()
                {
                    Title = LguConstants.MAIN_SCREEN_TITLE,
                    elements =
                    [
                        upgradeCursorMenu
                    ]
                };
                initialPage = PageCursorElement<CursorElement>.Create(startingPageIndex: 0, elements: [upgradeScreen], cursorMenus: [upgradeCursorMenu]);
            }
            else
            {
                if (sharedPage == null)
                {
                    initialPage = individualPage;
                }
                else
                {
                    initialPage = sharedPage;
                }
            }
            currentPage = initialPage;
            currentCursorMenu = currentPage.GetCurrentCursorMenu();
            currentScreen = currentPage.GetCurrentScreen();
        }
        PageCursorElement<CursorElement> GetFilteredUpgradeNodes(ref CustomTerminalNode[] nodes, ref List<CursorElement> list, Func<CustomTerminalNode, bool> predicate, string pageTitle, string cursorName)
        {
            PageCursorElement<CursorElement> page = null;
            CustomTerminalNode[] filteredNodes = nodes.Where(predicate).ToArray();
            if (filteredNodes.Length > 0)
            {
                page = BuildUpgradePage(filteredNodes, pageTitle);
                list.Add(CursorElement.Create(name: cursorName, action: () => SwitchToUpgradeScreen(page, previous: true)));
            }
            return page;
        }
        void SwitchToUpgradeScreen(PageCursorElement<CursorElement> page, bool previous)
        {
            InteractiveTerminalAPI.Compat.InputUtils_Compat.CursorExitKey.performed -= OnScreenExit;
            InteractiveTerminalAPI.Compat.InputUtils_Compat.CursorExitKey.performed += OnUpgradeStoreExit;
            SwitchScreen(page, previous);
        }

        void OnUpgradeStoreExit(CallbackContext context)
        {
            ResetScreen();
            InteractiveTerminalAPI.Compat.InputUtils_Compat.CursorExitKey.performed += OnScreenExit;
            InteractiveTerminalAPI.Compat.InputUtils_Compat.CursorExitKey.performed -= OnUpgradeStoreExit;
        }
        PageCursorElement<CursorElement> BuildUpgradePage(CustomTerminalNode[] nodes, string title)
        {
            (CustomTerminalNode[][], BaseCursorMenu<CursorElement>[], IScreen[]) entries = GetPageEntries(nodes);

            CustomTerminalNode[][] pagesUpgrades = entries.Item1;
            BaseCursorMenu<CursorElement>[] cursorMenus = entries.Item2;
            IScreen[] screens = entries.Item3;
            PageCursorElement<CursorElement> page = null;
            for (int i = 0; i < pagesUpgrades.Length; i++)
            {
                CustomTerminalNode[] upgrades = pagesUpgrades[i];
                CursorElement[] elements = new CursorElement[upgrades.Length];
                cursorMenus[i] = CursorMenu<CursorElement>.Create(startingCursorIndex: 0, elements: elements,
                    sorting: [
                        CompareName,
                        CompareCurrentPrice,
                        CompareCurrentPriceReversed
                        ]
                );
                BaseCursorMenu<CursorElement> cursorMenu = cursorMenus[i];
                screens[i] = new BoxedOutputScreen<string, string>()
                {
                    Title = title,
                    elements =
                    [
                        new TextElement()
                        {
                            Text = LguConstants.MAIN_SCREEN_TOP_TEXT,
                        },
                        new TextElement()
                        {
                            Text = " "
                        },
                        cursorMenu,
                    ],
                    Output = (x) => x,
                    Input = GetCurrentSort,
                };
                for (int j = 0; j < upgrades.Length; j++)
                {
                    CustomTerminalNode upgrade = upgrades[j];
                    if (upgrade == null) continue;
                    elements[j] = new UpgradeCursorElement()
                    {
                        Node = upgrade,
                        Action = () => BuyUpgrade(upgrade, () => SwitchScreen(page, previous: true)),
                        Active = (x) => CanBuyUpgrade(((UpgradeCursorElement)x).Node)
                    };
                }
            }
            page = PageCursorElement<CursorElement>.Create(0, screens, cursorMenus);
            return page;
        }

        string GetCurrentSort()
        {
            int currentSort = currentCursorMenu.sortingIndex;
            return currentSort switch
            {
                0 => $"정렬 기준: 알파벳순 [{InteractiveTerminalAPI.Compat.InputUtils_Compat.ChangeApplicationSortingKey.GetBindingDisplayString()}]",
                1 => $"정렬 기준: 가격(오름차순) [{InteractiveTerminalAPI.Compat.InputUtils_Compat.ChangeApplicationSortingKey.GetBindingDisplayString()}]",
                2 => $"정렬 기준: 가격(내림차순) [{InteractiveTerminalAPI.Compat.InputUtils_Compat.ChangeApplicationSortingKey.GetBindingDisplayString()}]",
                _ => "",
            };
        }
        int CompareName(CursorElement cursor1, CursorElement cursor2)
        {
            if (cursor1 == null) return 1;
            if (cursor2 == null) return -1;
            UpgradeCursorElement element = cursor1 as UpgradeCursorElement;
            UpgradeCursorElement element2 = cursor2 as UpgradeCursorElement;
            string name1 = element.Node.Name;
            string name2 = element2.Node.Name;
            return name1.CompareTo(name2);
        }
        int CompareCurrentPriceReversed(CursorElement cursor1, CursorElement cursor2)
        {
            if (cursor1 == null) return 1;
            if (cursor2 == null) return -1;
            UpgradeCursorElement element = cursor1 as UpgradeCursorElement;
            UpgradeCursorElement element2 = cursor2 as UpgradeCursorElement;
            int currentPrice1 = element.Node.Unlocked && element.Node.CurrentUpgrade >= element.Node.MaxUpgrade ? int.MinValue : element.Node.GetCurrentPrice();
            int currentPrice2 = element2.Node.Unlocked && element2.Node.CurrentUpgrade >= element2.Node.MaxUpgrade ? int.MinValue : element2.Node.GetCurrentPrice();
            return currentPrice2.CompareTo(currentPrice1);
        }
        int CompareCurrentPrice(CursorElement cursor1, CursorElement cursor2)
        {
            if (cursor1 == null) return 1;
            if (cursor2 == null) return -1;
            UpgradeCursorElement element = cursor1 as UpgradeCursorElement;
            UpgradeCursorElement element2 = cursor2 as UpgradeCursorElement;
            int currentPrice1 = element.Node.Unlocked && element.Node.CurrentUpgrade >= element.Node.MaxUpgrade ? int.MaxValue : element.Node.GetCurrentPrice();
            int currentPrice2 = element2.Node.Unlocked && element2.Node.CurrentUpgrade >= element2.Node.MaxUpgrade ? int.MaxValue : element2.Node.GetCurrentPrice();
            return currentPrice1.CompareTo(currentPrice2);
        }
        static bool CanBuyUpgrade(CustomTerminalNode node)
        {
            if (UpgradeBus.Instance.PluginConfiguration.ALTERNATIVE_ITEM_PROGRESSION && UpgradeBus.Instance.PluginConfiguration.ITEM_PROGRESSION_NO_PURCHASE_UPGRADES) return false;
            if (UpgradeBus.Instance.PluginConfiguration.BuyableUpgradeOnce && UpgradeBus.Instance.lockedUpgrades.Keys.Contains(node)) return false;
            if (MaximumIndividualUpgradeCheck(node)) return false;

			if (node.Refundable && node.Unlocked) return true;
            bool maxLevel = node.CurrentUpgrade >= node.MaxUpgrade;
            if (maxLevel && node.Unlocked)
                return false;

            int groupCredits = UpgradeBus.Instance.GetTerminal().groupCredits;
            int price = node.GetCurrentPrice();
            bool canBeBoughtWithGroupCredits = groupCredits >= price;

            if (!node.AlternateCurrency) return canBeBoughtWithGroupCredits;

            int playerCredits = CurrencyManager.Instance.CurrencyAmount;
            int playerPrice = CurrencyManager.Instance.GetCurrencyAmountFromCredits(price);
            bool canBeBoughtWithPlayerCredits = playerCredits >= playerPrice;
            switch (node.PurchaseMode)
            {
                case PurchaseMode.Both: return canBeBoughtWithGroupCredits || canBeBoughtWithPlayerCredits;
                case PurchaseMode.CompanyCredits: return canBeBoughtWithGroupCredits;
                case PurchaseMode.AlternateCurrency: return canBeBoughtWithPlayerCredits;
                default: return false;
            }
        }

        static bool CanBuyUpgradeWithGroupCredits(CustomTerminalNode node)
        {
            if (UpgradeBus.Instance.PluginConfiguration.ALTERNATIVE_ITEM_PROGRESSION && UpgradeBus.Instance.PluginConfiguration.ITEM_PROGRESSION_NO_PURCHASE_UPGRADES) return true;
            bool maxLevel = node.CurrentUpgrade >= node.MaxUpgrade;
            if (maxLevel && node.Unlocked)
                return false;

            int groupCredits = UpgradeBus.Instance.GetTerminal().groupCredits;
            int price = node.GetCurrentPrice();
            bool canBeBoughtWithGroupCredits = groupCredits >= price;
            return canBeBoughtWithGroupCredits;
        }

        static bool MaximumIndividualUpgradeCheck(CustomTerminalNode node)
        {
            return !node.SharedUpgrade && (!node.Unlocked && UpgradeBus.Instance.PluginConfiguration.MaximumIndividualUpgrades > 0 && UpgradeApi.GetUpgradeNodes().Where(x => !x.SharedUpgrade && x.Unlocked).Count() >= UpgradeBus.Instance.PluginConfiguration.MaximumIndividualUpgrades);

		}

        static bool CanBuyUpgradeWithPlayerCredits(CustomTerminalNode node)
        {
            if (UpgradeBus.Instance.PluginConfiguration.ALTERNATIVE_ITEM_PROGRESSION && UpgradeBus.Instance.PluginConfiguration.ITEM_PROGRESSION_NO_PURCHASE_UPGRADES) return true;
            bool maxLevel = node.CurrentUpgrade >= node.MaxUpgrade;
            if (maxLevel && node.Unlocked)
                return false;

            int price = node.GetCurrentPrice();

            int playerCredits = CurrencyManager.Instance.CurrencyAmount;
            int playerPrice = CurrencyManager.Instance.GetCurrencyAmountFromCredits(price);
            bool canBeBoughtWithPlayerCredits = playerCredits >= playerPrice;
            return canBeBoughtWithPlayerCredits;
        }
        public void BuyUpgrade(CustomTerminalNode node, Action backAction)
        {
            int groupCredits = UpgradeBus.Instance.GetTerminal().groupCredits;
            StringBuilder discoveredItems = new();
            List<string> items = ItemProgressionManager.GetDiscoveredItems(node);
            if (items.Count > 0)
            {
                discoveredItems.Append("\n\nDiscovered items: ");
                discoveredItems.Append(string.Join(",", items));
            }
            string finalText = node.Description + discoveredItems;
            bool maxLevel = node.CurrentUpgrade >= node.MaxUpgrade;
            if (maxLevel && node.Unlocked && !node.Refundable)
            {
                ErrorMessage(node.Name, finalText, backAction, LguConstants.REACHED_MAX_LEVEL);
                return;
            }
            int price = node.GetCurrentPrice();
            switch(node.PurchaseMode)
            {
                case PurchaseMode.CompanyCredits:
                    {
                        if (groupCredits < price && !node.Refundable)
                        {
                            ErrorMessage(node.Name, finalText, backAction, LguConstants.NOT_ENOUGH_CREDITS);
                            return;
                        }
                        break;
                    }
                case PurchaseMode.AlternateCurrency:
                    {
                        if (!node.AlternateCurrency && !node.Refundable)
                        {
                            ErrorMessage(node.Name, finalText, backAction, LguConstants.NOT_ENOUGH_CREDITS);
                            return;
                        }

                        int currencyPrice = CurrencyManager.Instance.GetCurrencyAmountFromCredits(price);
                        int playerCredits = CurrencyManager.Instance.CurrencyAmount;
                        if (playerCredits < currencyPrice && !node.Refundable)
                        {
                            ErrorMessage(node.Name, finalText, backAction, LguConstants.NOT_ENOUGH_CREDITS);
                            return;
                        }
                        break;
                    }
                case PurchaseMode.Both:
                    {
                        if (groupCredits >= price) break;

                        if (!node.AlternateCurrency && !node.Refundable)
                        {
                            ErrorMessage(node.Name, finalText, backAction, LguConstants.NOT_ENOUGH_CREDITS);
                            return;
                        }

                        int currencyPrice = CurrencyManager.Instance.GetCurrencyAmountFromCredits(price);
                        int playerCredits = CurrencyManager.Instance.CurrencyAmount;
                        if (playerCredits < currencyPrice && !node.Refundable)
                        {
                            ErrorMessage(node.Name, finalText, backAction, LguConstants.NOT_ENOUGH_CREDITS);
                            return;
                        }
                        break;
                    }
            }
            if (UpgradeBus.Instance.PluginConfiguration.BuyableUpgradeOnce && UpgradeBus.Instance.lockedUpgrades.Keys.Contains(node))
            {
                ErrorMessage(node.Name, finalText, backAction, LguConstants.LOCKED_UPGRADE);
                return;
            }
            if (UpgradeBus.Instance.PluginConfiguration.ALTERNATIVE_ITEM_PROGRESSION && UpgradeBus.Instance.PluginConfiguration.ITEM_PROGRESSION_NO_PURCHASE_UPGRADES)
            {
                ErrorMessage(node.Name, finalText, backAction, " ");
                return;
			}
			if (MaximumIndividualUpgradeCheck(node))
			{
				ErrorMessage(node.Name, finalText, backAction, $"허용된 개인 업그레이드 구매 한도를 초과했습니다. ({UpgradeBus.Instance.PluginConfiguration.MaximumIndividualUpgrades.Value})");
				return;
			}
			CursorElement[] elements;
            if (node.AlternateCurrency)
            {
                switch(node.PurchaseMode)
                {
                    case PurchaseMode.Both:
                        {
                            elements = [
                                CursorElement.Create("회사 크레딧으로 구매", "", () => ConfirmPurchaseUpgrade(node, price, backAction), active: (_) => CanBuyUpgradeWithGroupCredits(node), selectInactive: false),
                                CursorElement.Create("플레이어 크레딧으로 구매", "", () => ConfirmPurchaseUpgradeAlternateCurrency(node, CurrencyManager.Instance.GetCurrencyAmountFromCredits(price), backAction), active: (_) => CanBuyUpgradeWithPlayerCredits(node), selectInactive: false),
								CursorElement.Create("회사 크레딧에 대한 환불 업그레이드 레벨", "", () => ConfirmRefundUpgradeLevel(node,PurchaseMode.CompanyCredits, backAction), (_) => CanRefundUpgradeLevel(node), selectInactive: false),
								CursorElement.Create("플레이어 크레딧으로 업그레이드 레벨 환불", "", () => ConfirmRefundUpgradeLevel(node,PurchaseMode.AlternateCurrency, backAction), (_) => CanRefundUpgradeLevel(node), selectInactive: false),
                                CursorElement.Create("취소", "", backAction)
                                ];
                            break;
                        }
                    case PurchaseMode.AlternateCurrency:
                        {
                            elements = [
                                CursorElement.Create("플레이어 크레딧으로 구매", "", () => ConfirmPurchaseUpgradeAlternateCurrency(node, CurrencyManager.Instance.GetCurrencyAmountFromCredits(price), backAction), active: (_) => CanBuyUpgradeWithPlayerCredits(node), selectInactive: false),
								CursorElement.Create("환불 업그레이드 레벨", "", () => ConfirmRefundUpgradeLevel(node, node.PurchaseMode, backAction), (_) => CanRefundUpgradeLevel(node), selectInactive: false),
								CursorElement.Create("취소", "", backAction)
                                ];
                            break;
                        }
                    case PurchaseMode.CompanyCredits:
                    default:
                        {
                            elements = [
                                CursorElement.Create("회사 크레딧으로 구매", "", () => ConfirmPurchaseUpgrade(node, price, backAction), active: (_) => CanBuyUpgradeWithGroupCredits(node), selectInactive: false),
								CursorElement.Create("환불 업그레이드 수준", "", () => ConfirmRefundUpgradeLevel(node, node.PurchaseMode, backAction), (_) => CanRefundUpgradeLevel(node), selectInactive: false),
								CursorElement.Create("취소", "", backAction)
                                ];
                            break;
                        }
                }
            }
            else
            {
                elements = [
                    CursorElement.Create("회사 크레딧으로 구매", "", () => ConfirmPurchaseUpgrade(node, price, backAction), active: (_) => CanBuyUpgradeWithGroupCredits(node), selectInactive: false),
								CursorElement.Create("환불 업그레이드 수준", "", () => ConfirmRefundUpgradeLevel(node, PurchaseMode.CompanyCredits, backAction), (_) => CanRefundUpgradeLevel(node), selectInactive: false),
					CursorElement.Create("취소", "", backAction)
                    ];
            }
            CursorMenu<CursorElement> cursorMenu = CursorMenu<CursorElement>.Create(elements.Length-1, '>', elements);
            ITextElement[] elements2 =
            {
            TextElement.Create(finalText),
            TextElement.Create(" "),
            cursorMenu
            };
            IScreen screen = BoxedScreen.Create(node.Name, elements2);
            SwitchScreen(screen, cursorMenu, previous: false);
        }

		private void ConfirmRefundUpgradeLevel(CustomTerminalNode node, PurchaseMode refundMode, Action backAction)
		{
            if (!node.Refundable)
			{
				ErrorMessage(node.Name, backAction, "현재 설정으로는 이 업그레이드에 대한 환불이 불가능합니다.");
				return;
			}
            if (!node.Unlocked)
            {
				ErrorMessage(node.Name, backAction, "구매하신 업그레이드에 대해서만 환불이 가능합니다.");
				return;
			}

			Confirm(node.Name, "이번 업그레이드에서 레벨을 환불받으시겠습니까?", () => RefundUpgrade(node, refundMode, backAction), backAction);
		}

		private void RefundUpgrade(CustomTerminalNode node, PurchaseMode refundMode, Action backAction)
		{
            int price = node.GetPreviousPrice();
            switch(refundMode)
            {
                case PurchaseMode.CompanyCredits:
                {
					LguStore.Instance.SyncCreditsServerRpc(terminal.groupCredits + Mathf.CeilToInt(price * Mathf.Clamp01(node.RefundPercentage)));
                    break;
				}
                case PurchaseMode.AlternateCurrency:
                {
                        int credits = Mathf.CeilToInt(price * Mathf.Clamp01(node.RefundPercentage));
                        int currency = CurrencyManager.Instance.GetCurrencyAmountFromCredits(credits);
                        CurrencyManager.Instance.AddCurrencyAmount(currency, trackSpent: true);
                        break;
				}
                default:
                break;
            }
			
			UpgradeApi.TriggerUpgradeDowngrade(node);
			backAction();
		}

		private bool CanRefundUpgradeLevel(CustomTerminalNode node)
		{
            return node.Refundable && node.Unlocked;
		}

		void ConfirmPurchaseUpgrade(CustomTerminalNode node, int price, Action backAction)
        {
            int groupCredits = UpgradeBus.Instance.GetTerminal().groupCredits;
            if (groupCredits < price)
            {
                ErrorMessage(node.Name, backAction, LguConstants.NOT_ENOUGH_CREDITS);
                return;
            }
            Confirm(node.Name, string.Format(LguConstants.PURCHASE_UPGRADE_FORMAT, price), () => PurchaseUpgrade(node, price, backAction), backAction);
        }
        void ConfirmPurchaseUpgradeAlternateCurrency(CustomTerminalNode node, int currencyPrice, Action backAction)
        {
            int playerCredits = CurrencyManager.Instance.CurrencyAmount;
            if (playerCredits < currencyPrice)
            {
                ErrorMessage(node.Name, backAction, LguConstants.NOT_ENOUGH_CREDITS);
                return;
            }
            Confirm(node.Name, string.Format(LguConstants.PURCHASE_UPGRADE_ALTERNATE_FORMAT, currencyPrice), () => PurchaseUpgradeAlternateCurrency(node, currencyPrice, backAction), backAction);
        }
        void PurchaseUpgradeAlternateCurrency(CustomTerminalNode node, int currencyPrice, Action backAction)
        {
            CurrencyManager.Instance.RemoveCurrencyAmount(currencyPrice, trackSpent: true);
            if (!node.Unlocked)
            {
                LguStore.Instance.HandleUpgrade(node);
            }
            else if (node.Unlocked && node.MaxUpgrade > node.CurrentUpgrade)
            {
                LguStore.Instance.HandleUpgrade(node, true);
            }
            backAction();
        }
        void PurchaseUpgrade(CustomTerminalNode node, int price, Action backAction)
        {
            LguStore.Instance.SyncCreditsServerRpc(terminal.groupCredits - price);
            LguStore.Instance.AddUpgradeSpentCreditsServerRpc(price);
            UpgradeApi.TriggerUpgradeRankup(node);
            backAction();
        }
    }
}
