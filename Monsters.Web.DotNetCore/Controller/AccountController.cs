using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Monsters.Web.DotNetCore.Models.Account;
using Microsoft.AspNetCore.Authorization;

namespace Monsters.Web.DotNetCore
{
    [Authorize]
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}