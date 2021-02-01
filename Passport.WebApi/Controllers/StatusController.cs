namespace Passport.WebApi.Controllers
{
    using System.Web.Mvc;

    public sealed class StatusController : Controller
    {
        // GET: Status
        public ActionResult Index()
        {
            return View();
        }
    }
}