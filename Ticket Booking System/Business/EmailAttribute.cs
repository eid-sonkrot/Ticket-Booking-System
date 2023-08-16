using System.ComponentModel.DataAnnotations;

namespace TicketBookingSystem.Business
{
    public class EmailAttribute : ValidationAttribute
    {
        // In this method, we implement validation functionality for an email.
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var email = value.ToString();
            var pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
        }
    }
}
