using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.StaticData.Level;
using _Project.Scripts.StaticData.Windows;
using UnityEngine;

namespace _Project.Scripts.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private const string WindowsDataPath = "GameData/Windows";
        private const string GameDataPath = "GameData/Level/LevelStaticData";

        private Dictionary<WindowsId, WindowsStaticData> _windows;
        private LevelStaticData _levelData;

        public LevelStaticData LevelData => _levelData;

        public void Initialize()
        {
            _windows = Resources.LoadAll<WindowsStaticData>(WindowsDataPath).ToDictionary(x => x.Id, x => x);
            _levelData = Resources.Load<LevelStaticData>(GameDataPath);
            Debug.Log(_levelData);
        }
        public WindowsStaticData GetWindows(WindowsId id) =>
            _windows.TryGetValue(id, out WindowsStaticData staticData)
                ? staticData
                : null;
    }
}