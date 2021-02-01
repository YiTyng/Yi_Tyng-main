namespace Passport.Web.Controllers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using EnsureThat;
    using Models;

    public sealed class HomeController : Controller
    {
        private readonly WebApiClient client;

        public HomeController(WebApiClient client)
        {
            this.client = EnsureArg.IsNotNull(client, nameof(client));
        }
      
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> PassportValidation(PassportModel model)
        {
            using (CancellationTokenSource source = new CancellationTokenSource(TimeSpan.FromMinutes(1)))
            {
                var result = await this.client.ValidatePassportAsync(model, source.Token).ConfigureAwait(false);
                return View("Validate", result);
            }
        }
    }
}