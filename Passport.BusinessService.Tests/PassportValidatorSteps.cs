namespace Passport.BusinessService.Tests
{
    using System;
    using FluentAssertions;
    using Passport.BusinessService;

    internal sealed class PassportValidatorSteps
    {
        private readonly PassportValidator target = new PassportValidator();
        private PassportData input;
        private ValidationResult actualResult;
        private Action action;
        public PassportValidatorSteps GivenIHaveTheInput(PassportData data)
        {
            this.input = data;
            return this;
        }

        public PassportValidatorSteps WhenIValidateTheData()
        {
            this.actualResult = target.Validate(this.input);
            return this;
        }

        public PassportValidatorSteps WhenIValidateTheInvalidData()
        {
            this.action = () => this.WhenIValidateTheData();
            return this;
        }

        public PassportValidatorSteps ThenTheValidationResultShouldBe(ValidationResult expected)
        {
            this.actualResult.Should().NotBeNull();
            this.actualResult.Should().BeEquivalentTo(expected);
            return this;
        }

        public PassportValidatorSteps ThenAnExceptionIsThrown<T>()
            where T : Exception
        {
            this.action.Should().NotBeNull();
            this.action.Should().ThrowExactly<T>();
            return this;
        }
    }
}
