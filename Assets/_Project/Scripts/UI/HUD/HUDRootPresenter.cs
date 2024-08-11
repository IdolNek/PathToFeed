using _Project.Scripts.Services.SimulateCurrentDataService;
using _Project.Scripts.Simulation;
using _Project.Scripts.UI.Interface.GameMenu;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.HUD
{
    public class HUDRootPresenter : MonoBehaviour, IHUDRoot
    {
        [SerializeField] private Slider _speedSlider;
        private ISimulateCurrentDataService _simulateCurrentDataService;
        private SimulationManager _simulationManager;

        [Inject]
        private void Construct(ISimulateCurrentDataService simulateCurrentDataService)
        {
            _simulateCurrentDataService = simulateCurrentDataService;
        }

        public void Init(SimulationManager simulationManager)
        {
            _simulationManager = simulationManager;
            
            _speedSlider.value = _simulateCurrentDataService.SimulateData.AnimalSpeed;

        }
        private void Start()
        {
            _speedSlider.onValueChanged.AddListener(OnSpeedChanged);
        }

        private void OnSpeedChanged(float value)
        {
            _simulationManager.ChangeAnimalSpeed(value);
        }
        public class Factory : PlaceholderFactory<HUDRootPresenter>
        {
            
        }
    }
}