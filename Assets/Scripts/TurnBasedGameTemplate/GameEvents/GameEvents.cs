using System.Collections.Generic;
using TurnBasedGameTemplate.Model.Player;
using TurnBasedGameTemplate.Tools.Patterns.Observer;

namespace TurnBasedGameTemplate.GameEvents
{
    #region Game Events Declaration

    /// <summary> Broadcast of the players right before the game start.</summary>
    public interface IPreGameStart : ISubject
    {
        void OnPreGameStart(List<IPlayer> players);
    }

    /// <summary> Broadcast of the starter player to the Listeners.</summary>
    public interface IStartGame : ISubject
    {
        void OnStartGame(IPlayer starter);
    }

    /// <summary> Broadcast of the winner after a game is finished to the Listeners.</summary>
    public interface IFinishGame : ISubject
    {
        void OnFinishGame(IPlayer winner);
    }

    /// <summary> Broadcast of a player when it starts the turn to the Listeners.</summary>
    public interface IStartPlayerTurn : ISubject
    {
        void OnStartPlayerTurn(IPlayer player);
    }

    /// <summary> Broadcast of a player when it finishes the turn to the Listeners.</summary>
    public interface IFinishPlayerTurn : ISubject
    {
        void OnFinishPlayerTurn(IPlayer player);
    }

    /// <summary> Broadcast of restart game.</summary>
    public interface IRestartGame : ISubject
    {
        void OnRestart();
    }

    #endregion

    //----------------------------------------------------------------------------------------------------------
}