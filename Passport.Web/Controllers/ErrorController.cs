namespace Passport.Web.Controllers
{
    using System.Web.Mvc;

    public sealed class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}