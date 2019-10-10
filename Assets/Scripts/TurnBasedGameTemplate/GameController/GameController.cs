using TurnBasedGameTemplate.Configurations;
using TurnBasedGameTemplate.GameData;
using TurnBasedGameTemplate.GameEvents;
using TurnBasedGameTemplate.Model.Player;
using TurnBasedGameTemplate.Model.TurnBasedFSM;
using TurnBasedGameTemplate.Tools.Attributes;
using TurnBasedGameTemplate.Tools.Patterns.Observer;
using TurnBasedGameTemplate.Tools.Patterns.Singleton;
using UnityEngine;

namespace TurnBasedGameTemplate.GameController
{
    /// <summary>
    ///     Main Controller. Holds the FSM which controls the game flow. Also provides access to the players
    ///     controllers.TODO: Get rid of the Singleton??
    /// </summary>
    public class GameController : SingletonMB<GameController>, IGameController
    {
        [SerializeField] GameParameters gameParameters;
        [SerializeField] Observer GameEvents;

        void Start() => StartBattle();

        /// <summary>  All the game data. Access via Singleton Pattern. </summary>
        public IGameData Data => GameData.GameData.Instance;

        /// <summary>  State machine that holds the game logic. </summary>
        TurnBasedFsm TurnBasedLogic { get; set; }

        /// <summary>  Handler for the state machine. Used to dispatch coroutines. </summary>
        public MonoBehaviour MonoBehaviour => this;
        
        /// <summary>  Return the User Player. </summary>
        public IPlayerTurn GetUser() => GetPlayerController(gameParameters.Profiles.UserSeat);

        /// <summary>  Provides access to players controllers according to the player seat. </summary>
        public IPlayerTurn GetPlayerController(PlayerSeat seat) => TurnBasedLogic.GetPlayerController(seat);

        /// <summary>  Start the battle. Called only once after being initialized by the Bootstrapper. </summary>
        [Button]
        public void StartBattle()
        {
            TurnBasedLogic = new TurnBasedFsm(this, Data, gameParameters, GameEvents);
            TurnBasedLogic.StartBattle();
        }

        [Button]
        public void Win() => GameData.GameData.Instance.RuntimeGame.ForceWin(PlayerSeat.Bottom);

        [Button]
        public void Lose() => GameData.GameData.Instance.RuntimeGame.ForceWin(PlayerSeat.Top);

        [Button]
        public void RestartGameImmediately()
        {
            GameEvents.Notify<IRestartGame>(i => i.OnRestart());
            Data.CreateGame();
            StartBattle();
        }
    }
}