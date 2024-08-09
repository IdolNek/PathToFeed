using _Project.Scripts.StaticData.Windows;
using _Project.Scripts.UI.Interface;

namespace _Project.Scripts.UI.Factories
{
    public interface IUIFactory
    {
        void Cleanup();
        InterfaceRoot CreateRootUI();
        void CreateWindow(WindowsId id);
    }
}