using Microsoft.AspNetCore.Mvc;

namespace GymManager.Web.Controllers
{
    public class AttendanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
