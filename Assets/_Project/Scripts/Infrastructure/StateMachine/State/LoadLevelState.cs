using _Project.Scripts.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.StateMachine.State
{
    public class LoadLevelState : IPaylodedState<string>
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, ILoadingCurtain loadingCurtain, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
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
            _gameFactory.CreateSimulationManager();
            _gameStateMachine.Enter<GameLoopState>();
            _loadingCurtain.Hide();
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadLevelState>
        {
        }
    }
}