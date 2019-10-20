using TurnBasedGameTemplate;
using UnityEngine;

namespace TurnBasedGameTemplate.UI
{
    public class UiParticlesEndGame : UiParticles, IFinishGame
    {
        const float DelayToNotify = 1f;
        [SerializeField] PlayerSeat seat;

        void IFinishGame.OnFinishGame(IPlayer winner)
        {
            if (winner.Seat == seat) StartCoroutine(Play(DelayToNotify));
        }
    }
}