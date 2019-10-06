using TurnBasedGameTemplate.Tools.Patterns.Observer;
using UnityEngine;

namespace TurnBasedGameTemplate.UI
{
    public class UiListener : MonoBehaviour, IListener
    {
        protected virtual void Start()
        {
            //subscribe
            if (Tools.Patterns.GameEvents.GameEvents.Instance)
                Tools.Patterns.GameEvents.GameEvents.Instance.AddListener(this);
        }

        protected virtual void OnDestroy()
        {
            //unsubscribe
            if (Tools.Patterns.GameEvents.GameEvents.Instance)
                Tools.Patterns.GameEvents.GameEvents.Instance.RemoveListener(this);
        }
    }
}