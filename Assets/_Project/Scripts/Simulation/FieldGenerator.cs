using UnityEngine;

namespace _Project.Scripts.Simulation
{
    public class FieldGenerator
    {
        private int _fieldSize;

        public FieldGenerator(int fieldSize)
        {
            _fieldSize = fieldSize;
        }

        public GameObject GenerateField()
        {
            GameObject field = GameObject.CreatePrimitive(PrimitiveType.Cube);
            field.transform.position = new Vector3(0f,-1f,0f);

            field.transform.localScale = new Vector3(_fieldSize +1f, 1, _fieldSize +1f);

            return field;
        }
    }
}