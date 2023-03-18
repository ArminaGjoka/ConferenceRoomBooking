using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Repositories.Implementation;
using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Final_Project_Conference_Room_Booking.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Final_Project_Conference_Room_Booking.Services.Implementation
{
    public class BookingService : IBookingService
    {

        private readonly IBookingRepository _bookingRepository;
        private readonly IConferenceRoomRepository _conferenceRoomRepository;

        public BookingService(IBookingRepository bookingRepository, IConferenceRoomRepository conferenceRoomRepository)
        {
            _bookingRepository = bookingRepository;
            _conferenceRoomRepository = conferenceRoomRepository;   
        }

        public async Task<List<Booking>> GetAllTheBookings(DateTime data)
        {
            return await _bookingRepository.GetAllTheBookings(data);
        }
      
        public async Task<List<Booking>> GetAllTheBookings()
        {
            var bookings = await _bookingRepository.GetAllTheBookings();

            if (bookings == null || !bookings.Any())
            {
                throw new Exception("There are no bookings in the system.");
            }

            return bookings;
        }
   
        public async Task<bool> Create(Booking booking)
        {
            var room = await _conferenceRoomRepository.FindConferenceRoom(booking.RoomId);

            if(booking.Capacity> room.MaxCapacity)
            {
                return false;
            }


            return true;
        }
       
        public async Task<Booking> DeleteBooking(int id)
        {
           
            if (id <= 0)
            {
                throw new Exception("Invalid booking id.");
            }

            return await _bookingRepository.DeleteBooking(id);
        }
     
        public async Task<Booking> FindBooking(int id)
        {
            
            if (id <= 0)
            {
                throw new Exception("Invalid booking id.");
            }

            return await _bookingRepository.FindBooking(id);
        }

        public async Task<Booking> Edit(int id)
        {
           
            if (id <= 0)
            {
                throw new Exception("Invalid booking id.");
            }

            return await _bookingRepository.FindBooking(id);
        }
      
        public async Task<Booking> Edit(Booking booking)
        {
           
            if (booking.StartDate >= booking.EndDate)
            {
                throw new Exception("The booking start time must be before the end time.");
            }

            return await _bookingRepository.Edit(booking);
        }
    
        public async Task<Booking> Confirm(int id)
        {
          
            if (id <= 0)
            {
                throw new Exception("Invalid booking id.");
            }

            
            var booking = await _bookingRepository.FindBooking(id);

           
            if (booking == null)
            {
                throw new Exception("Booking not found.");
            }
     

            booking.IsConfirmed = true;

            return await _bookingRepository.Edit(booking);

        }
     
    }
}