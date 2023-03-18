using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Services.Implementation;
using Final_Project_Conference_Room_Booking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;

namespace Final_Project_Conference_Room_Booking.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IConferenceRoomService _conferenceRoomService;
        public BookingController(IBookingService bookingService, IConferenceRoomService conferenceRoomService)
        {
            _bookingService = bookingService;
            _conferenceRoomService = conferenceRoomService;
        }
        public async Task<ActionResult> Index(DateTime? dt)
        {
            List<Booking> bookingList;

            if (dt == null)
            {
                bookingList = await _bookingService.GetAllTheBookings();
            }
            else

            {
                bookingList = await _bookingService.GetAllTheBookings((DateTime)dt);
            }
            return View(bookingList);
        }
       

        public async Task<ActionResult> Create()
        {
        
            var conferenceRoomList = await _conferenceRoomService.GetAllConferenceRooms();
            ViewBag.ConferenceRoomList = conferenceRoomList;
            return View();
        }


        public async Task<ActionResult> Edit(int Id)
        {

            var booking = await _bookingService.FindBooking(Id);
            if (booking == null)
            {
                return NotFound();
            }

            var bookings = await _conferenceRoomService.GetAllConferenceRooms();
            ViewBag.RoomId = new SelectList(bookings, "Id", "Code", booking.RoomId);

            return View(booking);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Booking booking, ConferenceRoom conference)
        {
            //if (ModelState.IsValid)
            //{

                await _bookingService.Create(booking,conference);
                return RedirectToAction("Index");
            //}
            //else
            //{
            //    //var conferenceRoomList = await _conferenceRoomService.GetAllConferenceRooms();
            //    //ViewBag.ConferenceRoomList = conferenceRoomList;
            //    return View(booking);
            //}
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Booking booking)
        {
            //if (ModelState.IsValid)
            //{
                await _bookingService.Edit(booking);
                return RedirectToAction("Index");
            //}
            //else
            //{
            //    var bookings = await _conferenceRoomService.GetAllConferenceRooms();
            //    ViewBag.RoomId = new SelectList(bookings, "Id", "Code", booking.RoomId);
            //    return View(booking);
            //}
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var booking = await _bookingService.FindBooking(id);
            if (booking == null)
            {
                return BadRequest("The booking don't exist");
            }
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteBooking(int id)
        {
            var deleteBooking = await _bookingService.DeleteBooking(id);
            if (deleteBooking == null)
            {
                return BadRequest("This bookind don't exist");
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Confirm(int id)
        {
            var booking = await _bookingService.FindBooking(id);
            if (booking == null)
            {
                return BadRequest("this booking don't exist");
            }
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmBooking(int id)
        {
            var confirmBooking = await _bookingService.Confirm(id);
            if (confirmBooking == null)
            {
                return BadRequest("This Booking don't exist");
            }
            return RedirectToAction("Index");
        }
    }
}
