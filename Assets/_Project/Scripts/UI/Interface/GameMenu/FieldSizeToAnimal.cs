using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI.Interface.GameMenu
{
    public class FieldSizeToAnimal : MonoBehaviour
    {
        [SerializeField] private SlideChangeValue _fieldSize;
        [SerializeField] private Slider _animalCount;

        private void Awake()
        {
            _fieldSize.OnValueChanged += OnValueChanged;
        }

        private void OnValueChanged(float value)
        {
            _animalCount.maxValue = (int) value * value / 2;
        } 
    }
}