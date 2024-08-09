using _Project.Scripts.UI.HUD;

namespace _Project.Scripts.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly HUDRoot.Factory hudFactory;

        public GameFactory(HUDRoot.Factory hudFactory)
        {
            this.hudFactory = hudFactory;
        }

        public IHUDRoot CreateHUD() => hudFactory.Create();

        public void Cleanup()
        {
            
        }
    }
}