using UnityEngine;

namespace TurnBasedGameTemplate.UI
{
    public class UiPlayerElement : MonoBehaviour
    {
        UiPlayerContainer Handler { get; set; }

        void Awake() => Handler = GetComponentInParent<UiPlayerContainer>();
    }
}