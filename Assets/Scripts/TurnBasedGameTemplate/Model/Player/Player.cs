using TurnBasedGameTemplate.Configurations;
using TurnBasedGameTemplate.Tools.Patterns.Observer;

namespace TurnBasedGameTemplate.Model.Player
{
    /// <summary> A concrete player class. </summary>
    public class Player : IPlayer
    {
        public Player(PlayerSeat seat, GameParameters gameParameters, Observer gameEvents)
        {
            GameParameters = gameParameters;
            Seat = seat;
            StartTurnMechanics = new StartTurnMechanics(this);
            FinishTurnMechanics = new FinishTurnMechanics(this);
            GameEvents = gameEvents;
        }

        //----------------------------------------------------------------------------------------------------------
        
        public GameParameters GameParameters { get; }
        public Observer GameEvents { get; }

        public PlayerSeat Seat { get; }

        public bool IsUser => Seat == GameParameters.Profiles.UserSeat;

        public StartTurnMechanics StartTurnMechanics { get; }

        public FinishTurnMechanics FinishTurnMechanics { get; }

        void IPlayer.FinishTurn() => FinishTurnMechanics.FinishTurn();

        void IPlayer.StartTurn() => StartTurnMechanics.StartTurn();
    }
}