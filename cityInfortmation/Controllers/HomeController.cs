using CityInformation.Models.Entities;
using CityInformation.Models;
using cityInfortmation.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using cityInfo.Controllers;

namespace cityInfortmation.Controllers
{
    public class HomeController : Controller
    {
    
        public static int yetkiliId;
   
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("denied")]
        public IActionResult Denied()
        {
            return View();
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Validate(string username, string password, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            using (var db = new Context())
            {
            
                foreach (var item in db.Authorized.ToList())
                {
                    var autho = item;
                    if (username == ilYetkilisiController.crypt.Decrypt(autho.authorizedUserName, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256) && password == ilYetkilisiController.crypt.Decrypt(autho.authorizedPassword, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256) && ilYetkilisiController.crypt.Decrypt(autho.Roles, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256) == "D")
                    {
                        claimMaker(username, password, "Developer",item.authorizedId.ToString());
                        RedirectToAction("Index", "developer");
                       
                    }
                    if (username == ilYetkilisiController.crypt.Decrypt(autho.authorizedUserName, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256) && password == ilYetkilisiController.crypt.Decrypt(autho.authorizedPassword, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256) && ilYetkilisiController.crypt.Decrypt(autho.Roles, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256) == "Y")
                    {
                        claimMaker(username,password,"Yetkili", item.authorizedId.ToString());
                        RedirectToAction("addCity", "ilYetkilisi");
                        yetkiliId = autho.authorizedId;
                    }
                    if (username == ilYetkilisiController.crypt.Decrypt(autho.authorizedUserName, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256) && password == ilYetkilisiController.crypt.Decrypt(autho.authorizedPassword, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256) && ilYetkilisiController.crypt.Decrypt(autho.Roles, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256) == "A")
                    {
                        claimMaker(username, password, "Admin", item.authorizedId.ToString());
                        RedirectToAction("Index", "Admin");
                    }
                }
                
                TempData["Error"] = "Hata, kullanıcı adı veya şifre geçersizdir.";
                return View("login");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
        public void claimMaker(string username, string password, string role,string id)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("username", username));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
            claims.Add(new Claim(ClaimTypes.Name, username));
            claims.Add(new Claim(ClaimTypes.Role, role));
            claims.Add(new Claim("id", id));
            var claimsIdendity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdendity);
            HttpContext.SignInAsync(claimsPrincipal);
        }


    }
}
