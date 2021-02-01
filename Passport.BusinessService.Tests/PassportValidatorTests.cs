namespace Passport.BusinessService.Tests
{
    using Passport.BusinessService;
    using System;
    using Xunit;

    public sealed class PassportValidatorTests
    {
        private readonly PassportValidatorSteps steps = new PassportValidatorSteps();

        [Fact]
        public void Sample()
        {
            var input = new PassportData
            {
                PassportNumber = "L898902C"
                //other input data?                
            };

            var expected = new ValidationResult
            {
                //what is the expected result?
            };

            this.steps
                .GivenIHaveTheInput(input)
                .WhenIValidateTheData()
                .ThenTheValidationResultShouldBe(expected);
        }

        //Add additional unit test cases here
    }
}
