using TurnBasedGameTemplate;

namespace TurnBasedGameTemplate.Model.Game
{
    /// <summary> Start Game Step Implementation. </summary>
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

        /// <summary> Dispatch start game event to the listeners. </summary>
        void OnGameStarted(IPlayer starterPlayer) => GameEvents.Notify<IStartGame>(i => i.OnStartGame(starterPlayer));
    }
}