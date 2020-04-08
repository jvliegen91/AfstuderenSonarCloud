using System.Linq;
using Afstuderen2020.Data;
using Afstuderen2020.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Afstuderen2020.Controllers
{
    public class LoginController : Controller
    {
        private readonly Afstuderen2020Context _context;
        public LoginController(Afstuderen2020Context context)
        {
            _context = context;
        }

        // GET: SqlInjection
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("Id") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Welcome", "Login");           
            }
            
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            //Controleer of de gebruikersnaam en het wachtwoord in de database overeen komen.
            var userdetails = _context.Users.FromSqlRaw($"SELECT * From Users Where UserName='{model.UserName}' and Password Collate Latin1_general_CS_AS ='{model.Password}'").FirstOrDefault();
            if (userdetails == null)
            {
                ModelState.AddModelError("LoginErrorMessage", "Verkeerde gebruikersnaam of wachtwoord.");
                return View("Index", model);
            }
            else
            {
                HttpContext.Session.SetString("Id", $"{userdetails.Id}");
                HttpContext.Session.SetString("UserName", $"{userdetails.UserName}");
                HttpContext.Session.SetString("FirstName", $"{userdetails.FirstName}");
                HttpContext.Session.SetString("LastName", $"{userdetails.LastName}");
                HttpContext.Session.SetString("PictureId", $"{userdetails.PictureId}");
                HttpContext.Session.SetString("Address", $"{userdetails.Address}");
                HttpContext.Session.SetString("HouseNumber", $"{userdetails.HouseNumber}");
                HttpContext.Session.SetString("HouseNumberAddition", $"{userdetails.HouseNumberAddition}");
                HttpContext.Session.SetString("Residence", $"{userdetails.Residence}");
                HttpContext.Session.SetString("PhoneNumber", $"{userdetails.PhoneNumber}");
                HttpContext.Session.SetString("Email", $"{userdetails.Email}");
                HttpContext.Session.SetString("Role", $"{userdetails.Role}");
                return RedirectToAction("Welcome", "Login");
            }
        }

        public IActionResult Welcome()
        {
            if (HttpContext.Session.GetString("Id") == null)
            {
                return RedirectToAction("Index", "Login");            
            }
            else
            {
                ViewBag.Id = HttpContext.Session.GetString("Id");
                ViewBag.UserName = HttpContext.Session.GetString("UserName");
                ViewBag.FirstName = HttpContext.Session.GetString("FirstName");
                ViewBag.LastName = HttpContext.Session.GetString("LastName");
                ViewBag.PictureId = HttpContext.Session.GetString("PictureId");
                ViewBag.Address = HttpContext.Session.GetString("Address");
                ViewBag.HouseNumber = HttpContext.Session.GetString("HouseNumber");
                ViewBag.HouseNumberAddition = HttpContext.Session.GetString("HouseNumberAddition");
                ViewBag.Residence = HttpContext.Session.GetString("Residence");
                ViewBag.PhoneNumber = HttpContext.Session.GetString("PhoneNumber");
                ViewBag.Email = HttpContext.Session.GetString("Email");
                return View();
            }
                    
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}