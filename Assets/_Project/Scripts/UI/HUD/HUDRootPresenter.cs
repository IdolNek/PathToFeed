using _Project.Scripts.Services.SimulateCurrentDataService;
using _Project.Scripts.UI.Interface.GameMenu;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI.HUD
{
    public class HUDRootPresenter : MonoBehaviour, IHUDRoot
    {
        [SerializeField] private SlideChangeValue _speedSlider;

        [Inject]
        private void Construct(ISimulateCurrentDataService simulateCurrentDataService)
        {
            
        }

        private void Start()
        {
            _speedSlider.OnValueChanged += OnSpeedhanged;
        }

        private void OnSpeedhanged(float value)
        {
            
        }
        public class Factory : PlaceholderFactory<HUDRootPresenter>
        {
            
        }
    }
}