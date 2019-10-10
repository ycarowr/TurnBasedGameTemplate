using System.Collections;
using TurnBasedGameTemplate.Tools.Patterns.GameEvents;
using UnityEngine;

namespace TurnBasedGameTemplate.UI
{
    public class UiAnimation : UiGameEventListener
    {
        protected static readonly int HashName = Animator.StringToHash("Animation");
        protected Animator Animator { get; set; }

        protected virtual void Awake() => Animator = GetComponent<Animator>();

        protected virtual IEnumerator Animate(float delay = 0)
        {
            yield return new WaitForSeconds(delay);

            if (Animator != null)
                Animator.Play(HashName);
        }
    }
}