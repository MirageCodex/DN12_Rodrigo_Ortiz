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
    public class UsersAppService : IUsersAppServices
    {
        private readonly IRepository<int, User> _repository;
        private readonly IMapper _mapper;

        public UsersAppService(IRepository<int, Core.Accounts.User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddUserAsync(User user)
        {
            await _repository.AddAsync(user);
            return user.Id;
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _repository.DeleteAsync(userId);
        }

        public async Task EditUserAsync(User user)
        {
            await _repository.UpdateAsync(user);
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            var u = _mapper.Map<List<UserDto>>(await _repository.GetAll().ToListAsync());

            List<UserDto> users = _mapper.Map<List<UserDto>>(u);

            return users;
        }

        public async Task<UserDto> GetUsersAsync(int userId)
        {
            var user = await _repository.GetAsync(userId);

            UserDto dto = _mapper.Map<UserDto>(user);

            return dto;
        }
    }
}
