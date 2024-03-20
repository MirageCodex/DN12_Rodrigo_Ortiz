using GymManager.Core.Members;
using GymManager.Core.MembershipType;
using GymManager.DataAccess.Repositories;
using GymManagerApplicationServices.Members;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerApplicationServices.MembershipTypes
{
    public class MembershipTypesAppService : IMembershipTypesAppService
    {
        private readonly IRepository<int, MembershipType> _repository;
        public MembershipTypesAppService(IRepository<int, MembershipType> repository)
        {
            _repository = repository;
        }
        public async Task<int> AddMembershipTypesAsync(MembershipType membershiptype)
        {
            await _repository.AddAsync(membershiptype);
            return membershiptype.idMembership;
        }

        public async Task DeleteMembershipTypeAsync(int membershipId)
        {
            await _repository.DeleteAsync(membershipId);
        }

        public async Task EditMembershipTypeAsync(MembershipType membershiptype)
        {
            await _repository.UpdateAsync(membershiptype);
        }

        public async Task<MembershipType> GetMembershipTypeAsync(int membershipId)
        {
            return await _repository.GetAsync(membershipId);
        }

        public async Task<List<MembershipType>> GetMembershipTypesAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }
    }
    
}
