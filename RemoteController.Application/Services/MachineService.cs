using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using RemoteController.Application.Interfaces;
using RemoteController.Application.ViewModels;
using RemoteController.Domain.Interfaces;
using RemoteController.Domain.Models;

namespace RemoteController.Application.Services
{
    public class MachineService : IMachineService
    {
        private readonly IMapper _mapper;
        private readonly IMachineRepository _machineRepository;

        public MachineService(IMapper mapper, IMachineRepository machineRepository)
        {
            _mapper = mapper;
            _machineRepository = machineRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Add(MachineViewModel machineViewModel)
        {
            var machine = _mapper.Map<MachineViewModel, Machine>(machineViewModel);
            _machineRepository.Add(machine);
        }

        public IEnumerable<MachineViewModel> GetAll()
        {
            return _machineRepository.GetAll().ProjectTo<MachineViewModel>();
        }

        public MachineViewModel GetById(Guid id)
        {
            return _mapper.Map<MachineViewModel>(_machineRepository.GetById(id));
        }

        public void Update(MachineViewModel machineViewModel)
        {
            var machine = _mapper.Map<MachineViewModel, Machine>(machineViewModel);
            _machineRepository.Update(machine);
        }

        public void Remove(Guid id)
        {
            _machineRepository.Remove(id);
        }
    }
}
