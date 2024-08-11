using System.Collections;
using UnityEngine;

namespace _Project.Scripts.Simulation
{
    public class Animal : MonoBehaviour
    {
        private Vector3 _targetFoodPosition;
        private GameObject _foodPrefab;
        private GameObject _effectPrefab;
        private float _speed;
        private float _fieldSize;
        private GameObject _currentFood;

        private Transform _foodPoolParent;
        private Transform _effectPoolParent;
        private GameObject _foodPoolObject;
        private GameObject _effectPoolObject;

        public void Initialize(float fieldSize, float speed, GameObject foodPrefab, GameObject effectPrefab,
            Transform foodPoolParent, Transform effectPoolParent)
        {
            _fieldSize = fieldSize;
            _speed = speed;
            _foodPrefab = foodPrefab;
            _effectPrefab = effectPrefab;
            _foodPoolParent = foodPoolParent;
            _effectPoolParent = effectPoolParent;

            GenerateFood();
        }

        private void Update()
        {
            MoveTowardsFood();
        }

        private void MoveTowardsFood()
        {
            if (_targetFoodPosition != Vector3.zero)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, _targetFoodPosition, _speed * Time.deltaTime);

                if (Vector3.Distance(transform.position, _targetFoodPosition) < 0.1f)
                {
                    HandleFoodEaten();
                }
            }
        }

        private void GenerateFood()
        {
            Vector3 foodPosition = GetRandomPositionNear(transform.position);
            _currentFood = Instantiate(_foodPrefab, foodPosition, Quaternion.identity, _foodPoolParent);
            _targetFoodPosition = foodPosition;
        }

        private void HandleFoodEaten()
        {
            if (_currentFood != null)
            {
                // Spawn the effect
                GameObject effectObject = Instantiate(_effectPrefab, _currentFood.transform.position,
                    Quaternion.identity, _effectPoolParent);
                Destroy(_currentFood); // Destroy food immediately
                _currentFood = null;

                // Deactivate effect after 1 second
                StartCoroutine(DeactivateEffectAfterDelay(effectObject, 1f));

                // Generate new food
                GenerateFood();
            }
        }

        private IEnumerator DeactivateEffectAfterDelay(GameObject effectObject, float delay)
        {
            yield return new WaitForSeconds(delay);
            effectObject.SetActive(false);
        }

        private Vector3 GetRandomPositionNear(Vector3 center)
        {
            float maxDistance = Mathf.Min(5f, _fieldSize / 2f);
            Vector3 randomPosition;
            do
            {
                randomPosition = center + new Vector3(
                    Random.Range(-maxDistance, maxDistance),
                    0,
                    Random.Range(-maxDistance, maxDistance)
                );
            } while (!IsWithinField(randomPosition));

            return randomPosition;
        }

        private bool IsWithinField(Vector3 position)
        {
            float halfSize = _fieldSize / 2f;
            return Mathf.Abs(position.x) <= halfSize && Mathf.Abs(position.z) <= halfSize;
        }
    }
}