using TurnBasedGameTemplate.GameData;
using TurnBasedGameTemplate.Model.Player;

namespace TurnBasedGameTemplate.Model.TurnBasedFSM
{
    public class TopPlayerState : AiTurnState
    {
        //----------------------------------------------------------------------------------------------------------

        #region Constructor

        public TopPlayerState(TurnBasedFsm fsm, IGameData gameData, Configurations.Configurations configurations) : base(fsm, gameData,
            configurations)
        {
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        public override PlayerSeat Seat => PlayerSeat.Top;
        public override bool IsAi => Configurations.Profiles.TopPlayer.IsAi;
        public override bool IsUser => !Configurations.Profiles.TopPlayer.IsAi;

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}