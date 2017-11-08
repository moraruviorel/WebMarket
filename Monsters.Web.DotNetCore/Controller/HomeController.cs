using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Monsters.Web.DotNetCore.Models.Home;

namespace Monsters.Web.DotNetCore//.Controller
{
    public class HomeController : Controller
    {
        //[AutoValidateAntiforgeryToken]
        [Authorize]
        public ActionResult Index()
        {
            var homeModel = new HomeModel() { Message = "Hello World!" };
            return View("Index", homeModel);
        }
    }
}