using System.Collections;
using System.Collections.Generic;
using TMPro;
using TurnBasedGameTemplate.GameEvents;
using TurnBasedGameTemplate.Model.Player;
using TurnBasedGameTemplate.Tools.Patterns.Observer;
using UnityEngine;
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

    public class UiButtonRestart : UiButton,
        IListener,
        IPreGameStart,
        IFinishGame
    {
        const float DelayToShow = 3.5f;
        [SerializeField] Observer GameEvents;
        UITextMeshImage UiButton { get; set; }

        protected override void OnSetHandler(IButtonHandler handler)
        {
            if (handler is IPressRestart restart)
                AddListener(restart.PressRestart);
        }

        IEnumerator ShowButton()
        {
            yield return new WaitForSeconds(DelayToShow);
            UiButton.Enabled = true;
        }

        public interface IPressRestart
        {
            void PressRestart();
        }

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IFinishGame.OnFinishGame(IPlayer winner) => StartCoroutine(ShowButton());

        void IPreGameStart.OnPreGameStart(List<IPlayer> players) => UiButton.Enabled = false;

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Unity callbacks

        protected void Awake() =>
            UiButton = new UITextMeshImage(
                GetComponentInChildren<TMP_Text>(),
                GetComponent<Image>());

        void Start() => GameEvents.AddListener(this);

        void OnDestroy() => GameEvents.RemoveListener(this);

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}