using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Simulation
{
    [RequireComponent(typeof(Rigidbody))]
    public class Animal : MonoBehaviour
    {
        private Food _targetFood;
        private float _speed;
        private GameObject _foodPrefab;
        private GameObject _effectPrefab;
        private float _fieldSize;

        private Rigidbody _rigidbody;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = false;
            _rigidbody.freezeRotation = true;
        }

        public void SetTargetFood(Food food, GameObject foodPrefab, GameObject effectPrefab, float fieldSize)
        {
            _targetFood = food;
            _foodPrefab = foodPrefab;
            _effectPrefab = effectPrefab;
            _fieldSize = fieldSize;
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        void FixedUpdate()
        {
            if (_targetFood != null)
            {
                MoveTowardsFood();
            }
        }

        private void MoveTowardsFood()
        {
            if (_targetFood == null) return;

            Vector3 direction = (_targetFood.transform.position - transform.position).normalized;
            transform.position += direction * _speed * Time.fixedDeltaTime;

            float distance = Vector3.Distance(transform.position, _targetFood.transform.position);
            if (distance < 0.5f)
            {
                StartCoroutine(OnFoodReachedCoroutine());
            }
        }

        private IEnumerator OnFoodReachedCoroutine()
        {
            transform.position =
                new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Destroy(_targetFood.gameObject);
            PlayEatingEffect();

            yield return new WaitForSeconds(1.0f);

            Vector3 newFoodPosition = GenerateNewFoodPosition();
            _targetFood = Instantiate(_foodPrefab, newFoodPosition, Quaternion.identity).GetComponent<Food>();
        }

        private void PlayEatingEffect()
        {
            GameObject effect = Instantiate(_effectPrefab, transform.position, Quaternion.identity);
            ParticleSystem particleSystem = effect.GetComponent<ParticleSystem>();
            particleSystem.Play();
            Destroy(effect, 1.0f);
        }

        private Vector3 GenerateNewFoodPosition()
        {
            float halfFieldSize = _fieldSize / 2.0f;
            Vector3 randomDirection = Random.insideUnitSphere * (_speed * 5.0f);
            randomDirection.y = 0;

            Vector3 newFoodPosition = transform.position + randomDirection;

            newFoodPosition.x = Mathf.Clamp(newFoodPosition.x, -halfFieldSize, halfFieldSize);
            newFoodPosition.z = Mathf.Clamp(newFoodPosition.z, -halfFieldSize, halfFieldSize);

            return newFoodPosition;
        }
    }
}