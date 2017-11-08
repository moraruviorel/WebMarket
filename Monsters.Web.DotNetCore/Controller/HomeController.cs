using Microsoft.AspNetCore.Mvc;
using Monsters.Web.DotNetCore.Models.Home;

namespace Monsters.Web.DotNetCore//.Controller
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var homeModel = new HomeModel() { Message = "Hello World!" };
            return View("Index", homeModel);
        }
    }
}