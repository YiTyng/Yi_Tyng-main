using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.BusinessService
{
    public sealed class ValidationResult
    {
        public bool IsValidPassportNumber { get; set; }
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
