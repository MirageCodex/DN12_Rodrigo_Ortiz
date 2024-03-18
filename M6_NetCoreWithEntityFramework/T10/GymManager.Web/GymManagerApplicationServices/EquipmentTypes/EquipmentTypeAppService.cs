using GymManager.Core.EquipmentTypes;
using GymManager.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerApplicationServices.EquipmentTypes
{
     public class EquipmentTypeAppService : IEquipmentTypeAppService
    {
        private readonly IRepository<int, EquipmentType> _repository;
        public EquipmentTypeAppService(IRepository<int, EquipmentType> repository)
        {
            _repository = repository;
        }
        public async Task<int> AddEquipmentTypeAsync(EquipmentType equipmentType)
        {
            await _repository.AddAsync(equipmentType);
            return equipmentType.Id;
        }
        public async Task DeleteEquipmentTypeAsync(int equipmentId)
        {
            await _repository.DeleteAsync(equipmentId);
        }
        public async Task EditEquipmentTypeAsync(EquipmentType equipmentType)
        {
            await _repository.UpdateAsync(equipmentType);
        }
        public async Task<EquipmentType> GetEquipmentTypeAsync(int equipmentId)
        {
            return await _repository.GetAsync(equipmentId);
        }
        public async Task<List<EquipmentType>> GetEquipmentTypesAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

    }
}
