namespace Passport.WebApi
{
    using System;
    using System.Web;

    public sealed class TrimResponseHeaderModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            if (context != null)
            {
                context.PreSendRequestHeaders += OnPreSendRequestHeaders;
            }
        }

        private static void OnPreSendRequestHeaders(object sender, EventArgs e)
        {
            var context = HttpContext.Current;

            if (context != null)
            {
                HttpContextWrapper wrapper = new HttpContextWrapper(context);
                wrapper.Response.Headers.Remove("Server");
            }
        }
    }
}