using UnityEngine;

namespace TurnBasedGameTemplate.UI
{
    [RequireComponent(typeof(IUiUserInput))]
    [RequireComponent(typeof(IUiPlayer))]
    public class UiUserHudButtons : MonoBehaviour,
        UiButtonRandom.IPressPassTurn,
        UiButtonLose.IPressLose,
        UiButtonWin.IPressWin
    {
        IUiPlayer Ui { get; set; }
        IUiUserInput UserInput { get; set; }

        //----------------------------------------------------------------------------------------------------------

        #region Buttons

        void UiButtonRandom.IPressPassTurn.PressRandomMove()
        {
            if (Ui.PlayerController.PassTurn())
                DisableInput();
        }

        void UiButtonLose.IPressLose.PressLose()
        {
            Ui.Controller.Lose();
            DisableInput();
        }

        void UiButtonWin.IPressWin.PressWin()
        {
            Ui.Controller.Win();
            DisableInput();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Unity callback 

        void Awake()
        {
            UserInput = GetComponent<IUiUserInput>();
            Ui = GetComponent<IUiPlayer>();
            var buttons = gameObject.GetComponentsInChildren<UiButton>();
            foreach (var button in buttons)
                button.SetHandler(this);
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        void DisableInput() => UserInput.Disable();
    }
}