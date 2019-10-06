using TurnBasedGameTemplate.GameEvents;
using TurnBasedGameTemplate.Model.Player;

namespace TurnBasedGameTemplate.Model.Game
{
    /// <summary> Finish Game Step Implementation.</summary>
    public class FinishGameMechanics : BaseGameMechanics
    {
        public FinishGameMechanics(IGame game) : base(game)
        {
        }

        public void Execute(IPlayer winner)
        {
            if (!Game.IsGameStarted)
                return;
            if (Game.IsGameFinished)
                return;

            Game.IsGameFinished = true;

            OnGameFinished(winner);
        }

        public void CheckWinCondition()
        {
        }

        /// <summary> Dispatch end game to the listeners.</summary>
        /// <param name="winner"></param>
        void OnGameFinished(IPlayer winner)
        {
            Tools.Patterns.GameEvents.GameEvents.Instance.Notify<IFinishGame>(i => i.OnFinishGame(winner));
        }
    }
}