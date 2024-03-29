﻿using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Conference_Room_Booking.Repositories.Implementation
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ConferenceRoomBookingContext _context;

        public BookingRepository(ConferenceRoomBookingContext context)
        {
            _context = context;
        }
        public async Task<List<Booking>> GetAllTheBookings(DateTime data)
        {

            var bookingList = await _context.Bookings.Where(s => s.StartDate == data && s.IsDeleted == false).ToListAsync();       
            return bookingList;
        }

        public async Task<List<Booking>> GetAllTheBookings()
        {

            var bookingList = await _context.Bookings.Where(x => x.IsDeleted == false).ToListAsync();

            if (bookingList == null || bookingList.Count == 0)
            {
                throw new Exception("No bookings found.");
            }

            return bookingList;
        }

        public async Task<Booking> Create(Booking booking)
        {
          
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
 
        public async Task<Booking> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                throw new ArgumentException($"Booking with ID {id} does not exist.");
            }

            booking.IsDeleted = true;
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();

            return booking;
        }
   
        public async Task<Booking> FindBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                throw new ArgumentException($"Booking with ID {id} does not exist.");
            }

            return booking;
        }
  
        public async Task<Booking> Edit(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                throw new ArgumentException($"Booking with ID {id} does not exist.");
            }

            return booking;
        }
  
        public async Task<Booking> Edit(Booking booking)
        {
            if (booking.StartDate > booking.EndDate)
            {
                throw new ArgumentException("Booking start time must be before end time.");
            }

            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> Confirm(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                throw new ArgumentException($"Booking with ID {id} does not exist.");
            }

            booking.IsConfirmed = true;
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();

            return booking;
        }

    }
}
