using System;
using UnityEngine;
using UnityEngine.UI;

namespace Input
{
    public class TapReceiver : MonoBehaviour, ITapReceiver
    {
        [SerializeField] private Button _button;
        public event EventHandler TapPressed;

        private void OnEnable() => _button.onClick.AddListener(OnClick);
        private void OnClick() => TapPressed?.Invoke(this, EventArgs.Empty);
        private void OnDisable() => _button.onClick.RemoveListener(OnClick);
    }
}

