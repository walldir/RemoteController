using AutoMapper;
using RemoteController.Application.ViewModels;

namespace RemoteController.Application.AutoMapper.Mappers
{
    public class MachineMapper : Profile
    {
        public MachineMapper()
        {
            CreateMap<MachineMapper, MachineViewModel>();

            CreateMap<MachineViewModel, MachineMapper>();
        }
    }
}

