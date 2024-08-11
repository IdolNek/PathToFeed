using UnityEngine;

namespace _Project.Scripts.Simulation
{
    public class FieldInitializer : MonoBehaviour
    {
        public GameObject fieldPlanePrefab;
        private GameObject _fieldPlane;

        public void InitializeField(int fieldSize)
        {
            if (_fieldPlane != null)
            {
                Destroy(_fieldPlane);
            }

            _fieldPlane = Instantiate(fieldPlanePrefab, Vector3.zero, Quaternion.identity);
            _fieldPlane.transform.localScale = new Vector3(fieldSize+2f, 1, fieldSize+2f);
        }
    }
}