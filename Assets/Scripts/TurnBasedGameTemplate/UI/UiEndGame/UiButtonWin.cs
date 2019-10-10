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
    public class UiButtonWin : UiButton
    {
        UITextMeshImage UiButton { get; set; }

        protected override void OnSetHandler(IButtonHandler handler)
        {
            if (handler is IPressWin win)
                AddListener(win.PressWin);
        }

        public interface IPressWin
        {
            void PressWin();
        }

        protected void Awake() =>
            UiButton = new UITextMeshImage(
                GetComponentInChildren<TMP_Text>(),
                GetComponent<Image>());
    }
}