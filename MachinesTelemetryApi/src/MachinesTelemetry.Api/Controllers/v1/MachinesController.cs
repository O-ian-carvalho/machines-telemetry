using AutoMapper;
using MachinesTelemetry.Api.Dtos.Requests;
using MachinesTelemetry.Api.Dtos.Responses;
using MachinesTelemetry.Business.Interfaces.Services;
using MachinesTelemetry.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;


namespace MachinesTelemetry.Api.Controllers.v1
{
    public class MachinesController(IMachineService machineService, ITelemetryService telemetryService, IMapper mapper ) : BaseController
    {


        // TODO: Implementar paginação

        [HttpGet]
        public async Task<ActionResult<List<MachineResponseDto>>> GetMachines([FromQuery] string? status)
        {
            IEnumerable<Machine> machines;
            if (status != null)
            {
                if (!Enum.TryParse<EMachineStatus>(status, true, out var statusParsed))
                {
                    return BadRequest(BuildErrorResponse(StatusCodes.Status400BadRequest, "InvalidStatus",
                        "Status inválido. Valores válidos: Operating, Maintenance, Offline."));
                }

                machines = await machineService.GetByStatusWithTelemetriesAsync(statusParsed);
            }
            else
            {
                machines = await machineService.GetAllWithTelemetriesAsync();
            }

            return Ok(mapper.Map<List<MachineResponseDto>>(machines));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MachineResponseDto>> GetMachineById(Guid id)
        {
            var machine = await machineService.GetByIdWithTelemetriesAsync(id);

            if(machine == null)
                return NotFound(BuildErrorResponse(StatusCodes.Status404NotFound, "MachineNotFound", "Id da máquina não foi encontrado")); 
            
            return Ok(mapper.Map<MachineResponseDto>(machine));
        }

        [HttpPost]
        public async Task<ActionResult<MachineResponseDto>> CreateMachine(MachineCreateDto machineDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var machine = mapper.Map<Machine>(machineDto);


            await machineService.AddAsync(machine);

            var telemetry = mapper.Map<Telemetry>(machineDto.Telemetry);

            telemetry.MachineId = machine.Id;

            await telemetryService.AddAsync(telemetry);

            var responseDto = mapper.Map<MachineResponseDto>(machine);

            return CreatedAtAction(nameof(GetMachineById), new { id = machine.Id }, responseDto);
        }


        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> UpdateMachine(Guid id, [FromBody] MachineUpdateDto machineDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var machine = await machineService.GetByIdAsync(id);
            if (machine == null)
                return NotFound(BuildErrorResponse(StatusCodes.Status404NotFound, "MachineNotFound", "Id da máquina não foi encontrado"));

            await machineService.UpdateAsync(machine, id);
            return NoContent();
        }



        [HttpPost("{machineId:guid}/telemetries")]
        public async Task<ActionResult<MachineResponseDto>> SendTelemetrie(TelemetryCreateDto telemetryDto, Guid machineId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var machine = await machineService.GetByIdAsync(machineId);
            if (machine == null)
                return NotFound(BuildErrorResponse(StatusCodes.Status404NotFound, "MachineNotFound", "Id da máquina não foi encontrado"));

            var telemetry = mapper.Map<Telemetry>(telemetryDto);

            telemetry.MachineId = machineId;

            await telemetryService.AddAsync(telemetry);

            var responseDto = mapper.Map<TelemetryResponseDto>(telemetry);

            return CreatedAtAction(nameof(GetMachineById), new { id = telemetry.Id }, responseDto);
        }

        [HttpGet("{machineId:guid}/telemetries")]
        public async Task<ActionResult<List<TelemetryResponseDto>>> GetTelemetryHistory(
            Guid machineId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var telemetries = await telemetryService.GetByMachineIdAsync(machineId, pageNumber, pageSize);
            return Ok(mapper.Map<List<TelemetryResponseDto>>(telemetries));
        }



    }
}
