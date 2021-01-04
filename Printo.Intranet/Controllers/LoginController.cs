using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Printo.Data.Data;
using Printo.Data.Helpers;

namespace Printo.Intranet.Controllers
{
    public class LoginController : Controller
    {
        private readonly PrintoContext _context;

        public LoginController(PrintoContext context) 
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {

            User account = _context.Users.FirstOrDefault(u => u.Login == user.Login);

            if (account != null)
            {
                if (account.IsActive == false)
                {
                    ModelState.AddModelError("", "Twoje konto zostało dezaktywowane.");
                    return View();
                }
                else
                if (HashPassword.VerifyMd5Hash(user.Password, account.Password))
                {
                    HttpContext.Session.SetString("UserID", account.UserID.ToString());
                    HttpContext.Session.SetString("UserTypeID", account.UserTypeID.ToString());
                    HttpContext.Session.SetString("Login", account.Login.ToString());
                    HttpContext.Session.SetString("Name", account.Name.ToString());

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Błędne hasło");
                }
                return View();
            }

            if (account == null)
            {
                ModelState.AddModelError("", "Błędny login");
                return View();
            }
            else
                return View();

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
