using System;
using System.Collections.Generic;

namespace Final_Project_Conference_Room_Booking.Models
{
    public class UnavailabilityPeriod 
    {
        public int Id { get; set; }

        [UnavailabilityPeriodValidation]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ConferenceRoomId { get; set; }
        public virtual ConferenceRoom? ConferenceRoom { get; set; } 
        
    }
}
