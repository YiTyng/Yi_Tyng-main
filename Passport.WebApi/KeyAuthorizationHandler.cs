namespace Passport.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Principal;
    using System.Threading;
    using System.Threading.Tasks;
    using EnsureThat;

    internal sealed class AuthorizationHandler : DelegatingHandler
    {
        private const string AuthenticationScheme = "Key";
        private const string AuthenticationName = "InternalService";

        private readonly HashSet<string> acceptableKeys;

        public AuthorizationHandler(IEnumerable<string> acceptableKeys)
        {
            EnsureArg.IsNotNull(acceptableKeys, nameof(acceptableKeys));

            var collection = acceptableKeys.ToList();
            EnsureArg.HasItems(collection, nameof(acceptableKeys));

            this.acceptableKeys = new HashSet<string>(collection);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            EnsureArg.IsNotNull(request, nameof(request));
            cancellationToken.ThrowIfCancellationRequested();
            var authorization = request.Headers.Authorization;

            if (authorization == null ||
                !authorization.Scheme.Equals(AuthenticationScheme, StringComparison.OrdinalIgnoreCase) ||
                string.IsNullOrEmpty(authorization.Parameter) ||
                !this.acceptableKeys.Contains(authorization.Parameter))
            {
                return base.SendAsync(request, cancellationToken);
            }

            request.GetRequestContext().Principal = new GenericPrincipal(new GenericIdentity(AuthenticationName), new[] { AuthenticationName });
            return base.SendAsync(request, cancellationToken);
        }
    }
}