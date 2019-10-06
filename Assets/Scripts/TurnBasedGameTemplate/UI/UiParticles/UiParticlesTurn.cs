using TurnBasedGameTemplate.GameEvents;
using TurnBasedGameTemplate.Model.Player;
using UnityEngine;

namespace TurnBasedGameTemplate.UI
{
    public class UiParticlesTurn : UI.UiParticles, IStartPlayerTurn
    {
        [SerializeField] PlayerSeat seat;

        void IStartPlayerTurn.OnStartPlayerTurn(IPlayer player)
        {
            if (player.Seat == seat)
                StartCoroutine(Play());
        }
    }
}