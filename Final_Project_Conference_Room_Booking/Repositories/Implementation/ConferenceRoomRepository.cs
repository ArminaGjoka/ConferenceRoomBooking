using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Conference_Room_Booking.Repositories.Implementation;

public class ConferenceRoomRepository : IConferenceRoomRepository
{
    private readonly ConferenceRoomBookingContext _context;

    public ConferenceRoomRepository(ConferenceRoomBookingContext context)
    {
        _context = context;
    }

   public async Task<List<ConferenceRoom>> GetAllConferenceRooms()
    {
        var result = await _context.ConferenceRooms.ToListAsync();
        return result;
    }
    public async Task<ConferenceRoom> Create(ConferenceRoom conferenceRoom)
    {
        if (conferenceRoom.MaxCapacity > 50)
        {
            throw new ArgumentException("The Number of the attendees cannot exceed 50 persons");
        }
        await _context.ConferenceRooms.AddAsync(conferenceRoom);
       await _context.SaveChangesAsync();
        return (conferenceRoom);
    }
    public async Task<ConferenceRoom> DeleteConferenceRoom(int id)
    {
        var deleterecord = await _context.ConferenceRooms.FindAsync(id);
        _context.ConferenceRooms.Remove(deleterecord);
        await _context.SaveChangesAsync();
        return deleterecord;
    }
    public async Task<ConferenceRoom> FindConferenceRoom(int id)
    {
        var cRoomId = await _context.ConferenceRooms.FindAsync(id);
        return cRoomId;
    }
    public async Task<ConferenceRoom> Edit(int id)
    {
        return await _context.ConferenceRooms.FindAsync(id);
    }
    public async Task<ConferenceRoom> Edit(ConferenceRoom conferenceRoom)
    {
        _context.ConferenceRooms.Update(conferenceRoom);
        await _context.SaveChangesAsync();
        return conferenceRoom;
    }
}
