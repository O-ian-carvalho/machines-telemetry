using Amazon.S3;
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

            services.AddScoped<IS3Service, S3Service>();

            services.AddSingleton<IAmazonS3>(sp =>
            {
                var accessKey = Environment.GetEnvironmentVariable("S3_ACCESS_KEY");
                var secretKey = Environment.GetEnvironmentVariable("S3_SECRET_KEY");
                var region = Environment.GetEnvironmentVariable("S3_REGION");

                return new AmazonS3Client(
                    accessKey,
                    secretKey,
                    Amazon.RegionEndpoint.GetBySystemName(region)
                );
            });





            services.AddScoped<IValidator<MachineCreateDto>, MachineRequestValidator>();
            services.AddScoped<IValidator<TelemetryCreateDto>, TelemetryRequestValidator>();
            return services;
        }
    }
}