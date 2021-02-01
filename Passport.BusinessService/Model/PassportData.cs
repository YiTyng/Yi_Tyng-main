using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.BusinessService
{
    public sealed class PassportData
    {
        public string PassportNumber { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string PersonalNumber { get; set; }
        public string MRZLineTwo { get; set; }
    }
}
