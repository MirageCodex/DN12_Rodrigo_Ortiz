using ATOS.Accounts.Dto;
using ATOS.Core.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATOS.ApplicationServices.Accounts
{
    public interface IUsersAppServices
    {
        Task<List<UserDto>> GetUsersAsync();
        Task<int> AddUserAsync(User user);
        Task DeleteUserAsync(int userId);
        Task<UserDto> GetUsersAsync(int userId);
        Task EditUserAsync(User user);
    }
}
