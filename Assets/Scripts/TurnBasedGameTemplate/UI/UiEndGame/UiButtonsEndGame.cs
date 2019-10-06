using TurnBasedGameTemplate.UI;
using UnityEngine;

namespace TurnBasedGameTemplate.UI
{
    [RequireComponent(typeof(IRestartGameHandler))]
    public class UiButtonsEndGame : MonoBehaviour,
        IButtonHandler,
        UiButtonRestart.IPressRestart
    {
        IRestartGameHandler PlayerHandler { get; set; }

        void UiButtonRestart.IPressRestart.PressRestart()
        {
            PlayerHandler.RestartGame();
        }

        void Awake()
        {
            PlayerHandler = GetComponent<IRestartGameHandler>();

            var buttons = gameObject.GetComponentsInChildren<UiButton>();
            foreach (var button in buttons)
                button.SetHandler(this);
        }
    }
}