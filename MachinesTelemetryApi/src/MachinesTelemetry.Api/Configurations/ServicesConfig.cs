using Amazon.S3;
using FluentValidation.AspNetCore;
using MachinesTelemetry.Data;
using Microsoft.EntityFrameworkCore;

namespace MachinesTelemetry.Api.Configurations
{
    public static class ServicesConfig 
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.ConfigureCors();
            services.ConfigureDependencyInjection();

            services.AddAutoMapper(c => c.AddProfile<AutomapperConfig>());
            services.AddFluentValidationAutoValidation();

            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbUser = Environment.GetEnvironmentVariable("DB_USER");
            var dbPass = Environment.GetEnvironmentVariable("DB_PASS");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");

            var connectionString = $"Host={dbHost};Username={dbUser};Password={dbPass};Database={dbName}";

            services.AddDbContext<MachinesTelemetryDbContext>(options =>
                options.UseNpgsql(connectionString)
            );

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());

            return services;
        }

    }
}
