using System.ComponentModel.DataAnnotations;

namespace GigHub.Core.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            //DateTime datetime;
            //var isValid = DateTime.TryParseExact(Convert.ToString(value),
            //    "d MMM YYYY",
            //    CultureInfo.CurrentCulture,
            //    DateTimeStyles.None,
            //    out datetime);

            //return (isValid && datetime > DateTime.Now);
            return true;
        }
    }
}