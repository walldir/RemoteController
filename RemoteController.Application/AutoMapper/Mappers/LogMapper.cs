using AutoMapper;
using RemoteController.Application.ViewModels;
using RemoteController.Domain.Models;

namespace RemoteController.Application.AutoMapper.Mappers
{
    public class LogMapper : Profile
    {
        public LogMapper()
        {
            CreateMap<Log, LogViewModel>();
            CreateMap<LogViewModel, Log>();
        }
    }
}
