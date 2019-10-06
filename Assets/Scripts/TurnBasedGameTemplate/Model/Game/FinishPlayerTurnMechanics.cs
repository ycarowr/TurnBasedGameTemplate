using TurnBasedGameTemplate.GameEvents;
using TurnBasedGameTemplate.Model.Player;

namespace TurnBasedGameTemplate.Model.Game
{
    /// <inheritdoc />
    /// <summary> Finish Current player Turn Implementation.</summary>
    public class FinishPlayerTurnMechanics : BaseGameMechanics
    {
        public FinishPlayerTurnMechanics(IGame game) : base(game)
        {
        }


        /// <summary> Finish player turn logic.</summary>
        public void Execute()
        {
            if (!Game.IsTurnInProgress) return;
            if (!Game.IsGameStarted) return;
            if (Game.IsGameFinished) return;

            Game.IsTurnInProgress = false;
            Game.TurnLogic.CurrentPlayer.FinishTurn();
            OnFinishedCurrentPlayerTurn(Game.TurnLogic.CurrentPlayer);
        }

        /// <summary> Dispatch to the listeners.</summary>
        /// <param name="currentPlayer"></param>
        void OnFinishedCurrentPlayerTurn(IPlayer currentPlayer)
        {
            Tools.Patterns.GameEvents.GameEvents.Instance.Notify<IFinishPlayerTurn>(i => i.OnFinishPlayerTurn(currentPlayer));
        }
    }
}