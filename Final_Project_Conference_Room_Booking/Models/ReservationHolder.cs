using System;
using System.Collections.Generic;

namespace Final_Project_Conference_Room_Booking.Models
{
    public partial class ReservationHolder
    {  
        public int Id { get; set; }
        public string CardNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Notes { get; set; } = null!;
        public int BookingId { get; set; }
        public virtual Booking? Booking { get; set; } 
    }
}
