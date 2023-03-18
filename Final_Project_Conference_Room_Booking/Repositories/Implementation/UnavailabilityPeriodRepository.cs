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
            if (unavailability == null)
            {
                throw new ArgumentNullException(nameof(unavailability), "The unavailability period cannot be null.");
            }

            var existingPeriod = await _context.UnavailabilityPeriods.FindAsync(unavailability.Id);
            if (existingPeriod == null)
            {
                throw new KeyNotFoundException($"The unavailability period with ID {unavailability.Id} does not exist.");
            }

            var overlappingPeriod = await _context.UnavailabilityPeriods.FirstOrDefaultAsync(up => up.ConferenceRoomId == unavailability.ConferenceRoomId
                                                                                         && up.Id != unavailability.Id
                                                                                         && up.StartDate < unavailability.EndDate
                                                                                         && up.EndDate > unavailability.StartDate);
            if (overlappingPeriod != null)
            {
                throw new InvalidOperationException("The unavailability period overlaps with an existing one.");
            }

            existingPeriod.StartDate = unavailability.StartDate;
            existingPeriod.EndDate = unavailability.EndDate;

            _context.UnavailabilityPeriods.Update(existingPeriod);
            await _context.SaveChangesAsync();

            return existingPeriod;
        }


    }
}
