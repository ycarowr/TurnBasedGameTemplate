using TurnBasedGameTemplate;

namespace TurnBasedGameTemplate.Model.Game
{
    /// <summary> Finish Game Step Implementation. </summary>
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

        /// <summary> Dispatch end game to the listeners. </summary>
        void OnGameFinished(IPlayer winner) =>
            GameEvents.Notify<IFinishGame>(i => i.OnFinishGame(winner));
    }
}