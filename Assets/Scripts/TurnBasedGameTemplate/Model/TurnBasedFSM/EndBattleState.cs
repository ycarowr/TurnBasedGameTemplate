using TurnBasedGameTemplate.Configurations;
using TurnBasedGameTemplate.GameData;
using TurnBasedGameTemplate.GameEvents;
using TurnBasedGameTemplate.Model.Player;
using TurnBasedGameTemplate.Tools.Patterns.Observer;

namespace TurnBasedGameTemplate.Model.TurnBasedFSM
{
    /// <summary> Holds the Game flow when a match is Finished. </summary>
    public class EndBattleState : BaseBattleState, IFinishGame
    {
        public EndBattleState(TurnBasedFsm fsm, IGameData gameData, GameParameters gameParameters, Observer gameEvents) :
            base(fsm, gameData, gameParameters, gameEvents)
        {
        }

        void IFinishGame.OnFinishGame(IPlayer winner) => Fsm.EndBattle();
    }
}