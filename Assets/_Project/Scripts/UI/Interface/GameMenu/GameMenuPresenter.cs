using _Project.Scripts.Infrastructure.StateMachine;
using _Project.Scripts.Infrastructure.StateMachine.State;
using _Project.Scripts.Services.SaveLoadService;
using _Project.Scripts.Services.SimulateCurrentDataService;
using _Project.Scripts.Services.StaticDataService;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.Interface.GameMenu
{
    public class GameMenuPresenter : MonoBehaviour
    {
        private const string GameloopScene = "GameLoop";

        [SerializeField] private GameObject _setConfigbar;
        [SerializeField] private GameObject _loadGameConfigBar;
        
        [SerializeField] private PressedButton _loadConfigButton;
        [SerializeField] private PressedButton _setNewConfigButton;
        
        [SerializeField] private PressedButton _newConfigButton;
        [SerializeField] private Slider _fieldSize;
        [SerializeField] private Slider _animalCount;
        [SerializeField] private Slider _animalSpeed;
        [SerializeField] private SetTextValue _fieldSizeValue;
        [SerializeField] private SetTextValue _animalCountValue;
        [SerializeField] private SetTextValue _animalSpeedValue;
        
        private IGameStateMachine _gameStateMachine;
        private IStaticDataService _staticDataService;
        private ISimulateCurrentDataService _simulateCurrentDataService;
        private ISaveLoadService _saveLoadService;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, IStaticDataService staticDataService, 
            ISimulateCurrentDataService simulateCurrentDataService, ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _simulateCurrentDataService = simulateCurrentDataService;
            _staticDataService = staticDataService;
            _gameStateMachine = gameStateMachine;
        }

        public void Initialize()
        {
            if (_simulateCurrentDataService.SimulateData.IsNewData != true)
            {
                _loadGameConfigBar.SetActive(true);
                _setConfigbar.SetActive(false);
            }
            else
            {
                SetConfigBarActive();
            }
        }

        private void Awake()
        {
            _newConfigButton.Pressed += NewConfigChoosed;
            _setNewConfigButton.Pressed += SetConfigBarActive;
            _loadConfigButton.Pressed += StartWithLoadConfig;
        }

        public void StartWithLoadConfig() => 
            _gameStateMachine.Enter<LoadLevelState, string>(GameloopScene);

        private void SetConfigBarActive()
        {
            _loadGameConfigBar.SetActive(false);
            _setConfigbar.SetActive(true);
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

        private void NewConfigChoosed()
        {
            _simulateCurrentDataService.SimulateData.SetConfig((int)_fieldSize.value, (int)_animalCount.value, (int)_animalSpeed.value);
            _saveLoadService.SaveProgress();
            _gameStateMachine.Enter<LoadLevelState, string>(GameloopScene);
        }
    }
}