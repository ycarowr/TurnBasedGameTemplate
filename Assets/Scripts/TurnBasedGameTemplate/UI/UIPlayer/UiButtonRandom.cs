using TurnBasedGameTemplate.UI;

namespace TurnBasedGameTemplate.UI
{
    public class UiButtonRandom : UiButton
    {
        protected override void OnSetHandler(IButtonHandler handler)
        {
            if (handler is IPressPassTurn pressRandom)
                AddListener(pressRandom.PressRandomMove);
        }

        public interface IPressPassTurn : IButtonHandler
        {
            void PressRandomMove();
        }
    }
}