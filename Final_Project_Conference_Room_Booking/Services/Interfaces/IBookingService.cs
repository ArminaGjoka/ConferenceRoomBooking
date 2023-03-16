using Final_Project_Conference_Room_Booking.Models;

namespace Final_Project_Conference_Room_Booking.Services.Interfaces
{
    public interface IBookingService
    {
        Task<List<Booking>> GetAllTheBookings();
        Task<Booking> Create(Booking booking, ConferenceRoom conference);
        Task<Booking> DeleteBooking(int id);
        Task<Booking> FindBooking(int id);
        Task<Booking> Edit(int id);
        Task<Booking> Edit(Booking booking);
        Task<Booking> Confirm(int id);
        
    }
}
