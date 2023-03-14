using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Repositories.Implementation;
using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Final_Project_Conference_Room_Booking.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Final_Project_Conference_Room_Booking.Services.Implementation
{
    public class ReservationHolderService : IReservationHolderService
    {
        
        private readonly IReservationHolderRepository _reservationHolderRepository;
       
        public ReservationHolderService(IReservationHolderRepository reservationHolderRepository)
        {
            _reservationHolderRepository = reservationHolderRepository;
            
        }

        public async Task<List<ReservationHolder>> GetAllReservationHolders()
        {
            return await _reservationHolderRepository.GetAllReservationHolders();
        }
        
        public async Task<ReservationHolder> Create(ReservationHolder reservationHolder)
        {
            
            if (reservationHolder == null)
            {
                throw new ArgumentNullException(nameof(reservationHolder), "The reservation holder cannot be null.");
            }

            
            if (string.IsNullOrEmpty(reservationHolder.Name))
            {
                throw new ArgumentException("The Name field is required.", nameof(reservationHolder.Name));
            }
            if (string.IsNullOrEmpty(reservationHolder.Surname))
            {
                throw new ArgumentException("The Surname field is required.", nameof(reservationHolder.Surname));
            }


            if (string.IsNullOrEmpty(reservationHolder.Email))
            {
                throw new ArgumentException("The Email field is required.", nameof(reservationHolder.Email));
            }
       
          
            if (string.IsNullOrEmpty(reservationHolder.PhoneNumber))
            {
                throw new ArgumentException("The phone number field is required.", nameof(reservationHolder.PhoneNumber));
            }

            return await _reservationHolderRepository.Create(reservationHolder);
        }
        public async Task<ReservationHolder> DeleteReservationHolder(int id)
        {
            var reservationHolder = await _reservationHolderRepository.FindReservationHolder(id);
            if (reservationHolder == null)
            {
                throw new ArgumentException("The reservation holder could not be found.", nameof(id));
            }

           
            return await _reservationHolderRepository.DeleteReservationHolder(id);
        }
        public async Task<ReservationHolder> FindReservationHolder(int id)
        {
            var reservationHolder = await _reservationHolderRepository.FindReservationHolder(id);
            if (reservationHolder == null)
            {
                throw new ArgumentException("The reservation holder could not be found.", nameof(id));
            }

            return reservationHolder; ;
                }
        public async Task<ReservationHolder> Edit(int id)
        {
            var reservationHolder = await _reservationHolderRepository.FindReservationHolder(id);
            if (reservationHolder == null)
            {
                throw new ArgumentException("The reservation holder could not be found.", nameof(id));
            }

            return reservationHolder;
        }
        public async Task<ReservationHolder> Edit(ReservationHolder reservation)
        {
            if (reservation == null)
            {
                throw new ArgumentException("There is no reservation");
            }
                return await _reservationHolderRepository.Edit(reservation);
        }
    }
}