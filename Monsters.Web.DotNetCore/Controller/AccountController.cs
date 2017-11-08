using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Monsters.Web.DotNetCore.Models.Account;

namespace Monsters.Web.DotNetCore
{
    public class AccountController : Controller
    {
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        public IActionResult Login(LoginModel loginModel)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}