using _Project.Scripts.StaticData.Windows;
using _Project.Scripts.UI.Interface;
using _Project.Scripts.UI.Interface.GameMenu;
using UnityEngine;

namespace _Project.Scripts.UI.Factories
{
    public interface IUIFactory
    {
        void Cleanup();
        InterfaceRoot CreateRootUI();
        GameObject CreateWindow(WindowsId id);
    }
}