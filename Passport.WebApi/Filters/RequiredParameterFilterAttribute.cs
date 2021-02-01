namespace Passport.WebApi.Filters
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using EnsureThat;

    public sealed class RequiredParameterFilterAttribute : ActionFilterAttribute
    {
        private readonly string parameterName;

        public RequiredParameterFilterAttribute(string parameterName)
        {
            this.parameterName = EnsureArg.IsNotNullOrEmpty(parameterName, nameof(parameterName));
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments[this.parameterName] != null)
            {
                return;
            }

            string msg = FormattableString.Invariant($"Missing required parameter '{this.parameterName}'.");
            HttpError error = new HttpError(msg);
            actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
        }
    }
}