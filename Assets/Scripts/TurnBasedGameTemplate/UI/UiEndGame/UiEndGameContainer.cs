using System.Collections;
using TurnBasedGameTemplate.GameController;
using TurnBasedGameTemplate.GameEvents;
using TurnBasedGameTemplate.Model.Player;
using TurnBasedGameTemplate.Tools.Patterns.GameEvents;
using UnityEngine;

namespace TurnBasedGameTemplate.UI
{
    public interface IRestartGameHandler
    {
        void RestartGame();
    }

    /// <summary> End game HUD. Solves model dependencies accessing the game controller via Singleton. </summary>
    [RequireComponent(typeof(IUiUserInput))]
    public class UiEndGameContainer : UiGameEventListener,
        IRestartGameHandler,
        IFinishGame,
        IStartGame,
        IUiController
    {
        void IRestartGameHandler.RestartGame() => Controller.RestartGameImmediately();

        void Awake()
        {
            //user input
            UserInput = gameObject.AddComponent<UiUserInput>();

            //HUD end game
            gameObject.AddComponent<UiButtonsEndGame>();
        }

        IEnumerator EnableInput()
        {
            yield return new WaitForSeconds(DelayToEnable);
            UserInput.Enable();
        }

        const float DelayToEnable = 1f;
        IUiUserInput UserInput { get; set; }
        public IGameController Controller => GameController.GameController.Instance;

        void IFinishGame.OnFinishGame(IPlayer winner) => StartCoroutine(EnableInput());

        void IStartGame.OnStartGame(IPlayer starter) => UserInput.Disable();
    }
}