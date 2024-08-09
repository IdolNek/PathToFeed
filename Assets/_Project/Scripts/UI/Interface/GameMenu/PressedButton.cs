using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI.Interface.GameMenu
{
    public class PressedButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        public event Action Pressed;

        private void Awake() =>
            _button.onClick.AddListener(() => Pressed?.Invoke());
    }
}