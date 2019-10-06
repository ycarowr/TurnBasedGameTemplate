using TurnBasedGameTemplate.Localization;
using TurnBasedGameTemplate.UI;
using UnityEngine;

namespace TurnBasedGameTemplate.UI
{
    public class UiPlayerNameView : MonoBehaviour
    {
        string PlayerText { get; set; }
        UiText UiText { get; set; }
        IUiPlayer Ui { get; set; }

        void Awake()
        {
            Ui = GetComponentInParent<IUiPlayer>();
            UiText = GetComponent<UiText>();
            PlayerText = Localization.Localization.Instance.Get(LocalizationIds.Player);
        }

        void Start()
        {
            UiText.SetText(PlayerText + ": " + Ui.Seat);
        }
    }
}