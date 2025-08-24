using FluentValidation;
using MachinesTelemetry.Api.Dtos.Requests;
using System.Runtime.ConstrainedExecution;

namespace MachinesTelemetry.Api.Validations.MachineValidations
{
    public class MachineRequestValidator : AbstractValidator<MachineCreateDto>
    {
        public MachineRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome é requerido")
                .MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres")
                .MinimumLength(4).WithMessage("Nome deve ter no minimo 4 caracteres");
        }

    }
}
