using System;
using System.Collections.Generic;
using System.Text;
using RemoteController.Application.ViewModels;

namespace RemoteController.Application.Interfaces
{
    public interface IMachineService : IDisposable
    {
        void Add(MachineViewModel machineViewModel);
        IEnumerable<MachineViewModel> GetAll();
        MachineViewModel GetById(Guid id);
        void Update(MachineViewModel machineViewModel);
        void Remove(Guid id);
    }
}
