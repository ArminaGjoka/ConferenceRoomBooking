using Final_Project_Conference_Room_Booking.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Conference_Room_Booking.Services.Interfaces
{
    public interface IUnavailabilityPeriodService
    {
        Task<List<UnavailabilityPeriod>> GetAllUnavailabilityPeriod(DateTime data);
        Task<List<UnavailabilityPeriod>> GetAllUnavailabilityPeriod();
        Task<UnavailabilityPeriod> Create(UnavailabilityPeriod unavailability);
        Task<UnavailabilityPeriod> DeleteUnavailabilityPeriod(int id);
        Task<UnavailabilityPeriod> FindUnavailabilityPeriod(int id);
        Task<UnavailabilityPeriod> Edit(int id);
        Task<UnavailabilityPeriod> Edit(UnavailabilityPeriod unavailability);
    }
}
