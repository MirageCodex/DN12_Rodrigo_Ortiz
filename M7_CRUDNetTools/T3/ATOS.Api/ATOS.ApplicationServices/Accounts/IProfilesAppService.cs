using ATOS.Accounts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATOS.ApplicationServices.Accounts
{
    public interface IProfilesAppService
    {
        Task<List<ProfileDto>> GetProfilesAsync();
        Task<int> AddProfileAsync(ProfileDto profile);
        Task DeleteProfileAsync(int profileId);
        Task<ProfileDto> GetProfilesAsync(int profileId);
        Task EditoProfileAsync(ProfileDto profile);
    }
}
