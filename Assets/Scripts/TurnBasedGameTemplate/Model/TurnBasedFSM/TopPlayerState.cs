using TurnBasedGameTemplate.Configurations;
using TurnBasedGameTemplate.GameData;
using TurnBasedGameTemplate.Model.Player;
using TurnBasedGameTemplate.Tools.Patterns.Observer;

namespace TurnBasedGameTemplate.Model.TurnBasedFSM
{
    public class TopPlayerState : AiTurnState
    {
        public TopPlayerState(TurnBasedFsm fsm, IGameData gameData, GameParameters gameParameters, Observer gameEvents) :
            base(fsm, gameData, gameParameters, gameEvents)
        {
        }

        public override PlayerSeat Seat => PlayerSeat.Top;
        public override bool IsAi => GameParameters.Profiles.TopPlayer.IsAi;
        public override bool IsUser => !GameParameters.Profiles.TopPlayer.IsAi;
    }
}