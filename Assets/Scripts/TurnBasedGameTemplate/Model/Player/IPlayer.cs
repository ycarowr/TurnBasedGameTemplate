namespace TurnBasedGameTemplate.Model.Player
{
    public interface IPlayer
    {
        Configurations.Configurations Configurations { get; }
        PlayerSeat Seat { get; }
        bool IsUser { get; }
        void StartTurn();
        void FinishTurn();
    }
}