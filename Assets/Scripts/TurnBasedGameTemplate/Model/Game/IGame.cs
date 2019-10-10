using System.Collections.Generic;
using TurnBasedGameTemplate.Configurations;
using TurnBasedGameTemplate.Model.Player;
using TurnBasedGameTemplate.Model.TurnLogic;
using TurnBasedGameTemplate.Tools.Patterns.Observer;

namespace TurnBasedGameTemplate.Model.Game
{
    /// <summary> A game interface. </summary>
    public interface IGame
    {
        GameParameters GameParameters { get; }
        Observer GameEvents { get; }
        List<BaseGameMechanics> Mechanics { get; }

        List<IPlayer> Players { get; }

        ITurnLogic TurnLogic { get; }

        bool IsGameStarted { get; set; }

        bool IsGameFinished { get; set; }

        bool IsTurnInProgress { get; set; }

        void PreStartGame();

        void StartGame();

        void StartCurrentPlayerTurn();

        void FinishCurrentPlayerTurn();

        void ExecuteAiTurn(PlayerSeat seat);
        void ForceWin(PlayerSeat seat);
    }
}