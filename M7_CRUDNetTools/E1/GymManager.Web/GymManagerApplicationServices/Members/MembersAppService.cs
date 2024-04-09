using GymManager.Core.Members;
using GymManager.DataAccess.Repositories;
using Microsoft.AspNetCore.DataProtection.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GymManagerApplicationServices.Members
{
    public class MembersAppService : IMembersAppService
    {
        private readonly IRepository<int, Member> _repository;
        public MembersAppService(IRepository<int, Member> repositoy) 
        { 
            _repository = repositoy;
        }
        public async Task<int> AddMemberAsync(Member member)
        {
           await _repository.AddAsync(member);
            return member.Id;
        }

        public async Task DeleteMemberAsync(int memberId)
        {
          await _repository.DeleteAsync(memberId);
        }

        public async Task EditMemberAsync(Member member)
        {
            await _repository.UpdateAsync(member);
        }

        public async Task<Member> GetMemberAsync(int memberId)
        {
            return await _repository.GetAsync(memberId);
        }

        public async Task<List<Member>> GetMembersAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }
    }
}
