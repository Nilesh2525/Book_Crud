﻿using Book_Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Book_Crud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string> cities = new List<string>() { "Pune", "Mumbai", "Nashik", "Nagpur" };
            //1. single selection, iteration
            ViewData["cities"] = new SelectList(cities); // allow single selection
            ViewData["list"] = new MultiSelectList(cities); // allow multiple selection, iteration

            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormCollection form,ICollection<string> hobbies)
        {
            ViewBag.Username = form["username"];
            ViewBag.Gender = form["gender"];
            ViewBag.City = form["cities"];
            ViewBag.Hobbies = hobbies;
            ViewBag.Comments = form["comments"];
            return View("ShowInfo");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}