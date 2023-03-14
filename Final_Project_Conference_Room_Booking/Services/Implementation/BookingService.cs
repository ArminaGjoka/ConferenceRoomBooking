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

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;

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
   
        public async Task<Booking> Create(Booking booking)
        {
            // Validate that the booking has a valid start and end time
            if (booking.StartDate >= booking.EndDate)
            {
                throw new Exception("The booking start time must be before the end time.");
            }

            return await _bookingRepository.Create(booking);
        }

        public async Task<Booking> DeleteBooking(int id)
        {
            // Validate that the id is not negative
            if (id <= 0)
            {
                throw new Exception("Invalid booking id.");
            }

            return await _bookingRepository.DeleteBooking(id);
        }

       
        public async Task<Booking> FindBooking(int id)
        {
            // Validate that the id is not negative
            if (id <= 0)
            {
                throw new Exception("Invalid booking id.");
            }

            return await _bookingRepository.FindBooking(id);
        }

        public async Task<Booking> Edit(int id)
        {
            // Validate that the id is not negative
            if (id <= 0)
            {
                throw new Exception("Invalid booking id.");
            }

            return await _bookingRepository.FindBooking(id);
        }

       
        public async Task<Booking> Edit(Booking booking)
        {
            // Validate that the booking has a valid start and end time
            if (booking.StartDate >= booking.EndDate)
            {
                throw new Exception("The booking start time must be before the end time.");
            }

            return await _bookingRepository.Edit(booking);
        }
    
        public async Task<Booking> Confirm(int id)
        {
            // Validate that the id is not negative
            if (id <= 0)
            {
                throw new Exception("Invalid booking id.");
            }

            // Find the booking with the specified id
            var booking = await _bookingRepository.FindBooking(id);

            // Validate that the booking exists
            if (booking == null)
            {
                throw new Exception("Booking not found.");
            }

            // Set the booking status to confirmed

            booking.IsConfirmed = true;

            return await _bookingRepository.Edit(booking);

        }
        public async Task<bool> CheckBookingConflict(Booking existingBooking, Booking newBooking)
        {
          
            if (newBooking.StartDate >= existingBooking.StartDate && newBooking.StartDate < existingBooking.EndDate)
            {
                throw new Exception("The new Booking cannot be in the same period like the existing Booking");
                return true;
            }

            
            if (newBooking.StartDate <= existingBooking.StartDate && newBooking.EndDate >= existingBooking.EndDate)
            {
                return false;
            }

            // No scheduling conflict was found
            return false;
        }

   

     
    }
}