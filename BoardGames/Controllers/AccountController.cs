﻿using Microsoft.AspNetCore.Mvc;

namespace BoardGames.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
