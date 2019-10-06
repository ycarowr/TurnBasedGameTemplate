using System.Collections;
using TurnBasedGameTemplate.GameData;
using TurnBasedGameTemplate.GameEvents;
using TurnBasedGameTemplate.Model.Player;
using UnityEngine;

namespace TurnBasedGameTemplate.Model.TurnBasedFSM
{
    public class StartBattleState : BaseBattleState, IStartGame
    {
        //----------------------------------------------------------------------------------------------------------

        #region Constructor

        public StartBattleState(TurnBasedFsm fsm, IGameData gameData, Configurations.Configurations configurations) : base(fsm,
            gameData, configurations)
        {
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Operations

        public override void OnEnterState()
        {
            base.OnEnterState();
            //schedule pre game
            Fsm.Handler.MonoBehaviour.StartCoroutine(PreGameRoutine());

            //schedule start game
            Fsm.Handler.MonoBehaviour.StartCoroutine(StartGameRoutine());
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IStartGame.OnStartGame(IPlayer starter)
        {
            var nextState = Fsm.GetPlayerController(starter);
            Fsm.Handler.MonoBehaviour.StartCoroutine(NextStateRoutine(nextState));
        }

        IEnumerator NextStateRoutine(BaseBattleState nextState)
        {
            yield return new WaitForSeconds(Configurations.Timers.TimeUntilFirstPlayer);
            OnNextState(nextState);
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Coroutines

        IEnumerator PreGameRoutine()
        {
            yield return new WaitForSeconds(Configurations.Timers.TimeUntilPreGameEvent);
            GameData.RuntimeGame.PreStartGame();
        }

        IEnumerator StartGameRoutine()
        {
            var preGame = Configurations.Timers.TimeUntilPreGameEvent;
            var startGame = Configurations.Timers.TimeUntilStartGameEvent;
            var time = preGame + startGame;
            yield return new WaitForSeconds(time);
            GameData.RuntimeGame.StartGame();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}