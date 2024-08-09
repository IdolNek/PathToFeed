using UnityEngine;

namespace _Project.Scripts.StaticData.Windows
{
    [CreateAssetMenu(fileName = "WindowsStaticData", menuName = "StaticData/Windows")]
    public class WindowsStaticData : ScriptableObject
    {
        public WindowsId Id;
        public GameObject Prefab;
    }
}