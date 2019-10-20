using TurnBasedGameTemplate;

namespace TurnBasedGameTemplate.UI
{
    /// <summary> User HUD</summary>
    public class UiUserContainer : UiPlayerContainer
    {
        public override PlayerSeat Seat => Controller.GetUser().Seat;
    }
}