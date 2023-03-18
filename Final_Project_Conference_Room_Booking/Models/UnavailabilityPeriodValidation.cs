using System.ComponentModel.DataAnnotations;


namespace Final_Project_Conference_Room_Booking.Models
{
    public class UnavailabilityPeriodValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var unavailabilityPeriod = (UnavailabilityPeriod)validationContext.ObjectInstance;

            if (unavailabilityPeriod.StartDate > unavailabilityPeriod.EndDate)
            {
                return new ValidationResult("Start Date cannot be greater than End Date");
            }
            if (unavailabilityPeriod.StartDate < DateTime.Now.AddDays(-1))
            {
                return new ValidationResult("Start Date cannot be in the past");
            }

            return ValidationResult.Success;
        }
    }
}
