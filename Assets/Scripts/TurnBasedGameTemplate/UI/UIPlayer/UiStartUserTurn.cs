using System.Collections;
using TurnBasedGameTemplate.GameEvents;
using TurnBasedGameTemplate.Model.Player;
using TurnBasedGameTemplate.UI;
using UnityEngine;

namespace TurnBasedGameTemplate.UI
{
    [RequireComponent(typeof(IUiUserInput))]
    [RequireComponent(typeof(IUiPlayer))]
    public class UiStartUserTurn : UiListener, IStartPlayerTurn
    {
        const float DelayToEnableInput = 2;
        IUiUserInput UserInput { get; set; }
        IUiPlayer Ui { get; set; }

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IStartPlayerTurn.OnStartPlayerTurn(IPlayer player)
        {
            var isMyTurn = Ui.PlayerController.IsMyTurn;
            var isUser = Ui.PlayerController.IsUser;
            var notAi = !Ui.PlayerController.IsAi;

            if (isMyTurn && isUser && notAi)
                StartCoroutine(EnableInput());
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        IEnumerator EnableInput()
        {
            yield return new WaitForSeconds(DelayToEnableInput);
            UserInput.Enable();
        }

        void Awake()
        {
            Ui = GetComponentInParent<IUiPlayer>();
            UserInput = GetComponent<IUiUserInput>();
        }
    }
}