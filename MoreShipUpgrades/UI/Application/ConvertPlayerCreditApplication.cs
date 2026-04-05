using InteractiveTerminalAPI.UI;
using InteractiveTerminalAPI.UI.Application;
using InteractiveTerminalAPI.UI.Cursor;
using InteractiveTerminalAPI.UI.Screen;
using MoreShipUpgrades.Managers;
using System;

namespace MoreShipUpgrades.UI.Application
{
    internal class ConvertPlayerCreditApplication : InteractiveCounterApplication<CursorCounterElement>
    {
        const string TITLE = "플레이어 크레딧 전환";
        public override void Initialization()
        {
            CursorCounterElement[] cursorCounterElements = new CursorCounterElement[3];
			CursorMenu<CursorCounterElement> cursorCounterMenu = CursorMenu<CursorCounterElement>.Create(cursorCounterElements.Length - 1, '>', cursorCounterElements);
            ITextElement[] textElements =
                [
                    new TextElement()
                    {
                        Text = $"어떤 변환 작업을 실행하시겠습니까?"
                    },
                    new TextElement()
                    {
                        Text = ""
                    },
                    cursorCounterMenu
                ];
            IScreen screen = BoxedScreen.Create(TITLE, textElements);
            cursorCounterElements[0] = new CursorCounterElement()
            {
                Action = () => ConvertCreditsToPCsScreen(backAction: () => SwitchScreen(screen, cursorCounterMenu, previous: true)),
                Active = (_) => HasEnoughCreditsToConvert(),
                Name = "크레딧을 플레이어 크레딧(PC)으로 변환",
                SelectInactive = false
            };
            cursorCounterElements[1] = new CursorCounterElement()
            {
                Action = () => ConvertPCsToCreditsScreen(backAction: () => SwitchScreen(screen, cursorCounterMenu, previous: true)),
                Active = (_) => HasEnoughPCsToConvert(),
                Name = "플레이어 크레딧(PC)을 일반 크레딧으로 변환",
                SelectInactive = false
            };
            cursorCounterElements[2] = new CursorCounterElement()
            {
                Action = () => UnityEngine.Object.Destroy(InteractiveTerminalManager.Instance.gameObject),
                Active = (_) => true,
                Name = "뒤로가기",
                SelectInactive = false
            };

            currentCursorMenu = cursorCounterMenu;
            currentScreen = screen;
        }

        private void ConvertPCsToCreditsScreen(Action backAction)
        {
            CursorOutputElement<string>[] cursorCounterElements = new CursorOutputElement<string>[2];
            Func<int, string>[] array = new Func<int, string>[1];
            array[0] = (int x) => $"{x} PCs";
			CursorMenu<CursorCounterElement> cursorCounterMenu = CursorMenu<CursorCounterElement>.Create(cursorCounterElements.Length - 1, '>', cursorCounterElements);
            IScreen screen = BoxedOutputScreen<string, string>.Create(TITLE, [cursorCounterMenu], input: () => $"${CurrencyManager.Instance.GetCreditsFromCurrencyAmountConversion(cursorCounterElements[0].Counter)}", output: (string x) => x);
            cursorCounterElements[0] = new CursorOutputElement<string>()
            {
                Action = () => TryConvertPCsToCredits(cursorCounterElements[0], backAction: () => SwitchScreen(screen, cursorCounterMenu, previous: true)),
                Active = (x) => HasEnoughPCsToConvert(((CursorCounterElement)x).Counter),
                Name = "변환할 PC 수량",
                SelectInactive = true,
                Func = array[0],
            };
            cursorCounterElements[1] = new CursorOutputElement<string>()
            {
                Action = backAction,
                Active = (_) => true,
                Name = "뒤로가기",
                SelectInactive = false,
                Func = (_) => "",
            };

            currentCursorMenu = cursorCounterMenu;
            currentScreen = screen;
        }

