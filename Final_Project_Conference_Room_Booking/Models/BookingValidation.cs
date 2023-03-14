using System.ComponentModel.DataAnnotations;

namespace Final_Project_Conference_Room_Booking.Models
{
    public class BookingValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var booking = (Booking) validationContext.ObjectInstance;

            if (booking.StartDate > booking.EndDate)
            {
                return new ValidationResult("Start Date cannot be greater than End Date");
            }
         
            return ValidationResult.Success;
        }
    }
}
