namespace Passport.Web
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using EnsureThat;
    using Models;
    using Newtonsoft.Json;

    public sealed class WebApiClient
    {
        private const string AuthorizationScheme = "Key";
        private const string ContentTypeHeader = "application/json";

        private readonly HttpClient client;
        private readonly Uri apiEndpoint;
        private readonly string authorizationkey;

        public WebApiClient(
            HttpClient client,
            Uri apiEndpoint,
            string authorizationkey)
        {
            this.client = EnsureArg.IsNotNull(client, nameof(client));
            this.apiEndpoint = EnsureArg.IsNotNull(apiEndpoint, nameof(apiEndpoint));
            this.authorizationkey = EnsureArg.IsNotNullOrWhiteSpace(authorizationkey, nameof(authorizationkey));
        }

        public async Task<ValidationModel> ValidatePassportAsync(PassportModel input, CancellationToken cancellationToken)
        {
            EnsureArg.IsNotNull(input, nameof(input));
            cancellationToken.ThrowIfCancellationRequested();

            var requestUri = new Uri(apiEndpoint, "api/passportvalidation/");

            using (var request = new HttpRequestMessage(HttpMethod.Post, requestUri))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue(AuthorizationScheme, authorizationkey);
                var jsonBody = JsonConvert.SerializeObject(input);
                request.Content = new StringContent(jsonBody, Encoding.UTF8, ContentTypeHeader);
                var result = await this.client.SendAsync(request, cancellationToken).ConfigureAwait(false);
                string resultString = await result.Content.ReadAsStringAsync();
                var apiResponseData = JsonConvert.DeserializeObject<ValidationModel>(resultString);

                return apiResponseData;
            }
        }
    }
}