using System.ComponentModel.DataAnnotations;

namespace TicketBookingSystem.Business
{
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var email = value.ToString();
            // You can use regular expressions or other validation methods.
            var pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
        }
    }
}
