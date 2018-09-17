using RemoteController.Domain.Models;

namespace RemoteController.Domain.Interfaces
{
    public interface IMachineRepository : IRepository<Machine>
    {
        Machine GetByMacAdress(string macAddress);
    }
}
