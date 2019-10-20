using System.Collections;
using TurnBasedGameTemplate;
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
        const float DelayToEnable = 1f;
        IUiUserInput UserInput { get; set; }

        void IFinishGame.OnFinishGame(IPlayer winner) => StartCoroutine(EnableInput());
        void IRestartGameHandler.RestartGame() => Controller.RestartGameImmediately();

        void IStartGame.OnStartGame(IPlayer starter) => UserInput.Disable();
        public IGameController Controller => TurnBasedGameTemplate.GameController.Instance;

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
    }
}