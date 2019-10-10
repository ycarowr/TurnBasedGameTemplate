using TurnBasedGameTemplate.Model.Player;

namespace TurnBasedGameTemplate.UI
{
    /// <summary> User HUD</summary>
    public class UiUserContainer : UiPlayerContainer
    {
        public override PlayerSeat Seat => Controller.Data.RuntimeGame.GameParameters.Profiles.UserSeat;
    }
}