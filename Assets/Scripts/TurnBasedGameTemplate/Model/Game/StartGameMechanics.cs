using TurnBasedGameTemplate.GameEvents;
using TurnBasedGameTemplate.Model.Player;

namespace TurnBasedGameTemplate.Model.Game
{
    /// <inheritdoc />
    /// <summary> Start Game Step Implementation.</summary>
    public class StartGameMechanics : BaseGameMechanics
    {
        public StartGameMechanics(IGame game) : base(game)
        {
        }

        /// <summary> Execution of start game</summary>
        public void Execute()
        {
            if (Game.IsGameStarted) return;

            Game.IsGameStarted = true;

            //calculus of the starting player
            Game.TurnLogic.DecideStarterPlayer();

            OnGameStarted(Game.TurnLogic.StarterPlayer);
        }

        /// <summary> Dispatch start game event to the listeners.</summary>
        /// <param name="starterPlayer"></param>
        void OnGameStarted(IPlayer starterPlayer)
        {
            Tools.Patterns.GameEvents.GameEvents.Instance.Notify<IStartGame>(i => i.OnStartGame(starterPlayer));
        }
    }
}