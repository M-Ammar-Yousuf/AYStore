﻿using Microsoft.AspNetCore.Mvc;

namespace AYStore.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
