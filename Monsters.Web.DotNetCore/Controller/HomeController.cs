﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Monsters.Web.DotNetCore.Models.Home;

namespace Monsters.Web.DotNetCore
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var homeModel = new HomeModel() { Message = "Hello World!" };
            return View("Index", homeModel);
        }
    }
}