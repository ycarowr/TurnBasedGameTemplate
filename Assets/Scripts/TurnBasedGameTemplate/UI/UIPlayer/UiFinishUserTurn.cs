using TurnBasedGameTemplate.GameEvents;
using TurnBasedGameTemplate.Model.Player;
using TurnBasedGameTemplate.Tools.Patterns.GameEvents;
using UnityEngine;

namespace TurnBasedGameTemplate.UI
{
    [RequireComponent(typeof(IUiUserInput))]
    [RequireComponent(typeof(IUiPlayer))]
    public class UiFinishUserTurn : UiGameEventListener, IFinishPlayerTurn
    {
        IUiUserInput UserInput { get; set; }
        IUiPlayer Ui { get; set; }

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IFinishPlayerTurn.OnFinishPlayerTurn(IPlayer player)
        {
            if (Ui.PlayerController.IsUser)
                UserInput.Disable();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        void Awake()
        {
            Ui = GetComponent<IUiPlayer>();
            UserInput = GetComponent<IUiUserInput>();
        }
    }
}