using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Repositories.Implementation;
using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Final_Project_Conference_Room_Booking.Services.Interfaces;

namespace Final_Project_Conference_Room_Booking.Services.Implementation;

public class UnavailabilityPeriodService : IUnavailabilityPeriodService
{
    private readonly IUnavailabilityPeriodRepository _unavailabilityPeriodRepository;

    public UnavailabilityPeriodService(IUnavailabilityPeriodRepository unavailabilityPeriodRepository)
    {
        _unavailabilityPeriodRepository = unavailabilityPeriodRepository;
    }
    public async Task<List<UnavailabilityPeriod>> GetAllUnavailabilityPeriod(DateTime data)
    {
        return await _unavailabilityPeriodRepository.GetAllUnavailabilityPeriod(data);
    }

    public async Task<List<UnavailabilityPeriod>> GetAllUnavailabilityPeriod()
    {
        return await _unavailabilityPeriodRepository.GetAllUnavailabilityPeriod();
    }

    public async Task<UnavailabilityPeriod> Create(UnavailabilityPeriod unavailability)
    {
        return await _unavailabilityPeriodRepository.Create(unavailability);
    }

    public async Task<UnavailabilityPeriod> DeleteUnavailabilityPeriod(int id)
    {
        var unavailability = await _unavailabilityPeriodRepository.FindUnavailabilityPeriod(id);

        if (unavailability == null)
        {
            throw new ArgumentException($"Unavailability period with id {id} does not exist.");
        }

        return await _unavailabilityPeriodRepository.DeleteUnavailabilityPeriod(id);
    }

    public async Task<UnavailabilityPeriod> FindUnavailabilityPeriod(int id)
    {
        return await _unavailabilityPeriodRepository.FindUnavailabilityPeriod(id);
    }

    public async Task<UnavailabilityPeriod> Edit(int id)
    {
        var unavailability = await _unavailabilityPeriodRepository.FindUnavailabilityPeriod(id);

        if (unavailability == null)
        {
            throw new ArgumentException($"Unavailability period with id {id} does not exist.");
        }

        return unavailability;
    }

    public async Task<UnavailabilityPeriod> Edit(UnavailabilityPeriod unavailability)
    {
        if (unavailability.Id <= 0)
        {
            throw new ArgumentException("ID is not valid");
        }

        var existingUnavailability = await _unavailabilityPeriodRepository.FindUnavailabilityPeriod(unavailability.Id);

        if (existingUnavailability == null)
        {
            throw new ArgumentException($"Unavailability period with id {unavailability.Id} does not exist.");
        }

        return await _unavailabilityPeriodRepository.Edit(unavailability);
    }

}

