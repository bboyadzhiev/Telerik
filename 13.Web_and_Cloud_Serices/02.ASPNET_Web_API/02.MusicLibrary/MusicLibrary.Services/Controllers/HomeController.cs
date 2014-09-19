namespace MusicLibrary.Services.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Music Library";

            return View();
        }
    }
}