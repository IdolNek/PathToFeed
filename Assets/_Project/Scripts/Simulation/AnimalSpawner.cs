using UnityEngine;

namespace _Project.Scripts.Simulation
{
    public class AnimalSpawner
    {
        private GameObject _animalPrefab;
        private GameObject _foodPrefab;
        private GameObject _effectPrefab;
        private float _fieldSize;
        private float _maxDistance;
        private float _speed;

        public AnimalSpawner(GameObject animalPrefab, GameObject foodPrefab, GameObject effectPrefab, float fieldSize, float speed)
        {
            _animalPrefab = animalPrefab;
            _foodPrefab = foodPrefab;
            _effectPrefab = effectPrefab;
            _fieldSize = fieldSize;
            _speed = speed;

            _maxDistance = speed * 5.0f;
        }

        public void SpawnAnimalWithFood()
        {
            Vector3 animalPosition = GetRandomPosition();
            GameObject animalObject = Object.Instantiate(_animalPrefab, animalPosition, Quaternion.identity);

            Vector3 foodPosition = GenerateFoodPosition(animalPosition);
            Food foodObject = Object.Instantiate(_foodPrefab, foodPosition, Quaternion.identity).GetComponent<Food>();

            Animal animal = animalObject.GetComponent<Animal>();
            animal.SetTargetFood(foodObject, _foodPrefab, _effectPrefab, _fieldSize);
            animal.SetSpeed(_speed);
        }

        private Vector3 GetRandomPosition()
        {
            float halfFieldSize = _fieldSize / 2.0f;
            float x = Random.Range(-halfFieldSize, halfFieldSize);
            float z = Random.Range(-halfFieldSize, halfFieldSize);
            return new Vector3(x, 0, z);
        }

        private Vector3 GenerateFoodPosition(Vector3 animalPosition)
        {
            Vector3 randomDirection = Random.insideUnitSphere * _maxDistance;
            randomDirection.y = 0;

            Vector3 foodPosition = animalPosition + randomDirection;

            float halfFieldSize = _fieldSize / 2.0f;
            foodPosition.x = Mathf.Clamp(foodPosition.x, -halfFieldSize, halfFieldSize);
            foodPosition.z = Mathf.Clamp(foodPosition.z, -halfFieldSize, halfFieldSize);

            return foodPosition;
        }
    }
}