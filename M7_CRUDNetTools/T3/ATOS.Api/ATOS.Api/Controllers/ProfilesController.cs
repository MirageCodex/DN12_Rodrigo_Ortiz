using ATOS.Accounts.Dto;
using ATOS.ApplicationServices.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace ATOS.Api.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly IProfilesAppService _profilesAppService;
        Serilog.ILogger _logger;

        public ProfilesController(IProfilesAppService profilesAppService, Serilog.ILogger logger)
        {
            _profilesAppService = profilesAppService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<ProfileDto>> Get()
        {
            List<ProfileDto> profiles = await _profilesAppService.GetProfilesAsync();
            _logger.Information("Get all profiles: " + profiles);
            return profiles;
        }

        [HttpGet("{id}")]
        public async Task<ProfileDto> Get(int id)
        {
            ProfileDto profile = await _profilesAppService.GetProfilesAsync(id);
            _logger.Information("Get profile: " + id);
            return profile;
        }

        [HttpPost]
        public async Task<Int32> Post(ProfileDto entity)
        {
            var Result = await _profilesAppService.AddProfileAsync(entity);
            _logger.Information("New profile created: " + entity);
            return Result;
        }

        [HttpPut("{id}")]
        public async Task Put(int id, ProfileDto entity)
        {
            await _profilesAppService.EditoProfileAsync(entity);
            _logger.Information("Profile edited: " + entity);
        }
    }
}
