using System.Web.Mvc;
using BackEnd;

namespace AwesomeApp.Controllers
{
    public class HomeController : Controller
    {
        private IBackEnd backEnd;

        public HomeController()
        {
            this.backEnd = new BackEnd.BackEnd();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}