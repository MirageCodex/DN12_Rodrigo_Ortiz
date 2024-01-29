using Microsoft.AspNetCore.Mvc;

namespace GymManager.Web.Controllers
{
    public class MembersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
