using System.Collections.Generic;
using TurnBasedGameTemplate.Model.Player;
using TurnBasedGameTemplate.Model.TurnLogic;

namespace TurnBasedGameTemplate.Model.Game
{
    /// <summary> A game interface.</summary>
    public interface IGame
    {
        Configurations.Configurations Configurations { get; }

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