using System;
using System.Collections.Generic;
using TurnBasedGameTemplate.Model.Player;
using Random = UnityEngine.Random;

namespace TurnBasedGameTemplate.Model.TurnLogic
{
    /// <summary> This class decides which player goes first and which player goes next.</summary>
    public class TurnLogic : ITurnLogic
    {
        #region Constructor

        public TurnLogic(
            List<IPlayer> players,
            PlayerSeat start = PlayerSeat.Bottom,
            PlayerSeat current = PlayerSeat.Bottom)
        {
            if (players == null)
                throw new ArgumentException("A Null List is not a valid argument to Create a TurnLogic");
            if (players.Count < 1)
                throw new ArgumentException("Invalid number of players: " + players.Count);

            Players = players;
            TurnCount = 0;
            StarterPlayerSeat = start;
            CurrentPlayerSeat = current;
        }

        #endregion

        #region Properties

        public PlayerSeat CurrentPlayerSeat { get; private set; }

        public PlayerSeat NextPlayerSeat =>
            CurrentPlayer.Seat == PlayerSeat.Bottom ? PlayerSeat.Top : PlayerSeat.Bottom;

        public PlayerSeat StarterPlayerSeat { get; private set; }

        public List<IPlayer> Players { get; }
        public int TurnCount { get; private set; }

        public IPlayer CurrentPlayer => GetPlayer(CurrentPlayerSeat);
        public IPlayer NextPlayer => GetPlayer(NextPlayerSeat);
        public IPlayer StarterPlayer => GetPlayer(StarterPlayerSeat);

        public int QuantPlayers => Players.Count;

        bool ITurnLogic.IsMyTurn(IPlayer player)
        {
            return CurrentPlayer == player;
        }

        #endregion

        #region Operations

        /// <summary> Assign next player to the current player.</summary>
        public void UpdateCurrentPlayer()
        {
            //increment turn count
            TurnCount++;

            //not on the first turn of the match
            if (TurnCount == 1)
                return;

            //update current player
            CurrentPlayerSeat = NextPlayerSeat;
        }

        /// <inheritdoc />
        /// <summary> Decides which player goes first Randomly.</summary>
        public void DecideStarterPlayer()
        {
            var randomIndex = Random.Range(0, QuantPlayers);
            randomIndex = 0;
            StarterPlayerSeat = Players[randomIndex].Seat;
            CurrentPlayerSeat = StarterPlayerSeat;
        }

        public IPlayer GetOpponent(IPlayer player)
        {
            return player.Seat == PlayerSeat.Bottom ? GetPlayer(PlayerSeat.Top) : GetPlayer(PlayerSeat.Bottom);
        }

        public IPlayer GetPlayer(PlayerSeat seat)
        {
            foreach (var player in Players)
                if (player.Seat == seat)
                    return player;

            return null;
        }

        public void SetCurrentSeat(PlayerSeat current)
        {
            CurrentPlayerSeat = current;
        }

        public void SetStarterSeat(PlayerSeat first)
        {
            StarterPlayerSeat = first;
        }

        #endregion
    }
}