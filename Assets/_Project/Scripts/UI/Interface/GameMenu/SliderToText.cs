using UnityEngine;

namespace _Project.Scripts.UI.Interface.GameMenu
{
    public class SliderToText : MonoBehaviour
    {
        [SerializeField] private SlideChangeValue _slider;
        [SerializeField] private SetTextValue _text;

        private void Awake() => 
            _slider.OnValueChanged += (value) => _text.SetValue(value.ToString());
    }
}