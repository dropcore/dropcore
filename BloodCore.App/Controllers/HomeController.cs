using System.Web.Mvc;

namespace BloodCore.App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("HELLO WORLD");
        }
    }
}