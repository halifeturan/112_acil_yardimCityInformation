using Microsoft.AspNetCore.Mvc;

namespace cityInfortmation.Controllers
{
    public class firstPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
