using Microsoft.AspNetCore.Mvc;

namespace UsersApp.Controllers
{
    public class MapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
