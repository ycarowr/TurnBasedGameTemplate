using TurnBasedGameTemplate;

namespace TurnBasedGameTemplate
{
    /// <summary> Holds the Game flow when a match is Finished. </summary>
    public class EndBattleState : BaseBattleState, IFinishGame
    {
        public EndBattleState(TurnBasedFsm fsm, IGameData gameData, GameParameters gameParameters,
            Observer gameEvents) :
            base(fsm, gameData, gameParameters, gameEvents)
        {
        }

        void IFinishGame.OnFinishGame(IPlayer winner) => Fsm.EndBattle();
    }
}