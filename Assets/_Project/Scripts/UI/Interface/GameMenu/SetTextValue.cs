using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI.Interface.GameMenu
{
    public class SetTextValue : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
        public void SetValue(string value) => 
            _text.text = value;
    }
}