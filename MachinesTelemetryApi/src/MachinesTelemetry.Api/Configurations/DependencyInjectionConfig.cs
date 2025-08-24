using AutoMapper;
using FluentValidation;
using MachinesTelemetry.Api.Dtos.Requests;
using MachinesTelemetry.Api.Validations.MachineValidations;
using MachinesTelemetry.Business.Interfaces.Repositories;
using MachinesTelemetry.Business.Interfaces.Services;
using MachinesTelemetry.Business.Services;
using MachinesTelemetry.Data.Repositories;

namespace MachinesTelemetry.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
        {


            services.AddScoped<IMachineRepository, MachineRepository>();
            services.AddScoped<IMachineService, MachineService>();

            services.AddScoped<ITelemetryRepository, TelemetryRepository>();
            services.AddScoped<ITelemetryService, TelemetryService>();

            services.AddScoped<IValidator<MachineCreateDto>, MachineRequestValidator>();
            services.AddScoped<IValidator<TelemetryCreateDto>, TelemetryRequestValidator>();
            return services;
        }
    }
}