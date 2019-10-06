namespace TurnBasedGameTemplate.Model.Player
{
    /// <summary> A concrete player class.</summary>
    public class Player : IPlayer
    {
        public Player(PlayerSeat seat, Configurations.Configurations configurations = null)
        {
            Configurations = configurations;
            Seat = seat;
            StartTurnMechanics = new StartTurnMechanics(this);
            FinishTurnMechanics = new FinishTurnMechanics(this);
        }

        //----------------------------------------------------------------------------------------------------------
        public Configurations.Configurations Configurations { get; }

        public PlayerSeat Seat { get; }

        public bool IsUser => Seat == Configurations.PlayerTurn.UserSeat;

        #region Mechanics

        public StartTurnMechanics StartTurnMechanics { get; }

        public FinishTurnMechanics FinishTurnMechanics { get; }

        #endregion

        #region Turn

        void IPlayer.FinishTurn()
        {
            FinishTurnMechanics.FinishTurn();
        }

        void IPlayer.StartTurn()
        {
            StartTurnMechanics.StartTurn();
        }

        #endregion
    }
}