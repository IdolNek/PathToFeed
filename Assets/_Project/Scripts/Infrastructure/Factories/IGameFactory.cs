using _Project.Scripts.UI.HUD;

namespace _Project.Scripts.Infrastructure.Factories
{
    public interface IGameFactory
    {
        IHUDRoot CreateHUD();
        void Cleanup();
    }
}