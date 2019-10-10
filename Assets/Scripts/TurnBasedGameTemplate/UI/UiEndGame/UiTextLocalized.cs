using TurnBasedGameTemplate.Localization;

namespace TurnBasedGameTemplate.UI
{
    public class UiTextLocalized : UiText
    {
        public LocalizationIds Id;
        protected override void Awake()
        {
            base.Awake();
            var text = Localization.Localization.Instance.Get(Id);
            SetText(text);
        }
    }
}