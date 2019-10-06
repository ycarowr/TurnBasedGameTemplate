using TurnBasedGameTemplate.Tools.Patterns.Observer;
using UnityEngine;

namespace TurnBasedGameTemplate.Tools.Patterns.GameEvents
{
    public class UiGameEventListener : MonoBehaviour, IListener
    {
        protected virtual void Awake()
        {
            Subscribe();
        }

        protected virtual void OnDestroy()
        {
            Unsubscribe();
        }

        void Subscribe()
        {
            if (GameEvents.Instance)
                GameEvents.Instance.AddListener(this);
        }

        void Unsubscribe()
        {
            if (GameEvents.Instance)
                GameEvents.Instance.RemoveListener(this);
        }
    }
}