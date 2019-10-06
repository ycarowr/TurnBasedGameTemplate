using TurnBasedGameTemplate.Model.Player;
using TurnBasedGameTemplate.UI;

namespace TurnBasedGameTemplate.UI
{
    /// <summary> User HUD</summary>
    public class UiUserContainer : UiPlayerContainer
    {
        public override PlayerSeat Seat => Controller.Data.RuntimeGame.Configurations.PlayerTurn.UserSeat;

        void Awake()
        {
            //HUD input
            gameObject.AddComponent<UiUserInput>();

            //Ui elements for pre start game
            gameObject.AddComponent<UiPreStartGameUser>();

            //Ui elements for start user turn
            gameObject.AddComponent<UiStartUserTurn>();

            //Ui elements for finish user turn
            gameObject.AddComponent<UiFinishUserTurn>();

            //HUD buttons
            gameObject.AddComponent<UiUserHudButtons>();
        }
    }
}