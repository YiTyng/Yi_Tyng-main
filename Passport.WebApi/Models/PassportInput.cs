namespace Passport.WebApi.Models
{
    using System;

    public sealed class PassportInput
    {
        public string PassportNumber { get; set; }

        //Add additional properties for passport input
        public string Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string PersonalNumber { get; set; }
        public string MRZLineTwo { get; set; }
    }
}