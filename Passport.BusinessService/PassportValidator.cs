using System;
using System.Collections.Generic;
using System.Linq;

namespace Passport.BusinessService
{
    public class PassportValidator
    {
        public static string PassportNum { get; set; }
        public static string DOB { get; set; }
        public static string ExpiredDate { get; set; }

        public ValidationResult Validate(PassportData input)
        {            
            //Add your core validation logic here
            var result = new ValidationResult
            {
                IsValidPassportNumber = true,
                IsValidDateofBirthDigit = ValidateDateDetails(input.DateOfBirth),
                IsValidPassportExpiredDate = ValidateDateDetails(input.ExpiryDate),
                IsValidPersonalNumber = ValidateDetails(input.PersonalNumber),               
                IsValidGender = ValidateGenderDetails(input.Gender),
                IsValidNationalityCode = ValidateDetails(input.Nationality),
                IsValidDateofBirthCrossCheck = CrossCheckDOB(input.MRZLineTwo, input.DateOfBirth),
                IsValidPassportExpiredCrossCheck = CrossCheckExpired(input.MRZLineTwo, input.ExpiryDate),
                IsValidPassportNumberCrossCheck = CrossCheck(input.MRZLineTwo, input.PassportNumber),
                IsValidFinalCheck = FinalCheck(input),
            };
            return result;
        }

        #region Validation
        private bool ValidateDetails (string data)
        {
            return string.IsNullOrEmpty(data) ? false : true;
        }

        private bool ValidateGenderDetails(string data)
        {
            return string.IsNullOrEmpty(data) ? false : data == "<" ? false : true;
        }

        private bool ValidateDateDetails(DateTime data)
        {
            return data < DateTime.Now ? true : false;
        }
        #endregion

        #region Check Digit
        private int CheckDate(DateTime dateInput)
        {
            string dateVal = dateInput.ToString("yyMMdd");
            return CheckDigit(dateVal);
        }

        private int CheckDigit(string input)
        {
            int finalValue = 0;
            try
            {
                var inputData = input.ToArray();
                int val = 0;

                List<int> weightDigit = new List<int>() { 7, 3, 1 };

                List<int> inputValue = new List<int>();

                foreach (var d in inputData)
                {
                    val = GetValue(d.ToString());
                    inputValue.Add(val);
                }

                List<int> products = new List<int>();
                int tempVal = 0;
                int tempWeightVal = 0;
                for (int i = 0; i < inputValue.Count; i++)
                {
                    int weight = 0;
                    if (i > 2)
                    {
                        weight = weightDigit[i - (3 * tempWeightVal)];
                    }
                    else
                    {
                        weight = weightDigit[i];
                    }
                    tempVal++;
                    if (tempVal == 3)
                    {
                        tempVal = 0;
                        tempWeightVal++;
                    }
                    products.Add(inputValue[i] * weight);
                }
                finalValue = products.Sum() % 10;
            }
            catch (Exception)
            {

            }
            return finalValue;
        }

        private int GetValue(string charInput)
        {
            int val = 0;
            switch (charInput)
            {
                case "<":
                    val = 0;
                    break;
                case "A":
                    val = 10;
                    break;
                case "B":
                    val = 11;
                    break;
                case "C":
                    val = 12;
                    break;
                case "D":
                    val = 13;
                    break;
                case "E":
                    val = 14;
                    break;
                case "F":
                    val = 15;
                    break;
                case "G":
                    val = 16;
                    break;
                case "H":
                    val = 17;
                    break;
                case "I":
                    val = 18;
                    break;
                case "J":
                    val = 19;
                    break;
                case "K":
                    val = 20;
                    break;
                case "L":
                    val = 21;
                    break;
                case "M":
                    val = 22;
                    break;
                case "N":
                    val = 23;
                    break;
                case "O":
                    val = 24;
                    break;
                case "P":
                    val = 25;
                    break;
                case "Q":
                    val = 26;
                    break;
                case "R":
                    val = 27;
                    break;
                case "S":
                    val = 28;
                    break;
                case "T":
                    val = 29;
                    break;
                case "U":
                    val = 30;
                    break;
                case "V":
                    val = 31;
                    break;
                case "W":
                    val = 32;
                    break;
                case "X":
                    val = 33;
                    break;
                case "Y":
                    val = 34;
                    break;
                case "Z":
                    val = 35;
                    break;
                default:
                    val = Convert.ToInt32(charInput);
                    break;
            }

            return val;
        }
        #endregion

        #region Cross Check
        private bool FinalCheck(PassportData input)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(input.PersonalNumber) && !string.IsNullOrEmpty(PassportNum) && !string.IsNullOrEmpty(DOB) && !string.IsNullOrEmpty(ExpiredDate))
            {
                string personalNum = input.PersonalNumber.PadRight(14, '<');
                int chkDigitPersonalNum = CheckDigit(personalNum);
                int chkFinalDigit = CheckDigit(string.Format("{0}{1}{2}{3}{4}", PassportNum, DOB, ExpiredDate, personalNum, chkDigitPersonalNum.ToString()));

                string finalDigit = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", PassportNum, input.Nationality, DOB, input.Gender, ExpiredDate, personalNum, chkDigitPersonalNum.ToString(), chkFinalDigit.ToString());

                result = input.MRZLineTwo == finalDigit ? true : false;
            }
          
            return result;
        }

        private bool CrossCheck(string lineTwo, string input)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(lineTwo))
            {
                string newCross = lineTwo.Substring(0, 10);
                int chkdigit = CheckDigit(input);

                PassportNum = string.Format("{0}{1}", input.PadRight(9, '<'), chkdigit.ToString());
                result = newCross == PassportNum ? true : false;
            }
            return result;
        }

        private bool CrossCheckDOB(string lineTwo, DateTime dateInput)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(lineTwo))
            {
                string newCross = lineTwo.Substring(13, 7);
                int chkdigit = CheckDate(dateInput);

                DOB = string.Format("{0}{1}", dateInput.ToString("yyMMdd"), chkdigit.ToString());
                result = newCross == DOB ? true : false;
            }
            return result;
        }

        private bool CrossCheckExpired(string lineTwo, DateTime dateInput)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(lineTwo))
            {
                string newCross = lineTwo.Substring(21, 7);
                int chkdigit = CheckDate(dateInput);

                ExpiredDate = string.Format("{0}{1}", dateInput.ToString("yyMMdd"), chkdigit.ToString());
                result = newCross == ExpiredDate ? true : false;
            }
            return result;
        }

        #endregion
    }
}
