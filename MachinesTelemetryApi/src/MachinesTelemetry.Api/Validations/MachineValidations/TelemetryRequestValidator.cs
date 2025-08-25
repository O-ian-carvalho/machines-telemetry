using FluentValidation;
using MachinesTelemetry.Api.Dtos.Requests;
using MachinesTelemetry.Business.Models;

namespace MachinesTelemetry.Api.Validations.MachineValidations
{
    public class TelemetryRequestValidator : AbstractValidator<TelemetryCreateDto>
    {
        public TelemetryRequestValidator()
        {
            RuleFor(t => t.Latitude)
              .InclusiveBetween(-90, 90)
              .WithMessage("Latitude deve estar entre -90 e 90.");

            
            RuleFor(t => t.Longitude)
                .InclusiveBetween(-180, 180)
                .WithMessage("Longitude deve estar entre -180 e 180.");

            
            RuleFor(t => t.Status)
                .NotEmpty()
                .WithMessage("Status é obrigatório.")
                .Must(BeAValidStatus)
                .WithMessage("Status inválido. Valores válidos: Operating, Maintenance, Stopped.");
        }

        private bool BeAValidStatus(string status)
        {
            return Enum.TryParse(typeof(EMachineStatus), status, true, out _);
        }
    }
}
