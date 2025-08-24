using AutoMapper;
using MachinesTelemetry.Api.Dtos.Requests;
using MachinesTelemetry.Api.Dtos.Responses;
using MachinesTelemetry.Business.Models;

namespace MachinesTelemetry.Api.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Machine, MachineResponseDto>()
                .ForMember(dest => dest.LastTelemetry,
               opt => opt.MapFrom(src => src.LastTelemetry()));

            CreateMap<MachineCreateDto, Machine>();
            CreateMap<MachineUpdateDto, Machine>();

            CreateMap<Telemetry, TelemetryResponseDto>();
            CreateMap<TelemetryCreateDto, Telemetry>();
                
        }
    }
}
