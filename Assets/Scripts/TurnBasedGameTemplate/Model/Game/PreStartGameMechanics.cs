using System.Collections.Generic;
using TurnBasedGameTemplate.GameEvents;
using TurnBasedGameTemplate.Model.Player;

namespace TurnBasedGameTemplate.Model.Game
{
    /// <summary> Pre Start Game Step Implementation. </summary>
    public class PreStartGameMechanics : BaseGameMechanics
    {
        public PreStartGameMechanics(IGame game) : base(game)
        {
        }

        /// <summary> Execution of start game</summary>
        public void Execute()
        {
            if (Game.IsGameStarted)
                return;

            OnGamePreStarted(Game.TurnLogic.Players);
        }

        /// <summary> Dispatch pre start game event to the listeners</summary>
        void OnGamePreStarted(List<IPlayer> players) =>
            GameEvents.Notify<IPreGameStart>(i => i.OnPreGameStart(players));
    }
}