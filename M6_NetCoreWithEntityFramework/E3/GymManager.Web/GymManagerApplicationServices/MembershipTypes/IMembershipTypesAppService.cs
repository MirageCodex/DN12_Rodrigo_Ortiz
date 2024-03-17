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
        Task<List<MembershipType>> GetMembershipTypesAsync();

        Task<int> AddMembershipTypesAsync(MembershipType membershiptype);

        Task DeleteMembershipTypeAsync(int membershipId);

        Task<MembershipType> GetMembershipTypeAsync(int membershipId);

        Task EditMembershipTypeAsync(MembershipType membershiptype);
    }
    
}
