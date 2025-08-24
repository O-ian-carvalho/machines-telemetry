using MachinesTelemetry.Api.Configurations;
using MachinesTelemetry.Api.Helpers;
using MachinesTelemetry.Api.Middlewears;
using MachinesTelemetry.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureServices(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await Seeder.SeedAsync(app);

app.Run();
