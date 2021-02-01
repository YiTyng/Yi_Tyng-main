namespace Passport.Web.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public sealed class PassportModel
    {
        [Required]
        [DisplayName("Passport no.")]
        //Data Annotations?
        public string PassportNumber { get; set; }

        //Add/Extend Passport Input data here
        [DisplayName("Nationality")]
        public string Nationality { get; set; }

        [DisplayName("Date of birth")]
        public DateTime? DateOfBirth { get; set; } = DateTime.Now;

        public string Gender { get; set; }

        [DisplayName("Date of expiry")]
        public DateTime? ExpiryDate { get; set; } = DateTime.Now;

        [DisplayName("Personal no.")]
        public string PersonalNumber { get; set; }

        [DisplayName("MRZ line 2")]
        public string MRZLineTwo { get; set; }
    }
}