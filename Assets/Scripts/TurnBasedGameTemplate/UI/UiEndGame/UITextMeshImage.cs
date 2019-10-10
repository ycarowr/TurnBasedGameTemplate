using TMPro;
using UnityEngine.UI;

namespace TurnBasedGameTemplate.UI
{
    public class UITextMeshImage
    {
        public UITextMeshImage(TMP_Text text, Image image)
        {
            TmpText = text;
            Image = image;
        }

        public bool Enabled
        {
            get => Image.enabled;
            set
            {
                Image.enabled = value;
                TmpText.enabled = value;
            }
        }

        public TMP_Text TmpText { get; }
        public Image Image { get; }
    }
}