using TMPro;
using TurnBasedGameTemplate.GameEvents;
using TurnBasedGameTemplate.Localization;
using TurnBasedGameTemplate.Model.Player;
using UnityEngine;

namespace TurnBasedGameTemplate.UI
{
    public class UiAnimationEndGame : UiAnimation, IFinishGame
    {
        const float DelayToNotify = 1f;
        [SerializeField] LocalizationIds id;
        [SerializeField] PlayerSeat seat;
        TMP_Text Text;

        void IFinishGame.OnFinishGame(IPlayer winner)
        {
            if (winner.Seat == seat)
            {
                Text.text = Localization.Localization.Instance.Get(id);
                StartCoroutine(Animate(DelayToNotify));
            }
        }

        protected override void Awake()
        {
            base.Awake();
            Text = GetComponent<TMP_Text>();
        }
    }
}