using _Project.Scripts.Services.SimulateCurrentDataService;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Simulation
{
    public class SimulationManager : MonoBehaviour

    {
        [SerializeField] private GameObject animalPrefab;

        [SerializeField] private GameObject foodPrefab;

        [SerializeField] private GameObject effectPrefab;

        private FieldGenerator _fieldGenerator;
        private ISimulateCurrentDataService _simulateCurrentDataService;

        private int _fieldSize;
        private int _animalCount;
        private int _animalSpeed;
        private AnimalSpawner _animalSpawner;

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
            
            _fieldGenerator = new FieldGenerator(_fieldSize);
            
            GameObject field = _fieldGenerator.GenerateField();
            
            SpawnAnimals(_animalCount, _animalSpeed);
        }

        void SpawnAnimals(int animalCount, float speed)
        {
            _animalSpawner = new AnimalSpawner(animalPrefab, foodPrefab, effectPrefab, _fieldSize, speed);

            for (int i = 0; i < animalCount; i++)
            {
                _animalSpawner.SpawnAnimalWithFood();
            }
        }

        public void ChangeAnimalSpeed(float value) => 
            _animalSpawner.ChangeAnimalSpeed(value);

        public class Factory : PlaceholderFactory<SimulationManager>
        {
        }
    }
}