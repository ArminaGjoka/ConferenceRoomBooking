using System;
using System.Collections.Generic;

namespace Final_Project_Conference_Room_Booking.Models
{
    public partial class ConferenceRoom
    {
        public ConferenceRoom()
        {
            Bookings = new HashSet<Booking>();
            UnavailabilityPeriods = new HashSet<UnavailabilityPeriod>();
        }

        public int Id { get; set; } 
        public string Code { get; set; } 
        public int MaxCapacity { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<UnavailabilityPeriod> UnavailabilityPeriods { get; set; }
    }
}
