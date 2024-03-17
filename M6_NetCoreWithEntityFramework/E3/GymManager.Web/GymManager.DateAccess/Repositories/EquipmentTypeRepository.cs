using GymManager.Core.EquipmentTypes;
using GymManager.Core.MembershipType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.DataAccess.Repositories
{
    public class EquipmentTypeRepository : Repository<int, EquipmentType>
    {
        public EquipmentTypeRepository(GymManagerContext context) : base(context)
        {
        }
    }
}
