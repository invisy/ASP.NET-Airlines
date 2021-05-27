using System;
using System.Threading.Tasks;
using Airlines.ApplicationCore.Constants;
using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Exceptions;
using Airlines.ApplicationCore.Interfaces;
using Airlines.Web.Models.AdminPanel;
using Airlines.Web.StringConstants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Web.Controllers.AdminPanel
{
    [Authorize(Roles=Roles.ADMINISTRATORS)]
    public class CitiesController : Controller
    {
        private readonly ICitiesService _citiesService;
        private readonly IMapper<CityDTO, CityViewModel> _mapper;
        
        public CitiesController(ICitiesService citiesService, IMapper<CityDTO, CityViewModel> mapper)
        {
            _citiesService = citiesService;
            _mapper = mapper;
        }
        
        // GET
        public IActionResult Index()
        {
            return RedirectToAction("All");
        }
        
        // GET
        public async Task<IActionResult> All()
        {
            var cities = await _citiesService.GetAll();
            
            return View(_mapper.Map(cities));
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
            if (ModelState.IsValid) {
                await _citiesService.Create(_mapper.Map(model));
                return RedirectToAction("All");
            }
            
            ModelState.AddModelError(string.Empty, GeneralExceptions.InvalidInput);
            return View();
        }
        
        // GET
        public async Task<IActionResult> Edit(int id)
        {
            try {
                CityDTO dto = await _citiesService.GetById(id);
                return View(_mapper.Map(dto));
            }
            catch (EntityNotFoundException)
            {
                ModelState.AddModelError(string.Empty, CitiesExceptions.CityNotFound);
                return View();
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, GeneralExceptions.UnknownError);
                return View();
            }
        }
        
        // POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(CityViewModel model)
        {
            try {
                if (ModelState.IsValid) {
                    await _citiesService.Update(_mapper.Map(model));
                    return RedirectToAction("All");
                }
                
                ModelState.AddModelError(string.Empty, GeneralExceptions.InvalidInput);
                return View();
            }
            catch (EntityNotFoundException) {
                ModelState.AddModelError(string.Empty, CitiesExceptions.CityNotFound);
                return View();
            }
            catch (Exception) {
                ModelState.AddModelError(string.Empty, GeneralExceptions.UnknownError);
                return View();
            }
        }
        
        // GET
        public async  Task<IActionResult> Delete(int id)
        {
            try
            {
                CityDTO dto = await _citiesService.GetById(id);
                return View(_mapper.Map(dto));
            }
            catch (EntityNotFoundException)
            {
                ModelState.AddModelError(string.Empty, CitiesExceptions.CityNotFound);
                return View();
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, GeneralExceptions.UnknownError);
                return View();
            }
        }
        
        // POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async  Task<IActionResult> Delete(CityViewModel model)
        {
            try {
                await _citiesService.Delete(model.Id);
                return RedirectToAction("All");
            }
            catch (EntityNotFoundException) {
                ModelState.AddModelError(string.Empty, CitiesExceptions.CityNotFound);
                return View();
            }
            catch (Exception) {
                ModelState.AddModelError(string.Empty, GeneralExceptions.UnknownError);
                return View();
            }
        }
    }
}