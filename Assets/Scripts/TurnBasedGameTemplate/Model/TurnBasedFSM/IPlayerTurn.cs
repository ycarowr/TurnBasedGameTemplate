using TurnBasedGameTemplate.Model.Player;

namespace TurnBasedGameTemplate.Model.TurnBasedFSM
{
    public interface IPlayerTurn
    {
        bool IsAi { get; }
        bool IsUser { get; }
        bool IsMyTurn { get; }
        PlayerSeat Seat { get; }
        IPlayer Player { get; }
        bool PassTurn();
    }
}