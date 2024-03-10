using GymManager.Core.Members;
using GymManager.Core.MembershipType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerApplicationServices.MembershipTypes
{
    public interface IMembershipTypesAppService
    {
        List<MembershipType> GetMembershipTypes();

        int AddMembershipTypes(MembershipType membershiptype);

        void DeleteMembershipType(int membershipId);

        MembershipType GetMembershipType(int membershipId);

        void EditMembershipType(MembershipType membershiptype);
    }
    
}
