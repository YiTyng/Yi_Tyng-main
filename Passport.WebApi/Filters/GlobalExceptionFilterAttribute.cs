namespace Passport.WebApi.Filters
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Filters;

    public sealed class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <inheritdoc/>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            // Absorb unhandled exception, log context exception here if required.
            var error = new HttpError("Error occurred. Please contact support.");
            actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, error);
        }
    }
}