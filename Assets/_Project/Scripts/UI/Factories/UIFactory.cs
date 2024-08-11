using System;
using _Project.Scripts.Services.StaticDataService;
using _Project.Scripts.StaticData.Windows;
using _Project.Scripts.UI.Interface;
using _Project.Scripts.UI.Interface.GameMenu;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly InterfaceRoot.Factory _interFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly DiContainer _container;

        private InterfaceRoot _interface;

        public UIFactory(InterfaceRoot.Factory interFactory, IStaticDataService staticDataService, DiContainer container)
        {
            _interFactory = interFactory;
            _staticDataService = staticDataService;
            _container = container;
        }

        public InterfaceRoot CreateRootUI()
        {
            _interface = _interFactory.Create();
            return _interface;
        }

        public GameObject CreateWindow(WindowsId id)
        {
            GameObject window = null;
            switch (id)
            {
                case WindowsId.GameMenu:
                    window = CreateGameMenu();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(id), id, null);
            }
            return window;
        }

        private GameObject CreateGameMenu()
        {
            WindowsStaticData window = _staticDataService.GetWindows(WindowsId.GameMenu);
            GameMenuPresenter gameMenu = _container.InstantiatePrefab(window.Prefab,_interface.Canvas.transform).GetComponent<GameMenuPresenter>();
            gameMenu.Initialize();
            return gameMenu.gameObject;
        }

        public void Cleanup()
        {
            
        }
    }
}