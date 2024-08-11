using _Project.Scripts.StaticData.Windows;
using _Project.Scripts.UI.Factories;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.StateMachine.State
{
    public class GameMenuState: IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly ILoadingCurtain _loadingCurtain;
        
        private GameObject _gameMenu;

        public GameMenuState(IGameStateMachine stateMachine, ISceneLoader sceneLoader, IUIFactory uiFactory, ILoadingCurtain loadingCurtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _loadingCurtain = loadingCurtain;
        }
        public void Exit()
        {
            _loadingCurtain.Show();
            Object.Destroy(_gameMenu);
        }

        public void Enter()
        {
            _sceneLoader.Load("GameMenu", OnLoaded);
        }

        private void OnLoaded()
        {
            _loadingCurtain.Hide();
            _uiFactory.CreateRootUI();
            _gameMenu = _uiFactory.CreateWindow(WindowsId.GameMenu);
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, GameMenuState> { }
    }
}