        private void TryConvertPCsToCredits(CursorOutputElement<string> cursorOutputElement, Action backAction)
        {
            int count = cursorOutputElement.Counter;
            if (CurrencyManager.Instance.CurrencyAmount < count)
            {
                ErrorMessage(title: TITLE, description: "", backAction, error: "변환 작업을 수행하기에 PC가 충분하지 않습니다.");
                return;
            }
            LguStore.Instance.SyncCreditsServerRpc(terminal.groupCredits + CurrencyManager.Instance.GetCreditsFromCurrencyAmountConversion(count));
            CurrencyManager.Instance.RemoveCurrencyAmount(count);
            backAction();
        }
        private void TryConvertCreditsToPCs(CursorOutputElement<string> cursorOutputElement, Action backAction)
        {
            int count = cursorOutputElement.Counter;
			if (CurrencyManager.Instance.BlockExceedOperations(count))
			{
				ErrorMessage(title: TITLE, description: "", backAction, error: "요청 금액이 설정된 대체 통화 단위의 최대 한도를 초과했습니다.");
				return;
			}
			int requiredCredits = CurrencyManager.Instance.GetRequiredCreditsFromCurrencyConversion(count);

			if (terminal.groupCredits < requiredCredits)
            {
                ErrorMessage(title: TITLE, description: "", backAction, error: "전환을 수행하기에 회사 크레딧이 부족합니다.");
                return;
            }
            LguStore.Instance.SyncCreditsServerRpc(terminal.groupCredits - requiredCredits);
            CurrencyManager.Instance.AddCurrencyAmount(count);
            backAction();
        }

        const int MINIMUM_PC = 1;
        private bool HasEnoughCreditsToConvert(int amount = MINIMUM_PC)
        {
            if (CurrencyManager.Instance.BlockExceedOperations(amount)) return false;
            return terminal.groupCredits >= CurrencyManager.Instance.GetRequiredCreditsFromCurrencyConversion(amount);
        }

        private bool HasEnoughPCsToConvert(int amount = 0)
        {
            return CurrencyManager.Instance.CurrencyAmount != 0 && CurrencyManager.Instance.CurrencyAmount >= amount;
        }

        private void ConvertCreditsToPCsScreen(Action backAction)
        {
            CursorOutputElement<string>[] cursorCounterElements = new CursorOutputElement<string>[2];
            Func<int, string>[] array = new Func<int, string>[1];
            array[0] = (int x) => $"${CurrencyManager.Instance.GetRequiredCreditsFromCurrencyConversion(cursorCounterElements[0].Counter)}";
            CursorMenu<CursorCounterElement> cursorCounterMenu = CursorMenu<CursorCounterElement>.Create(cursorCounterElements.Length - 1, '>', cursorCounterElements);
            IScreen screen = BoxedOutputScreen<string, string>.Create(TITLE, [cursorCounterMenu], input: () => $"{cursorCounterElements[0].Counter} PC", output: (string x) => x);
            cursorCounterElements[0] = new CursorOutputElement<string>()
            {
                Action = () => TryConvertCreditsToPCs(cursorCounterElements[0], backAction: () => SwitchScreen(screen, cursorCounterMenu, previous: true)),
                Active = (x) => HasEnoughCreditsToConvert(((CursorCounterElement)x).Counter),
                Name = "변환할 크레딧 금액",
                SelectInactive = true,
                Func = array[0],
            };
            cursorCounterElements[1] = new CursorOutputElement<string>()
            {
                Action = backAction,
                Active = (_) => true,
                Name = "뒤로가기",
                SelectInactive = false,
                Func = (_) => "",
            };

            currentCursorMenu = cursorCounterMenu;
            currentScreen = screen;
        }
        protected void Confirm(string title, string description, Action confirmAction, Action declineAction, string additionalMessage = "")
        {
            CursorCounterElement[] elements =
            [
            CursorCounterElement.Create("수락", "", confirmAction, showCounter: false),
            CursorCounterElement.Create("거부", "", declineAction, showCounter: false)
            ];
			CursorMenu<CursorCounterElement> cursorMenu = CursorMenu<CursorCounterElement>.Create(0, '>', elements);
            ITextElement[] elements2 =
            [
            TextElement.Create(description),
            TextElement.Create(" "),
            TextElement.Create(additionalMessage),
            cursorMenu
            ];
            IScreen screen = BoxedScreen.Create(title, elements2);
            SwitchScreen(screen, cursorMenu, previous: false);
        }
        protected void ErrorMessage(string title, string description, Action backAction, string error)
        {
            CursorCounterElement[] elements = [CursorCounterElement.Create("뒤로가기", "", backAction, showCounter: false)];
			CursorMenu<CursorCounterElement> cursorMenu = CursorMenu<CursorCounterElement>.Create(0, '>', elements);
            ITextElement[] elements2 =
            [
            TextElement.Create(description),
            TextElement.Create(" "),
            TextElement.Create(error),
            TextElement.Create(" "),
            cursorMenu
            ];
            IScreen screen = BoxedScreen.Create(title, elements2);
            SwitchScreen(screen, cursorMenu, previous: false);
        }
    }
}
