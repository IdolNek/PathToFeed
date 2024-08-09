using UnityEngine;

namespace _Project.Scripts.StaticData.Level
{
    [CreateAssetMenu(fileName = "LevelStaticData", menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        [Range(2, 900)] public int MinFieldSize;
        [Range(4, 1000)] public int MaxFieldSize;
        [Range(1, 1000)] public int MinAnimalCount;
        [Range(1, 90)] public int MinAnimalSpeed;
        [Range(3, 100)] public int MaxAnimalSpeed;

        private void OnValidate()
        {
            if (MinFieldSize >= MaxFieldSize)
                MinFieldSize = MaxFieldSize - 1;
            if (MinAnimalSpeed >= MaxFieldSize)
                MinAnimalSpeed = MaxFieldSize - 1;
        }
    }
}