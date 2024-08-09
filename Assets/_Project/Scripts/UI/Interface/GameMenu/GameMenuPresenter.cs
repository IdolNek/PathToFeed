using _Project.Scripts.Infrastructure.StateMachine;
using _Project.Scripts.Infrastructure.StateMachine.State;
using _Project.Scripts.Services.SimulateCurrentDataService;
using _Project.Scripts.Services.StaticDataService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.Interface.GameMenu
{
    public class GameMenuPresenter : MonoBehaviour
    {
        private const string GameloopScene = "GameLoop";
        
        [SerializeField] private PressedButton _pressedButton;
        [SerializeField] private Slider _fieldSize;
        [SerializeField] private Slider _animalCount;
        [SerializeField] private Slider _animalSpeed;
        [SerializeField] private SetTextValue _fieldSizeValue;
        [SerializeField] private SetTextValue _animalCountValue;
        [SerializeField] private SetTextValue _animalSpeedValue;
        
        private IGameStateMachine _gameStateMachine;
        private IStaticDataService _staticDataService;
        private ISimulateCurrentDataService _simulateCurrentDataService;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, IStaticDataService staticDataService, ISimulateCurrentDataService simulateCurrentDataService)
        {
            _simulateCurrentDataService = simulateCurrentDataService;
            _staticDataService = staticDataService;
            _gameStateMachine = gameStateMachine;
        }

        public void Initialize()
        {
            var data = _staticDataService.LevelData;
            _fieldSize.minValue = data.MinFieldSize;
            _fieldSize.value = data.MinFieldSize;
            _fieldSize.maxValue = data.MaxFieldSize;
            _animalCount.minValue = data.MinAnimalCount;
            _animalCount.value = data.MinAnimalCount;
            _animalSpeed.minValue = data.MinAnimalSpeed;
            _animalSpeed.value = data.MinAnimalSpeed;
            _animalSpeed.maxValue = data.MaxAnimalSpeed;
        }
        private void Awake()
        {
            _pressedButton.Pressed += OnPressed;
        }

        private void OnPressed()
        {
            _simulateCurrentDataService.SimulateData.SetConfig((int)_fieldSize.value, (int)_animalCount.value, (int)_animalSpeed.value);
            _gameStateMachine.Enter<LoadLevelState, string>(GameloopScene);
        }
    }
}