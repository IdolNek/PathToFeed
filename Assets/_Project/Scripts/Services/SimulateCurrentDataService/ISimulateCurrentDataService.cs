using _Project.Scripts.Data;

namespace _Project.Scripts.Services.SimulateCurrentDataService
{
    public interface ISimulateCurrentDataService
    {
        CurrentData SimulateData { get; set; }
    }
}