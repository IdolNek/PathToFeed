using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.StateMachine.State
{
    public class LoadLevelState : IPaylodedState<string>
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingCurtain _loadingCurtain;

        public LoadLevelState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, ILoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter(string sceneName)
        {
            Debug.Log($"LoadLevelState enter. Load scene {sceneName}");
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            Debug.Log("LoadLevelState exit");
        }

        private void OnLoaded()
        {
            Debug.Log("LoadLevelState OnLoaded");
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadLevelState>
        {
        }
    }
}