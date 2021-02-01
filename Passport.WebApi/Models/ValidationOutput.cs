namespace Passport.WebApi.Models
{
    public sealed class ValidationOutput
    {
        public bool IsValidPassportNumber { get; set; }
        //Add additional result return properties

        public bool IsValidDateofBirthDigit { get; set; }
        public bool IsValidPassportExpiredDate { get; set; }
        public bool IsValidPersonalNumber { get; set; }
        public bool IsValidFinalCheck { get; set; }
        public bool IsValidGender { get; set; }
        public bool IsValidDateofBirthCrossCheck { get; set; }
        public bool IsValidPassportExpiredCrossCheck { get; set; }
        public bool IsValidNationalityCode { get; set; }
        public bool IsValidPassportNumberCrossCheck { get; set; }
    }
}
