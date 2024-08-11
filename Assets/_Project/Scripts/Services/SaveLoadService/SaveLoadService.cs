using System.IO;
using _Project.Scripts.Data;
using _Project.Scripts.Services.SimulateCurrentDataService;
using UnityEngine;

namespace _Project.Scripts.Services.SaveLoadService
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly ISimulateCurrentDataService _simulateCurrentDataService;

        public SaveLoadService(ISimulateCurrentDataService simulateCurrentDataService)
        {
            _simulateCurrentDataService = simulateCurrentDataService;
        }
        private string GetFilePath()
        {
            return Path.Combine(Application.persistentDataPath, "currentData.json");
        }
        public void SaveProgress()
        {
            string filePath = GetFilePath();

            string json = _simulateCurrentDataService.SimulateData.ToJson();

            try
            {
                File.WriteAllText(filePath, json);
                Debug.Log("Data saved to " + filePath);
            }
            catch (IOException e)
            {
                Debug.LogError("Failed to save data: " + e.Message);
            }
            Debug.Log("bad save");
        }

        public CurrentData LoadConfig()
        {
            string filePath = GetFilePath();
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    CurrentData data = json.ToDeserialized<CurrentData>();
                    return data;
                }
                catch (IOException e)
                {
                    Debug.LogError("Failed to load data: " + e.Message);
                }
            }
            else
            {
                Debug.LogWarning("No save file found at " + filePath);
            }

            return null;
        }
    }
}