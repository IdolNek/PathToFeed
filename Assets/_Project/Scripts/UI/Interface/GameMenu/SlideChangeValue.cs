using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI.Interface.GameMenu
{
    public class SlideChangeValue : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        
        public event Action<float> OnValueChanged;

        private void Awake() => 
            _slider.onValueChanged.AddListener(ValueChanged);

        private void ValueChanged(float value) => 
            OnValueChanged?.Invoke(value);
    }
}