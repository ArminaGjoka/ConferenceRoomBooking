using System;
using System.Collections.Generic;


namespace Final_Project_Conference_Room_Booking.Models
{
    public  class Booking
    {
        public Booking()
        {
            ReservationHolders = new HashSet<ReservationHolder>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public int Capacity { get; set; }
      
     
        public int RoomId { get; set; }

        [BookingValidation]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsDeleted { get; set; }
        public int? ConfirmedFromId { get; set; }

        public virtual ApplicationUser? ConfirmedFrom { get; set; }
        public virtual ConferenceRoom Room { get; set; } = null!;
        public virtual ICollection<ReservationHolder> ReservationHolders { get; set; }
    }
}
