using Final_Project_Conference_Room_Booking.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Final_Project_Conference_Room_Booking.Models
{
    public class AttendeesValidationAttribute : ValidationAttribute
    {
        private readonly IBookingService _bookingService;
        private readonly IConferenceRoomService _conferenceRoomService;
        public AttendeesValidationAttribute(IBookingService bookingService, IConferenceRoomService conferenceRoomService)
        {
            _bookingService = bookingService;
            _conferenceRoomService = conferenceRoomService;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var booking = (Booking)validationContext.ObjectInstance;
            var conferenceRoom = (ConferenceRoom)validationContext.ObjectInstance;

            if (booking.Capacity > conferenceRoom.MaxCapacity)
            {
                return new ValidationResult($"The number of attendees ({booking.Capacity}) cannot exceed the maximum capacity of the conference room ({conferenceRoom.MaxCapacity}).");
            }

            return ValidationResult.Success;
        }

    }
}
