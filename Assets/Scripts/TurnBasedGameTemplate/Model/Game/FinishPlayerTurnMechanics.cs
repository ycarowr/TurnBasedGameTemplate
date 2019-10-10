using TurnBasedGameTemplate.GameEvents;
using TurnBasedGameTemplate.Model.Player;

namespace TurnBasedGameTemplate.Model.Game
{
    /// <summary> Finish Current player Turn Implementation. </summary>
    public class FinishPlayerTurnMechanics : BaseGameMechanics
    {
        public FinishPlayerTurnMechanics(IGame game) : base(game)
        {
        }


        /// <summary> Finish player turn logic. </summary>
        public void Execute()
        {
            if (!Game.IsTurnInProgress) return;
            if (!Game.IsGameStarted) return;
            if (Game.IsGameFinished) return;

            Game.IsTurnInProgress = false;
            Game.TurnLogic.CurrentPlayer.FinishTurn();
            OnFinishedCurrentPlayerTurn(Game.TurnLogic.CurrentPlayer);
        }

        /// <summary> Dispatch to the listeners. </summary>
        void OnFinishedCurrentPlayerTurn(IPlayer currentPlayer) =>
            GameEvents.Notify<IFinishPlayerTurn>(i =>
                i.OnFinishPlayerTurn(currentPlayer));
    }
}