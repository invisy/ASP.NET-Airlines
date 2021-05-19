﻿using System.Threading.Tasks;
using Airlines.ApplicationCore.Interfaces;
using Airlines.Web.Models.AdminPanel;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Web.Controllers.AdminPanel
{
    public class CitiesController : Controller
    {
        private ICitiesService _citiesService;
        
        public CitiesController(ICitiesService citiesService)
        {
            _citiesService = citiesService;
        }
        
        // GET
        public async Task<IActionResult> All()
        {
            var cities = await _citiesService.GetAll();
            return View(cities);
        }
        
        // GET
        public IActionResult Create()
        {
            return View();
        }
        
        // POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async  Task<IActionResult> Create(CityViewModel model)
        {
            await _citiesService.Create(model.Name);
            return RedirectToAction("All");
        }
    }
}