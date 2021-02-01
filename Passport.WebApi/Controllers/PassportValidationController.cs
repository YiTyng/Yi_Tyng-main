namespace Passport.WebApi.Controllers
{
    using AutoMapper;
    using EnsureThat;
    using Filters;
    using Models;
    using Passport.BusinessService;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [Authorize]
    public sealed class PassportValidationController : ApiController
    {
        private readonly IMapper mapper;
        private readonly PassportValidator validator;

        public PassportValidationController(IMapper mapper, PassportValidator validator)
        {
            this.mapper = EnsureArg.IsNotNull(mapper, nameof(mapper));
            this.validator = EnsureArg.IsNotNull(validator, nameof(validator));
        }

        [RequiredParameterFilter("input")]
        public HttpResponseMessage Post([FromBody]PassportInput input)
        {
            try
            {
                var data = this.mapper.Map<PassportData>(input);

                var result = this.validator.Validate(data);
                var output = this.mapper.Map<ValidationOutput>(result);

                return this.Request.CreateResponse(HttpStatusCode.OK, output);

            }
            catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentException)
            {
                HttpError error = new HttpError("Invalid input!");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
            }
        }
    }
}