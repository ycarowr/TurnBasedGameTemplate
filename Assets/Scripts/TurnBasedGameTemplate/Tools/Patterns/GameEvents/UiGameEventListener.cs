using TurnBasedGameTemplate;
using UnityEngine;

namespace TurnBasedGameTemplate.Tools.Patterns.GameEvents
{
    public class UiGameEventListener : MonoBehaviour, IListener
    {
        [SerializeField] TurnBasedGameTemplate.Observer GameEvents;

        protected virtual void Start()
        {
            if (GameEvents == null)
                Debug.Log("Assign a observer to " + gameObject.name);
            Subscribe();
        }

        protected virtual void OnDestroy() => Unsubscribe();

        void Subscribe() => GameEvents.AddListener(this);

        void Unsubscribe() => GameEvents?.RemoveListener(this);
    }
}