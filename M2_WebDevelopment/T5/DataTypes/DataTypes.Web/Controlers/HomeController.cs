using Microsoft.AspNetCore.Mvc;

namespace DataTypes.Web.Controlers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
