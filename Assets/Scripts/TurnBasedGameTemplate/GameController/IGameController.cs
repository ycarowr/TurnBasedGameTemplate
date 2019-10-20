using TurnBasedGameTemplate;
using TurnBasedGameTemplate.Tools.Patterns.StateMachine;
using UnityEngine;

namespace TurnBasedGameTemplate
{
    public interface IGameController : IStateMachineHandler
    {
        MonoBehaviour MonoBehaviour { get; }
        IPlayerTurn GetUser();
        IPlayerTurn GetPlayerController(PlayerSeat seat);
        void RestartGameImmediately();
        void Win();
        void Lose();
    }
}