using MachinesTelemetry.Business.Interfaces.Repositories;
using MachinesTelemetry.Business.Interfaces.Services;
using MachinesTelemetry.Business.Models;
using Microsoft.AspNetCore.Http;

namespace MachinesTelemetry.Business.Services
{
    public class MachineService : BaseService<Machine>, IMachineService
    {
        private readonly IMachineRepository _machineRepository;
        private readonly IS3Service _s3Service;

        public MachineService(IMachineRepository repository, IS3Service s3Service) : base(repository)
        {
            _machineRepository = repository;
            _s3Service = s3Service;
        }

        public override async Task AddAsync(Machine entity)
        {
            var machine = await _repository.SearchAsync(m => m.Name == entity.Name);
            if (machine.Any()) throw new InvalidOperationException("MachineNameDuplicated");
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Machine>> GetAllWithTelemetriesAsync()
        {
            return await _machineRepository.GetAllWithTelemetriesAsync();
        }
      


        public async Task<Machine?> GetByIdWithTelemetriesAsync(Guid id)
        {
            return await _machineRepository.GetByIdWithTelemetriesAsync(id);
        }

        public async Task<IEnumerable<Machine>> GetByStatusWithTelemetriesAsync(EMachineStatus status)
        {
            return await _machineRepository.GetByStatusWithTelemetriesAsync(status);
        }

        public async Task<Machine> UploadImageAsync(Guid id, IFormFile file)
        {
            var machine = await _machineRepository.GetByIdAsync(id);
            if (machine == null)
            {
                throw new KeyNotFoundException("MachineNotFound");
            }

            var imageUrl = await _s3Service.UploadFileAsync(file);
            machine.ImageUrl = imageUrl;

            await _machineRepository.UpdateAsync(machine);
            await _machineRepository.SaveChangesAsync();

            return machine;
        }
    }
}
