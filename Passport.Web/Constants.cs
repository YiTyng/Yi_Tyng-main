namespace Passport.Web
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public static class Constants
    {
        public static readonly IReadOnlyCollection<SelectListItem> Genders = new List<SelectListItem>
        {
            new SelectListItem { Text = "Male", Value = "M" },
            new SelectListItem { Text = "Female", Value = "F" },
            new SelectListItem { Text = "Unspecified", Value = "<" },
        }
        .AsReadOnly();

        public static readonly IReadOnlyCollection<SelectListItem> Countries = new List<SelectListItem>
        {
            new SelectListItem { Text = "Australia", Value = "AUS" },            
            new SelectListItem { Text = "China", Value = "CHN" },            
            new SelectListItem { Text = "Indonesia", Value = "IDN" },            
            new SelectListItem { Text = "Malaysia", Value = "MYS" },            
            new SelectListItem { Text = "United Kingdom", Value = "GBR" },
            new SelectListItem { Text = "United States of America", Value = "USA" },            
        }
        .AsReadOnly();
    }
}