using CityInformation.Models.Entities;
using CityInformation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using static cityInfo.Controllers.ilYetkilisiController;

namespace cityInfortmation.Controllers
{
    [Authorize(Roles ="Admin")]
    public class adminController : Controller
    {

        public static Crypt crypt = new Crypt();
        public IActionResult Index()
        {
            using (var dbContext = new Context())
            {
                var city = dbContext.CityProp.ToList();
                return View(city);
            }
          
        }
        public IActionResult listPersonal()
        {
            using (var dbContext = new Context())
            {
                var autho = dbContext.Authorized.ToList();
                return View(autho);
            }
        }
        public IActionResult addPersonal()
        {
            using (var dbContext = new Context())
            {
                return View(dbContext.Authorized.ToList());
            }
        }
        [HttpPost]

        public IActionResult addPersonal(Authorized autho)
        {
            string CRYPTauthoName = crypt.Encrypt(autho.authorizedUserName, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
            autho.authorizedUserName = CRYPTauthoName;
            string CRYPTauthoPass= crypt.Encrypt(autho.authorizedPassword, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
            autho.authorizedPassword = CRYPTauthoPass;
            string CRYPTauthoRoles= crypt.Encrypt(autho.Roles, "a102193198482", "a1021931984823", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
            autho.Roles = CRYPTauthoRoles;
            using (var db = new Context())
                {
                if (db.Authorized.Find(autho.authorizedId) == null)
                {
                    db.Authorized.Add(autho);
                    db.SaveChanges();
                }
                else
                {
                    ViewData["Hata"] = "Benzersiz kullanıcı Id'leri kullanınız. Daha önce böyle bir kayıt yapılmış.";
                }
               
                }
            
            return RedirectToAction("listPersonal", "admin");
        }

        public IActionResult deleteCity(int id)
        {
            using (var db = new Context())
            {
                var city = db.CityProp.Find(id);
                db.CityProp.Remove(city);
                db.SaveChanges();
            }
            return RedirectToAction("Index","admin");
        }
      
        public IActionResult deletePersonal(int id)
        {
            using (var db = new Context())
            {
                var autho = db.Authorized.Find(id);
                db.Authorized.Remove(autho);
                db.SaveChanges();
            }
            return RedirectToAction("listPersonal", "admin");
        }
    }
}
