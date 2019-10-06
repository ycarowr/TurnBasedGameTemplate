using System.Collections.Generic;
using TurnBasedGameTemplate.GameController;
using TurnBasedGameTemplate.GameData;
using TurnBasedGameTemplate.Model.Player;
using TurnBasedGameTemplate.Tools.Patterns.StateMachine;

namespace TurnBasedGameTemplate.Model.TurnBasedFSM
{
    public class TurnBasedFsm : BaseStateMachine
    {
        //----------------------------------------------------------------------------------------------------------

        #region Properties

        /// <summary>  Register with all players states.</summary>
        readonly Dictionary<IPlayer, TurnState> actorsRegister =
            new Dictionary<IPlayer, TurnState>();

        /// <summary>  All Game Data.</summary>
        IGameData GameData { get; }

        /// <summary>  MonoBehavior which holds this FSM.</summary>
        public new IGameController Handler { get; }

        Configurations.Configurations Configurations { get; }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Initialization

        public TurnBasedFsm(IGameController handler, IGameData gameData, Configurations.Configurations configurations) :
            base(handler)
        {
            Configurations = configurations;
            Handler = handler;
            GameData = gameData;
            Initialize();
        }

        protected override void OnBeforeInitialize()
        {
            //create states
            var bottom = new BottomPlayerState(this, GameData, Configurations);
            var top = new TopPlayerState(this, GameData, Configurations);
            var start = new StartBattleState(this, GameData, Configurations);
            var end = new EndBattleState(this, GameData, Configurations);

            //register all states
            RegisterState(bottom);
            RegisterState(top);
            RegisterState(start);
            RegisterState(end);
        }

        /// <summary>  Register a player and his respective turn state.</summary>
        /// <param name="player"></param>
        /// <param name="state"></param>
        public void RegisterPlayerState(IPlayer player, TurnState state)
        {
            actorsRegister.Add(player, state);
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Operations

        /// <summary>  Returns the player controller according to its registered player.</summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public TurnState GetPlayerController(IPlayer player)
        {
            return IsInitialized && actorsRegister.ContainsKey(player) ? actorsRegister[player] : null;
        }

        /// <summary>  Returns a the player turn according to the position. Null if there isn't player registered with the argument.</summary>
        /// <param name="seat"></param>
        /// <returns></returns>
        public TurnState GetPlayerController(PlayerSeat seat)
        {
            foreach (var player in actorsRegister.Keys)
                if (player.Seat == seat)
                    return actorsRegister[player];

            return null;
        }

        /// <summary>  Call this method to Push Start Battle State and begin the match.</summary>
        public void StartBattle()
        {
            if (!IsInitialized)
                return;

            PopState();
            PushState<StartBattleState>();
        }

        /// <summary>  Call this method to Push End Battle State and Finish the match.</summary>
        public void EndBattle()
        {
            if (!IsInitialized)
                return;

            PopState();
            PushState<EndBattleState>();
        }

        #endregion
    }
}