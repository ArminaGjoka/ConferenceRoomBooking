using Final_Project_Conference_Room_Booking.Models;

namespace Final_Project_Conference_Room_Booking.Repositories.Interfaces
{
    public interface IUnavailabilityPeriodRepository
    {
        Task<List<UnavailabilityPeriod>> GetAllUnavailabilityPeriod(DateTime dt);
        Task<List<UnavailabilityPeriod>> GetAllUnavailabilityPeriod();
        Task<UnavailabilityPeriod> Create(UnavailabilityPeriod unavailability);
        Task<UnavailabilityPeriod> DeleteUnavailabilityPeriod(int id);
        Task<UnavailabilityPeriod> FindUnavailabilityPeriod(int id);
        Task<UnavailabilityPeriod> Edit(int id);
        Task<UnavailabilityPeriod> Edit(UnavailabilityPeriod unavailability);
    }
}
