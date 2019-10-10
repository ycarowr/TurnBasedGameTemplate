namespace TurnBasedGameTemplate.UI
{
    public class UiButtonLose : UiButton
    {
        UITextMeshImage UiButton { get; set; }

        protected override void OnSetHandler(IButtonHandler handler)
        {
            if (handler is IPressLose lose)
                AddListener(lose.PressLose);
        }

        public interface IPressLose
        {
            void PressLose();
        }
    }
}