using System;
using UnityEngine;

namespace TurnBasedGameTemplate.Tools.Input.KeyBoard
{
    public class KeyboardInput : MonoBehaviour, IKeyboardInput
    {
        public bool IsTracking { get; private set; }
        [SerializeField] KeyCode key;
        public KeyCode Key => key;
        public Action OnKey { get; set; } = () => { };
        public Action OnKeyDown { get; set; } = () => { };
        public Action OnKeyUp { get; set; } = () => { };

        public void StartTracking() => IsTracking = true;

        public void StopTracking() => IsTracking = false;

        void Update()
        {
            if (!IsTracking)
                return;

            var isKey = UnityEngine.Input.GetKey(Key);
            var isKeyDown = UnityEngine.Input.GetKeyDown(Key);
            var isKeyUp = UnityEngine.Input.GetKeyUp(Key);

            if (isKey)
                OnKey?.Invoke();
            if (isKeyDown)
                OnKeyDown?.Invoke();
            if (isKeyUp)
                OnKeyUp?.Invoke();
        }

        public void SetKey(KeyCode keyCode) => key = keyCode;
    }
}