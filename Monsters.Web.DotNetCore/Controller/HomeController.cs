using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Monsters.Web.DotNetCore.Models.Home;

namespace Monsters.Web.DotNetCore//.Controller
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //[AutoValidateAntiforgeryToken]
        //[Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            var homeModel = new HomeModel() { Message = "Hello World!" };
            return View("Index", homeModel);
        }
    }
}