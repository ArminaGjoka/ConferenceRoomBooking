using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Final_Project_Conference_Room_Booking.Services.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Conference_Room_Booking.Repositories.Implementation
{
    public class UnavailabilityPeriodRepository : IUnavailabilityPeriodRepository
    {
        private readonly ConferenceRoomBookingContext _context;

        public UnavailabilityPeriodRepository(ConferenceRoomBookingContext context)
        {
            _context = context;
        }
        public async Task<List<UnavailabilityPeriod>> GetAllUnavailabilityPeriod(DateTime dt)
        {
            var result = await _context.UnavailabilityPeriods.Where(s => s.StartDate == dt).
            ToListAsync();
            return result;

        }
        public async Task<List<UnavailabilityPeriod>> GetAllUnavailabilityPeriod()
        {
            var result = await _context.UnavailabilityPeriods.ToListAsync();
            return result;
        }
        public async Task<UnavailabilityPeriod> Create(UnavailabilityPeriod unavailability)
        {
         
            await _context.UnavailabilityPeriods.AddAsync(unavailability);
            await _context.SaveChangesAsync();
            return unavailability;
        }
      
        public async Task<UnavailabilityPeriod> DeleteUnavailabilityPeriod(int id)
        {
            var deleterecord = await _context.UnavailabilityPeriods.FindAsync(id);

            if (deleterecord == null)
            {
                throw new KeyNotFoundException($"The unavailability period with ID {id} does not exist.");
            }

            _context.UnavailabilityPeriods.Remove(deleterecord);
            await _context.SaveChangesAsync();

            return deleterecord;
        }

        public async Task<UnavailabilityPeriod> FindUnavailabilityPeriod(int id)
        {
            var uPeriodId = await _context.UnavailabilityPeriods.FindAsync(id);
            return uPeriodId;
        }
        public async Task<UnavailabilityPeriod> Edit(int id)
        {
            return await _context.UnavailabilityPeriods.FindAsync(id);
        }
       
        public async Task<UnavailabilityPeriod> Edit(UnavailabilityPeriod unavailability)
        {
            if (unavailability.StartDate > unavailability.EndDate)
            {
                throw new ArgumentException("Booking start time must be before end time.");
            }

            _context.UnavailabilityPeriods.Update(unavailability);
            await _context.SaveChangesAsync();
            return unavailability;
           
        }

    }
}
