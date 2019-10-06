using TurnBasedGameTemplate.Localization;
using UnityEngine;

namespace TurnBasedGameTemplate.UI
{
    public class UiLocalizedTextView : UiText
    {
        [SerializeField] LocalizationIds id;

        protected override void Awake()
        {
            base.Awake();
            SetText(Localization.Localization.Instance.Get(id));
        }
    }
}