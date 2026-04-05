using GameNetcodeStuff;
using InteractiveTerminalAPI.UI;
using InteractiveTerminalAPI.UI.Application;
using InteractiveTerminalAPI.UI.Cursor;
using InteractiveTerminalAPI.UI.Page;
using InteractiveTerminalAPI.UI.Screen;
using MoreShipUpgrades.Managers;
using System;
using System.Linq;

namespace MoreShipUpgrades.UI.Application
{
    internal class TradePlayerCreditsApplication : PageApplication<CursorElement>
    {
        const string MAIN_SCREEN_TITLE = "플레이어 크레딧 거래";
        const string NO_PLAYERS_TO_TRADE_TEXT = "플레이어 크레딧을 교환할 수 있는 플레이어가 없습니다.";
        const string NO_PLAYER_CREDITS_TO_TRADE_TEXT = "현재 거래에 사용할 수 있는 선수 크레딧이 없습니다.";

        const string TRADE_PLAYER_TEXT = "선택한 플레이어에게 얼마만큼의 플레이어 크레딧을 제공하시겠습니까?";
        const string TRADE_CREDITS_INFO_TEXT = "플레이어 크레딧을 제공할 플레이어를 선택하세요:";
        const string CONFIRM_TRADE_PLAYER_TEXT = "{0} 플레이어 크레딧을 {1}로 교환하시겠습니까?";
        public override void Initialization()
        {
            PlayerControllerB[] activePlayers = StartOfRound.Instance.allPlayerScripts.Where(x => (x.isPlayerControlled || x.isPlayerDead) && x != GameNetworkManager.Instance.localPlayerController).ToArray();
            if (activePlayers.Length == 0)
            {
                CursorElement[] elements =
                [
                    CursorElement.Create(name: "떠나기", action: () => UnityEngine.Object.Destroy(InteractiveTerminalManager.Instance)),
                ];
                CursorMenu<CursorElement> cursorMenu = CursorMenu<CursorElement>.Create(startingCursorIndex: 0, elements: elements);
                IScreen screen = new BoxedScreen()
                {
                    Title = MAIN_SCREEN_TITLE,
                    elements =
                    [
                        new TextElement()
                        {
                            Text = NO_PLAYERS_TO_TRADE_TEXT,
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
            if (CurrencyManager.Instance.CurrencyAmount <= 0)
            {
                CursorElement[] elements =
                [
                    CursorElement.Create(name: "떠나기", action: () => UnityEngine.Object.Destroy(InteractiveTerminalManager.Instance)),
                ];
                CursorMenu<CursorElement> cursorMenu = CursorMenu<CursorElement>.Create(startingCursorIndex: 0, elements: elements);
                IScreen screen = new BoxedScreen()
                {
                    Title = MAIN_SCREEN_TITLE,
                    elements =
                    [
                        new TextElement()
                        {
                            Text = NO_PLAYER_CREDITS_TO_TRADE_TEXT,
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
            (PlayerControllerB[][], BaseCursorMenu<CursorElement>[], IScreen[]) entries = GetPageEntries(activePlayers);

            PlayerControllerB[][] pagesPlayers = entries.Item1;
            BaseCursorMenu<CursorElement>[] cursorMenus = entries.Item2;
            IScreen[] screens = entries.Item3;
            PageCursorElement<CursorElement> page = null;
            for (int i = 0; i < pagesPlayers.Length; i++)
            {
                PlayerControllerB[] players = pagesPlayers[i];
                CursorElement[] cursorElements = new CursorElement[players.Length];
                cursorMenus[i] = CursorMenu<CursorElement>.Create(startingCursorIndex: 0, elements: cursorElements);
                BaseCursorMenu<CursorElement> cursorMenu = cursorMenus[i];
                screens[i] = new BoxedScreen()
                {
                    Title = MAIN_SCREEN_TITLE,
                    elements =
                    [
                        new TextElement()
                        {
                            Text = TRADE_CREDITS_INFO_TEXT,
                        },
                        new TextElement()
                        {
                            Text = " "
                        },
                        cursorMenu,
                    ],
                };

                for (int j = 0; j < players.Length; j++)
                {
                    PlayerControllerB player = players[j];
                    if (player == null) continue;
                    cursorElements[j] = new CursorElement()
                    {
                        Name = player.playerUsername,
                        Action = () => TradePlayerCredits(player, () => SwitchScreen(page, previous: true)),
                    };
                }
            }
            page = PageCursorElement<CursorElement>.Create(0, screens, cursorMenus);
            initialPage = page;
            currentPage = initialPage;
            currentCursorMenu = currentPage.GetCurrentCursorMenu();
            currentScreen = currentPage.GetCurrentScreen();

        }

        void TradePlayerCredits(PlayerControllerB tradingPlayer, Action backAction)
        {
            int playerCredits = CurrencyManager.Instance.CurrencyAmount;
            CursorElement[] elements =
                {
                CursorElement.Create("1명에게 크레딧 주기", "", () => ConfirmTradePlayerCredits(tradingPlayer, 1, backAction), selectInactive: false),
                CursorElement.Create("5명에게 크레딧 주기", "", () => ConfirmTradePlayerCredits(tradingPlayer, 5, backAction), active: (_) => playerCredits >= 5, selectInactive: false),
                CursorElement.Create("모든 플레이어에게 크레딧 주기", "", () => ConfirmTradePlayerCredits(tradingPlayer, playerCredits, backAction), selectInactive: false),
                CursorElement.Create("취소", "", backAction)
                };
            CursorMenu<CursorElement> cursorMenu = CursorMenu<CursorElement>.Create(0, '>', elements);
            ITextElement[] elements2 =
            {
                TextElement.Create(TRADE_PLAYER_TEXT),
                TextElement.Create(" "),
                cursorMenu
                };
            IScreen screen = BoxedScreen.Create(tradingPlayer.playerUsername, elements2);
            SwitchScreen(screen, cursorMenu, previous: false);
        }

        void ConfirmTradePlayerCredits(PlayerControllerB tradingPlayer, int playerCreditAmount,  Action backAction)
        {
            Confirm(tradingPlayer.playerUsername, string.Format(CONFIRM_TRADE_PLAYER_TEXT, playerCreditAmount, tradingPlayer.playerUsername), () => ExecuteTrade(tradingPlayer, playerCreditAmount, backAction), backAction);
        }

        void ExecuteTrade(PlayerControllerB tradingPlayer, int playerCreditAmount, Action backAction)
        {
            CurrencyManager.Instance.RemoveCurrencyAmount(playerCreditAmount);
            CurrencyManager.Instance.TradePlayerCreditsServerRpc(tradingPlayer.actualClientId, playerCreditAmount);
            if (CurrencyManager.Instance.CurrencyAmount <= 0)
                UnityEngine.Object.Destroy(InteractiveTerminalManager.Instance);
            else backAction();
        }
    }
}
