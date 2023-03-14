using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Conference_Room_Booking.Repositories.Implementation
{
    public class ReservationHolderRepository:IReservationHolderRepository
    {
        private readonly ConferenceRoomBookingContext _context;

        public ReservationHolderRepository(ConferenceRoomBookingContext context)
        {
            _context = context;
        }

        public async Task<List<ReservationHolder>> GetAllReservationHolders()
        {
            var rHoldersList = await _context.ReservationHolders.ToListAsync();
            if (rHoldersList == null || rHoldersList.Count == 0)
            {
                throw new ArgumentException("The returned list is null or empty");
            }
            return rHoldersList;
        }
        public async Task<ReservationHolder> Create(ReservationHolder reservationHolder)
        {
            if (reservationHolder == null)
            {
                throw new ArgumentException("There is no input");
            }
            await _context.ReservationHolders.AddAsync(reservationHolder);
            await _context.SaveChangesAsync();
            return (reservationHolder);
        }
        public async Task<ReservationHolder> DeleteReservationHolder(int id)
        {
            var deleterecord = await _context.ReservationHolders.FindAsync(id);
            if (deleterecord == null)
            {
                throw new ArgumentException("the record is null");
            }
            
            _context.ReservationHolders.Remove(deleterecord);
            await _context.SaveChangesAsync();

            return deleterecord;
        }

        public async Task<ReservationHolder> FindReservationHolder(int id)
        {
            var authData = await _context.ReservationHolders.FindAsync(id);
            if (authData == null)
            {
                throw new ArgumentException("There is no reservation");
            }
            return authData;
        }

        public async Task<ReservationHolder> Edit(int id)
        {
            var reservation = await _context.ReservationHolders.FindAsync(id);
            if (reservation == null)
            {
                throw new ArgumentException("There is no reservation");
            }
            return reservation;
        }

        public async Task<ReservationHolder> Edit(ReservationHolder reservation)
        {
            if (reservation == null)
            {
                throw new ArgumentException("There is no reservation");
            }
            _context.ReservationHolders.Update(reservation);
            await _context.SaveChangesAsync();

            return reservation;
        }

    }
}
