using GymManager.Core.EquipmentTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerApplicationServices.EquipmentTypes
{
    public interface IEquipmentTypeAppService
    {
        Task<int> AddEquipmentTypeAsync(EquipmentType equipmentType);
        Task DeleteEquipmentTypeAsync(int equipmentId);
        Task EditEquipmentTypeAsync(EquipmentType equipmentType);
        Task<EquipmentType> GetEquipmentTypeAsync(int equipmentId);
        Task<List<EquipmentType>> GetEquipmentTypesAsync();
    }
}
