using TurnBasedGameTemplate.Configurations;

namespace TurnBasedGameTemplate.Model.Player
{
    public interface IPlayer
    {
        GameParameters GameParameters { get; }
        PlayerSeat Seat { get; }
        bool IsUser { get; }
        void StartTurn();
        void FinishTurn();
    }
}