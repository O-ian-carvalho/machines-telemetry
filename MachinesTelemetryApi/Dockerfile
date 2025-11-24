FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /
COPY . .
RUN dotnet restore "./src/MachinesTelemetry.Api/MachinesTelemetry.Api.csproj" 
RUN dotnet publish "./src/MachinesTelemetry.Api/MachinesTelemetry.Api.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5058

ENTRYPOINT ["dotnet", "MachinesTelemetry.Api.dll"]
