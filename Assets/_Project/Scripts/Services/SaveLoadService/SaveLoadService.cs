using _Project.Scripts.Data;
using _Project.Scripts.Services.SimulateCurrentDataService;
using UnityEngine;

namespace _Project.Scripts.Services.SaveLoadService
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "SimulateData";
        
        private readonly ISimulateCurrentDataService _simulateCurrentDataService;

        public SaveLoadService(ISimulateCurrentDataService simulateCurrentDataService)
        {
            _simulateCurrentDataService = simulateCurrentDataService;
        }

        public void SaveProgress()
        {
            PlayerPrefs.SetString(ProgressKey, _simulateCurrentDataService.SimulateData.ToJson());
        }

        public CurrentData LoadConfig()
        {
            return PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<CurrentData>();
        }
    }
}