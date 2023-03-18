using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Services.Implementation;
using Final_Project_Conference_Room_Booking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_Project_Conference_Room_Booking.Controllers
{
    public class UnavailabilityPeriodController : Controller
    {
        private readonly IUnavailabilityPeriodService _unavailabilityPeriodService;
        private readonly IConferenceRoomService _conferenceRoomService;

        public UnavailabilityPeriodController(IUnavailabilityPeriodService unavailabilityPeriodService, IConferenceRoomService conferenceRoomService)
        {
            _unavailabilityPeriodService = unavailabilityPeriodService;
            _conferenceRoomService = conferenceRoomService;
        }
        public async Task<ActionResult> Index(DateTime? dt)
        {
            List<UnavailabilityPeriod> period;

            if (dt == null)
            {
                period = await _unavailabilityPeriodService.GetAllUnavailabilityPeriod();
            }
            else
            {
                period = await _unavailabilityPeriodService.GetAllUnavailabilityPeriod((DateTime)dt);
            }
            return View(period);
        }
        public async Task<ActionResult> Create()
        {
            var conferenceRoomList = await _conferenceRoomService.GetAllConferenceRooms();
            ViewBag.ConferenceRoomList = conferenceRoomList; // ViewBag i dergon cRooms tek View

            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {

            var unavailabilityPeriod = await _unavailabilityPeriodService.FindUnavailabilityPeriod(id);
            if (unavailabilityPeriod == null)
            {
                return NotFound();
            }

            var conferenceRooms = await _conferenceRoomService.GetAllConferenceRooms();
            ViewBag.ConferenceRoomId = new SelectList(conferenceRooms, "Id", "Code", unavailabilityPeriod.ConferenceRoomId);

            return View(unavailabilityPeriod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(UnavailabilityPeriod unavailabilityPeriod)
        {
            if (ModelState.IsValid)
            {
                var result = await _unavailabilityPeriodService.Create(unavailabilityPeriod);
                return RedirectToAction("Index");
            }

            var conferenceRoomList = await _conferenceRoomService.GetAllConferenceRooms();
            ViewBag.ConferenceRoomList = conferenceRoomList; // ViewBag i dergon cRooms tek View
            return View(unavailabilityPeriod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UnavailabilityPeriod unavailabilityPeriod)
        {
            if (ModelState.IsValid)
            {
                await _unavailabilityPeriodService.Edit(unavailabilityPeriod);
                return RedirectToAction("Index");
            }
            else
            {
                var conferenceRooms = await _conferenceRoomService.GetAllConferenceRooms();
                ViewBag.ConferenceRoomId = new SelectList(conferenceRooms, "Id", "Code", unavailabilityPeriod.ConferenceRoomId);

                return View(unavailabilityPeriod);
            }

        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var booking = await _unavailabilityPeriodService.FindUnavailabilityPeriod(id);
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteUnavailabilityPeriod(int id)
        {
            await _unavailabilityPeriodService.DeleteUnavailabilityPeriod(id);
            return RedirectToAction("Index");
        }
    }
}
