﻿using System.Collections;
using TurnBasedGameTemplate;
using UnityEngine;

namespace TurnBasedGameTemplate
{
    public class AiTurnState : TurnState
    {
        //----------------------------------------------------------------------------------------------------------

        #region Constructor

        protected AiTurnState(TurnBasedFsm fsm, IGameData gameData, GameParameters gameParameters,
            Observer gameEvents) :
            base(fsm, gameData, gameParameters, gameEvents)
        {
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        Coroutine AiFinishTurnRoutine { get; set; }
        float AiFinishTurnDelay => GameParameters.Timers.TimeUntilAiFinishTurn;
        float AiDoTurnDelay => GameParameters.Timers.TimeUntilAiDoTurn;

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

            Fsm.Handler.MonoBehaviour.StartCoroutine(TimeOut());
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}