using System.Collections;
using TurnBasedGameTemplate.GameData;
using UnityEngine;

namespace TurnBasedGameTemplate.Model.TurnBasedFSM
{
    public class AiTurnState : TurnState
    {
        //----------------------------------------------------------------------------------------------------------

        #region Constructor

        protected AiTurnState(TurnBasedFsm fsm, IGameData gameData, Configurations.Configurations configurations) : base(fsm, gameData,
            configurations)
        {
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        Coroutine AiFinishTurnRoutine { get; set; }
        float AiFinishTurnDelay => Configurations.AiFinishTurnDelay;
        float AiDoTurnDelay => Configurations.AiDoTurnDelay;

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Operations

        protected override IEnumerator StartTurn()
        {
            yield return base.StartTurn();
            //call do turn routine
            Fsm.Handler.MonoBehaviour.StartCoroutine(AiDoTurn());
            //call finish turn routine
            AiFinishTurnRoutine = Fsm.Handler.MonoBehaviour.StartCoroutine(AiFinishTurn(AiFinishTurnDelay));
        }

        protected override void RestartTimeouts()
        {
            base.RestartTimeouts();

            if (AiFinishTurnRoutine != null)
                Fsm.Handler.MonoBehaviour.StopCoroutine(AiFinishTurnRoutine);
            AiFinishTurnRoutine = null;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Coroutines

        IEnumerator AiDoTurn()
        {
            yield return new WaitForSeconds(AiDoTurnDelay);

            if (!IsMyTurn)
                yield break;

            if (!IsAi)
                yield break;

            GameData.RuntimeGame.ExecuteAiTurn(Seat);
        }

        IEnumerator AiFinishTurn(float delay)
        {
            yield return new WaitForSeconds(delay);
            if (!IsMyTurn)
                yield break;

            if (!IsAi)
                yield break;

            if (!Configurations.PlayerTurn.DebugAiTurn)
                Fsm.Handler.MonoBehaviour.StartCoroutine(TimeOut());
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}