using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Entities;
using Airlines.ApplicationCore.Interfaces;
using Airlines.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Airlines.Web.Controllers
{
    public class AirportController : Controller
    {
        private readonly IAirportService _airportService;
        private readonly ICitiesService _citiesService;
        private IMapper<FoundFlightsDTO, FoundFlightsViewModel> _foundFlightsMapper;
        private IMapper<SearchFlightsDTO, SearchFlightsViewModel> _searchFlightsMapper;

        public AirportController(IAirportService airportService, ICitiesService citiesService,
            IMapper<SearchFlightsDTO, SearchFlightsViewModel> searchFlightsMapper,
            IMapper<FoundFlightsDTO, FoundFlightsViewModel> foundFlightsMapper)
        {
            _airportService = airportService;
            _citiesService = citiesService;
            _foundFlightsMapper = foundFlightsMapper;
            _searchFlightsMapper = searchFlightsMapper;
        }

        public async Task<IActionResult> Index(SearchFlightsViewModel vm)
        {
            var cities = await _citiesService.GetAll();
            vm.DepartureCities = new SelectList(cities, "Id", "Name");
            vm.IncomingCities = vm.DepartureCities;
            return View(vm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FindFlights(SearchFlightsViewModel vm)
        {
            var flights = await _airportService.FindFlightInstances(_searchFlightsMapper.Map(vm));
            return View("FoundFlights",_foundFlightsMapper.Map(flights));
        }

        public IActionResult FoundFlights(IEnumerable<FoundFlightsViewModel> vms)
        {
            return View(vms);
        }
        
        public async Task<IActionResult> Buy(int id)
        {
            var travelClasses = await _airportService.GetFlightAvailableTravelClasses(id);
            var planeSeats = await _airportService.GetFlightFreePlaneSeats(id, travelClasses.FirstOrDefault().Id);
            SelectingPlaceViewModel selectingPlaceVm = new SelectingPlaceViewModel();
            selectingPlaceVm.TravelClasses = new SelectList(travelClasses, "Id", "Name");
            selectingPlaceVm.PlanePlaces = new SelectList(planeSeats, "Id", "Number");
            EnteringTicketDataViewModel ticketDataVm = new EnteringTicketDataViewModel() {SelectingPlace = selectingPlaceVm};
            TempData["SelectedPlanePlaceId"] = Convert.ToInt32(selectingPlaceVm.PlanePlaces.Select(x => x.Value).FirstOrDefault());
            return View(ticketDataVm);
        }
        
        [HttpPost]
        public async Task<IActionResult> Buy(int id, EnteringTicketDataViewModel ticketDataVm)
        {
            SelectingPlaceViewModel selectingPlaceVm = ticketDataVm.SelectingPlace;
            var travelClasses = await _airportService.GetFlightAvailableTravelClasses(id);
            var planeSeats = await _airportService.GetFlightFreePlaneSeats(id, selectingPlaceVm.SelectedTravelClassId);
            selectingPlaceVm.TravelClasses = new SelectList(travelClasses, "Id", "Name", selectingPlaceVm.SelectedTravelClassId);
            selectingPlaceVm.PlanePlaces = new SelectList(planeSeats, "Id", "Number", selectingPlaceVm.SelectedPlanePlaceId);
            TempData["SelectedPlanePlaceId"] = selectingPlaceVm.SelectedPlanePlaceId;
            return View(ticketDataVm);
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