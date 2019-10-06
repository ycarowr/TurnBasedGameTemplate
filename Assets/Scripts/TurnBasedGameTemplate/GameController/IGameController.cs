using TurnBasedGameTemplate.GameData;
using TurnBasedGameTemplate.Model.Player;
using TurnBasedGameTemplate.Model.TurnBasedFSM;
using TurnBasedGameTemplate.Tools.Patterns.StateMachine;
using UnityEngine;

namespace TurnBasedGameTemplate.GameController
{
    public interface IGameController : IStateMachineHandler, IGameDataHandler
    {
        MonoBehaviour MonoBehaviour { get; }
        IPlayerTurn GetUser();
        IPlayerTurn GetPlayerController(PlayerSeat seat);
        void RestartGameImmediately();
    }
}