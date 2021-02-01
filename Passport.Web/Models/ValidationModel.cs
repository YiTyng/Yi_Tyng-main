namespace Passport.Web.Models
{
    using System.ComponentModel;

    public sealed class ValidationModel
    {
        [DisplayName("Passport no. check digit")]
        public bool IsValidPassportNumber { get; set; }
        //Add additional validation flag here

        [DisplayName("Date of birth check digit")]
        public bool IsValidDateofBirthDigit { get; set; }
        [DisplayName("Passport expire date check digit")]
        public bool IsValidPassportExpiredDate { get; set; }
        [DisplayName("Personal no. check digit")]
        public bool IsValidPersonalNumber { get; set; }
        [DisplayName("Final check digit")]
        public bool IsValidFinalCheck { get; set; }
        [DisplayName("Gender cross check")]
        public bool IsValidGender { get; set; }
        [DisplayName("Date of birth cross check")]
        public bool IsValidDateofBirthCrossCheck { get; set; }
        [DisplayName("Passport expired date cross check")]
        public bool IsValidPassportExpiredCrossCheck { get; set; }
        [DisplayName("Nationality code cross check")]
        public bool IsValidNationalityCode { get; set; }
        [DisplayName("Passport no. cross check")]
        public bool IsValidPassportNumberCrossCheck { get; set; }
    }
}