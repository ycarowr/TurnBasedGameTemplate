using TurnBasedGameTemplate.GameData;
using TurnBasedGameTemplate.Model.Player;

namespace TurnBasedGameTemplate.Model.TurnBasedFSM
{
    /// <summary> Bottom, where the User is always sitting.</summary>
    public class BottomPlayerState : AiTurnState
    {
        //----------------------------------------------------------------------------------------------------------

        #region Constructor

        public BottomPlayerState(TurnBasedFsm fsm, IGameData gameData, Configurations.Configurations configurations) :
            base(fsm, gameData, configurations)
        {
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        public override PlayerSeat Seat => PlayerSeat.Bottom;
        public override bool IsAi => Configurations.BottomIsAi;
        public override bool IsUser => true;

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}