﻿using System;
using System.Collections.Generic;
using TurnBasedGameTemplate.Model.Game;
using TurnBasedGameTemplate.Model.Player;
using TurnBasedGameTemplate.Tools.Patterns.Singleton;
using UnityEngine;

namespace TurnBasedGameTemplate.GameData
{
    /// <summary>  Game data concrete implementation with Singleton Pattern.</summary>
    /// TODO: Get rid of the Singleton??
    public class GameData : SingletonMB<GameData>, IGameData
    {
        //--------------------------------------------------------------------------------------------------------

        [SerializeField] Configurations.Configurations configurations;
        public IGame RuntimeGame { get; private set; }


        //--------------------------------------------------------------------------------------------------------

        #region Unity Callbacks

        /// <summary>  Initialize game data OnAwake.</summary>
        protected override void OnAwake()
        {
            CreateGame();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------

        #region Operations

        /// <summary>  Clears the game data.</summary>
        public void Clear()
        {
            RuntimeGame = null;
        }

        /// <summary>  Create a new game data overriding the previous one. Produces Garbage.</summary>
        public void CreateGame()
        {
            //create and connect players to their seats
            var player1 = new Player(configurations.PlayerTurn.UserSeat, configurations);

            //if the second player doesn't have a deck, send null
            var player2 = new Player(PlayerSeat.Top, configurations);

            //create game data
            RuntimeGame = new Game(new List<IPlayer> {player1, player2}, configurations);
        }

        public void LoadGame()
        {
            throw new NotImplementedException();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------
    }
}