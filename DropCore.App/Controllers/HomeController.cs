using System.Web.Mvc;

namespace DropCore.App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("HELLO WORLD");
        }
    }
}