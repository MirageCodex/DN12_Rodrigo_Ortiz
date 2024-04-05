using ATOS.Accounts.Dto;
using ATOS.Core.Accounts;
using ATOS.DataAccess.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATOS.ApplicationServices.Accounts
{
    public class ProfilesAppService : IProfilesAppService
    {
        private readonly IRepository<int, Core.Accounts.Profile> _repository;
        private readonly IMapper _mapper;

        public ProfilesAppService(IRepository<int, Core.Accounts.Profile> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<int> AddProfileAsync(ProfileDto profile)
        {
            var p = _mapper.Map<Core.Accounts.Profile>(profile);
            await _repository.AddAsync(p);
            return profile.Id;
        }

        public async Task DeleteProfileAsync(int profileId)
        {
            await _repository.DeleteAsync(profileId);
        }

        public async Task EditoProfileAsync(ProfileDto profile)
        {
            var p = _mapper.Map<Core.Accounts.Profile>(profile);
            await _repository.UpdateAsync(p);
        }

        public async Task<List<ProfileDto>> GetProfilesAsync()
        {
            var users = _mapper.Map<List<ProfileDto>>(await _repository.GetAll().ToListAsync());
            return users;
        }

        public async Task<ProfileDto> GetProfilesAsync(int profileId)
        {
            return _mapper.Map<ProfileDto>(await _repository.GetAsync(profileId));
        }
    }
}
