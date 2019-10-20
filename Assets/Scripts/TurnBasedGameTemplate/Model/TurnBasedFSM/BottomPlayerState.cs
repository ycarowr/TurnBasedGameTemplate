using TurnBasedGameTemplate;

namespace TurnBasedGameTemplate
{
    /// <summary> Bottom, where the User is always sitting. </summary>
    public class BottomPlayerState : AiTurnState
    {
        public BottomPlayerState(TurnBasedFsm fsm, IGameData gameData, GameParameters gameParameters,
            Observer gameEvents) :
            base(fsm, gameData, gameParameters, gameEvents)
        {
        }

        public override PlayerSeat Seat => PlayerSeat.Bottom;
        public override bool IsAi => GameParameters.Profiles.BottomPlayer.IsAi;
        public override bool IsUser => !GameParameters.Profiles.BottomPlayer.IsAi;
    }
}