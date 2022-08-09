using CityInformation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace cityInfortmation.Controllers
{
    [Authorize(Roles ="Developer")]
    public class developerController : Controller
    {
        Context dbContext = new Context();
        public IActionResult Index()
        {
            var city = dbContext.CityProp.ToList();
            return View(city);
        }
    }
}
