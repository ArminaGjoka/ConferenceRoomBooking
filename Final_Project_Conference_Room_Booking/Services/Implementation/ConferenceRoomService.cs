using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Repositories.Implementation;
using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Final_Project_Conference_Room_Booking.Services.Interfaces;

namespace Final_Project_Conference_Room_Booking.Services.Implementation;

public class ConferenceRoomService:IConferenceRoomService
{
    private readonly IConferenceRoomRepository _conferenceRoomRepository;

    public ConferenceRoomService(IConferenceRoomRepository conferenceRoomRepository)
    {
         _conferenceRoomRepository = conferenceRoomRepository;
    }
    public async Task<List<ConferenceRoom>> GetAllConferenceRooms()
    {
        return await _conferenceRoomRepository.GetAllConferenceRooms();
    }
    public async Task<ConferenceRoom> Create(ConferenceRoom conferenceRoom)
    {
        return await _conferenceRoomRepository.Create(conferenceRoom);
    }
    public async Task<ConferenceRoom> DeleteConferenceRoom(int id)
    {
        return await _conferenceRoomRepository.DeleteConferenceRoom(id);
    }
    public async Task<ConferenceRoom> FindConferenceRoom(int id)
    {
        return await _conferenceRoomRepository.FindConferenceRoom(id);
    }
    public async Task<ConferenceRoom> Edit(int id)
    {
        return await _conferenceRoomRepository.FindConferenceRoom(id);
    }
    public async Task<ConferenceRoom> Edit(ConferenceRoom conferenceRoom)
    {
        return await _conferenceRoomRepository.Edit(conferenceRoom);
    }
}
