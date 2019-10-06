using System.Collections.Generic;
using TurnBasedGameTemplate.Model.Player;

namespace TurnBasedGameTemplate.Model.TurnLogic
{
    public interface ITurnLogic
    {
        /// <summary> List with all the players that are playing the match.</summary>
        List<IPlayer> Players { get; }

        /// <summary> Quantity of players playing this match.</summary>
        int QuantPlayers { get; }

        /// <summary> Duration of the match in turns.</summary>
        int TurnCount { get; }

        /// <summary> Current player playing this turn.</summary>
        IPlayer CurrentPlayer { get; }

        /// <summary> GameController that started the match.</summary>
        IPlayer StarterPlayer { get; }

        /// <summary> Next player to play.</summary>
        IPlayer NextPlayer { get; }

        /// <summary> Finds the next player and turns it into the current player.</summary>
        void UpdateCurrentPlayer();

        /// <summary> Calculus to decide which player starts the match.</summary>
        void DecideStarterPlayer();

        /// <summary> Returns whether is the player turn or not.</summary>
        /// <param name="player"></param>
        /// <returns></returns>
        bool IsMyTurn(IPlayer player);

        /// <summary> Returns a player opponent.</summary>
        /// <param name="player"></param>
        /// <returns></returns>
        IPlayer GetOpponent(IPlayer player);

        /// <summary> Returns a player based on its seat.</summary>
        /// <param name="seat"></param>
        /// <returns></returns>
        IPlayer GetPlayer(PlayerSeat seat);
    }
}