﻿using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Conference_Room_Booking.Controllers
{
    public class ReservationHolderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}