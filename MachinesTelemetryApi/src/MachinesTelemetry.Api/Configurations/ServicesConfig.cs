using FluentValidation;
using FluentValidation.AspNetCore;
using MachinesTelemetry.Api.Validations.MachineValidations;
using MachinesTelemetry.Data;
using Microsoft.EntityFrameworkCore;

namespace MachinesTelemetry.Api.Configurations
{
    public static class ServicesConfig 
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.ConfigureDependencyInjection();
            services.AddAutoMapper(c =>
            {
                c.AddProfile<AutomapperConfig>();
            });
            services.AddFluentValidationAutoValidation(); 
            services.AddDbContext<MachinesTelemetryDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
