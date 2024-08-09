using _Project.Scripts.StaticData.Level;
using _Project.Scripts.StaticData.Windows;

namespace _Project.Scripts.Services.StaticDataService
{
    public interface IStaticDataService
    {
        void Initialize();
        WindowsStaticData GetWindows(WindowsId id);
        LevelStaticData LevelData { get; }
    }
}