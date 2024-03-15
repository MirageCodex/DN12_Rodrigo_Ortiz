using GymManager.Core.Members;
using GymManager.DataAccess;
using GymManager.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Web.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly GymManagerContext _context;
        public UsersController(UserManager<IdentityUser> userManager,GymManagerContext context) 
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task <IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel userViewModel)
        {

            var result = await _userManager.CreateAsync(new IdentityUser 
            { 
                Email = userViewModel.UserName, 
                EmailConfirmed = true,
                UserName = userViewModel.UserName,
                PhoneNumber = userViewModel.PhoneNumber

            },userViewModel.Password);

            if (result.Succeeded) 
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors) 
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return View();
            }
        }
        public async Task<IActionResult> Edit(string userID)
        {
            var user = await _userManager.FindByIdAsync(userID);

            UserViewModel viewModel = new UserViewModel
            {
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Id = user.Id
            };

            return View(viewModel); 
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel userViewModel)
        {

            var user = await _userManager.FindByIdAsync(userViewModel.Id);
            user.PhoneNumber = userViewModel.PhoneNumber;
            string hashedNewPassword = _userManager.PasswordHasher.HashPassword(user,userViewModel.Password);
            UserStore<IdentityUser> store = new UserStore<IdentityUser>(_context);
            await store.SetPasswordHashAsync(user, hashedNewPassword);
            await store.UpdateAsync(user);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string userId)
        {

            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
    }
}
