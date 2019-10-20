using TurnBasedGameTemplate;
using UnityEngine;

namespace TurnBasedGameTemplate.UI
{
    public interface IUiPlayer : IUiController, IUiPlayerController
    {
        PlayerSeat Seat { get; }
    }

    /// <summary> Main player UI. It resolves the dependencies accessing the game controller via Singleton. </summary>
    public class UiPlayerContainer : MonoBehaviour, IUiPlayer
    {
        public virtual PlayerSeat Seat => PlayerSeat.Top;
        public IGameController Controller => TurnBasedGameTemplate.GameController.Instance;
        public IPlayerTurn PlayerController => Controller.GetPlayerController(Seat);
    }
}