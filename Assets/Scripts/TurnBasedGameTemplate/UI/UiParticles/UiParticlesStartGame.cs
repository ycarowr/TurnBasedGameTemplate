using TurnBasedGameTemplate.GameEvents;
using TurnBasedGameTemplate.Model.Player;

namespace TurnBasedGameTemplate.UI
{
    public class UiParticlesStartGame : UiParticles, IStartGame
    {
        const float DelayToNotify = 0.75f;

        void IStartGame.OnStartGame(IPlayer player) => StartCoroutine(Play(DelayToNotify));
    }
}