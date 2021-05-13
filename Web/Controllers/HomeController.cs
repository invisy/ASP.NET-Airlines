using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Airlines.ApplicationCore.Entities;
using Airlines.ApplicationCore.Interfaces;
using Airlines.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Airlines.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFlightsService _flightsService;

        public HomeController(IFlightsService flightsService)
        {
            _flightsService = flightsService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FindFlights(FindingFlightViewModel vm)
        {
            IReadOnlyList<FlightInstance> flights = await _flightsService.FindFlightInstances(vm.SelectedDepartureCityId ?? 0, 
                                        vm.SelectedIncomingCityId ?? 0, 
                                                    vm.DepartureDate ?? DateTime.Now, 
                                                    vm.IncomingDate ?? DateTime.Now);
            return Redirect("./");
        }

        public IActionResult EnteringPrivateInfo()
        {
            return View();
        }

        public IActionResult FoundFlights()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}