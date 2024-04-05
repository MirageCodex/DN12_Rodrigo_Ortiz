using ATOS.Accounts.Dto;
using ATOS.ApplicationServices.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace ATOS.Api.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersAppServices _usersAppServices;
        Serilog.ILogger _logger;

        public UsersController(IUsersAppServices usersAppServices, Serilog.ILogger logger)
        {
            _usersAppServices = usersAppServices;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<List<UserDto>> Get()
        {
            List<UserDto> users = await _usersAppServices.GetUsersAsync();
            _logger.Information("Total users retrieved: " + users?.Count);
            return users;
        }

        [HttpGet("{id}")]
        public async Task<UserDto> Get(int id)
        {
            UserDto user = await _usersAppServices.GetUsersAsync(id);
            _logger.Information("Get user: " + id);
            return user;
        }
    }
}
