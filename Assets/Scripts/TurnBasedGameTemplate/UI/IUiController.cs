using TurnBasedGameTemplate.GameController;
using TurnBasedGameTemplate.Model.TurnBasedFSM;

namespace TurnBasedGameTemplate.UI
{
    /// <summary>  All child components search for this interface in order to resolve dependencies related to the game state.</summary>
    public interface IUiController
    {
        IGameController Controller { get; }
    }

    public interface IUiPlayerController
    {
        IPlayerTurn PlayerController { get; }
    }
}