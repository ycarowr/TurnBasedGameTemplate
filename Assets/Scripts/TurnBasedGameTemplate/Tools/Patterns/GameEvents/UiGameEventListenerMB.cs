using TurnBasedGameTemplate;
using UnityEngine;

namespace TurnBasedGameTemplate.Tools.Patterns.GameEvents
{
    public class UiGameEventListenerMB : MonoBehaviour, IListener
    {
        protected virtual void Awake() => Subscribe();

        protected virtual void OnDestroy() => Unsubscribe();

        void Subscribe()
        {
            if (GameEventsMB.Instance)
                GameEventsMB.Instance.AddListener(this);
        }

        void Unsubscribe()
        {
            if (GameEventsMB.Instance)
                GameEventsMB.Instance.RemoveListener(this);
        }
    }
}