using _Project.Scripts.Infrastructure;
using _Project.Scripts.Services.SimulateCurrentDataService;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Project.Scripts.Simulation
{
    public class SimulationManager : MonoBehaviour
    {
        [SerializeField] private FieldInitializer _fieldInitializer;
        [SerializeField] private GameObject _animalPrefab;
        [SerializeField] private GameObject _foodPrefab;
        [SerializeField] private GameObject _effectPrefab;

        private int _fieldSize;
        private int _animalCount;
        private int _animalSpeed;
        private ISimulateCurrentDataService _simulateCurrentDataService;

        [Inject]
        private void Construct(ISimulateCurrentDataService simulateCurrentDataService)
        {
            _simulateCurrentDataService = simulateCurrentDataService;
        }

        public void InitializeSimulation()
        {
            _fieldSize = _simulateCurrentDataService.SimulateData.FieldSize;
            _animalCount = _simulateCurrentDataService.SimulateData.AnimalCount;
            _animalSpeed = _simulateCurrentDataService.SimulateData.AnimalSpeed;

            _fieldInitializer.InitializeField(_fieldSize);

            // Create pool parents
            Transform foodPoolParent = new GameObject("FoodPool").transform;
            Transform effectPoolParent = new GameObject("EffectPool").transform;

            for (int i = 0; i < _animalCount; i++)
            {
                Vector3 spawnPosition = GetRandomPositionOnField();
                GameObject animalObject = Instantiate(_animalPrefab, spawnPosition, Quaternion.identity);
                Animal animal = animalObject.GetComponent<Animal>();
                animal.Initialize(_fieldSize, _animalSpeed, _foodPrefab, _effectPrefab, foodPoolParent, effectPoolParent);
            }
        }

        private Vector3 GetRandomPositionOnField()
        {
            float halfSize = _fieldSize / 2f;
            return new Vector3(
                Random.Range(-halfSize, halfSize),
                0,
                Random.Range(-halfSize, halfSize)
            );
        }

        public class Factory : PlaceholderFactory<SimulationManager>
        {
        }
    }
}