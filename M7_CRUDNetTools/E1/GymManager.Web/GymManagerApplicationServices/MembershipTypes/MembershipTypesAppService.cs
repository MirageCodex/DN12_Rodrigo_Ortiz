using AutoMapper;
using GymManager.Core.Members;
using GymManager.Core.MembershipType;
using GymManager.DataAccess.Repositories;
using GymManager.MembershipTypes.Dto;
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
        private readonly IMapper _mapper;
        public MembershipTypesAppService(IRepository<int, MembershipType> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

        public async Task<MembershipTypeDto> GetMembershipTypeAsync(int membershipId)
        {
            var membershipType = await _repository.GetAsync(membershipId);
            MembershipTypeDto dto = _mapper.Map<MembershipTypeDto>(membershipType);
            return dto;
        }

        public async Task<List<MembershipTypeDto>> GetMembershipTypesAsync()
        {
            var u = await _repository.GetAll().ToListAsync();
            List<MembershipTypeDto> list = _mapper.Map<List<MembershipTypeDto>>(u);
            return list;
        
        }
    }
    
}
