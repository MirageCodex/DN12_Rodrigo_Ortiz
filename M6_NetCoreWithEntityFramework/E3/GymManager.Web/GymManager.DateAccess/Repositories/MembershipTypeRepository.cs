using GymManager.Core.MembershipType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.DataAccess.Repositories
{
    public class MembershipTypeRepository :Repository<int, MembershipType>
    {
        public MembershipTypeRepository(GymManagerContext context) : base(context)
        {

        }
    }
}
