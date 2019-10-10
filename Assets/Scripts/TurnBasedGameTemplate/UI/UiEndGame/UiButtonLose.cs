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