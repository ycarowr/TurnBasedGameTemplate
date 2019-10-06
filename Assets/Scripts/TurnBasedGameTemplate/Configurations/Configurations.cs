using System;
using TurnBasedGameTemplate.Model.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace TurnBasedGameTemplate.Configurations
{
    [CreateAssetMenu(menuName = "Configurations")]
    public class Configurations : ScriptableObject
    {
        #region Game Start

        public GameEventTimers Timers = new GameEventTimers();

        [Serializable]
        public class GameEventTimers
        {
            [Range(0.01f, 0.5f)] [Tooltip("Time between Load/Create and Pregame Event")]
            public float TimeUntilPreGameEvent = 0.01f;
            [Tooltip("Time between Pregame event and Start Game Event")] [Range(0.01f, 0.5f)]
            public float TimeUntilStartGameEvent = 0.01f;
            [Tooltip("Time between Start Game event and First Player turn animation")] [Range(3f, 6f)]
            public float TimeUntilFirstPlayer = 3f;
            [Range(6f, 12f)] [Tooltip("Total user turn time")]
            public float TimeUntilFinishTurn = 6;
            [Range(0.01f, 2f)] [Tooltip("Time until player starts the turn after the animation.")]
            public float TimeUntilStartTurn = 0.01f;
            [Range(0.01f, 4)] [Tooltip("Time until AI does the turn.")]
            public float TimeUntilAiDoTurn = 2.5f;
            [Range(0.01f, 10)] [Tooltip("Time maximum for AI turns.")]
            public float TimeUntilAiFinishTurn = 3.5f;

        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Players Configurations

        public PlayerProfiles Profiles = new PlayerProfiles();

        [Serializable]
        public class PlayerProfiles
        {
            [Tooltip("Seat where the user player will be sitting.")]
            public PlayerSeat UserSeat = PlayerSeat.Bottom;
            
            [Tooltip("Configurations for Bottom player")]
            public Player BottomPlayer = new Player
            {
                IsAi = false,
                Seat = PlayerSeat.Bottom
            };

            [Tooltip("Configurations for Top player")]
            public Player TopPlayer = new Player
            {
                IsAi = true,
                Seat = PlayerSeat.Top
            };

            [Serializable]
            public class Player
            {
                [Tooltip("Whether this player is driven by an AI system or not")]
                public bool IsAi;

                public PlayerSeat Seat;
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}