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
    public class TravelClassesController : Controller
    {
        private readonly ITravelClassesService _travelClassesService;
        private readonly IMapper<TravelClassDTO, TravelClassViewModel> _mapper;
        
        public TravelClassesController(ITravelClassesService travelClassesService, IMapper<TravelClassDTO, TravelClassViewModel> mapper)
        {
            _travelClassesService = travelClassesService;
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
            var travelClasses = await _travelClassesService.GetAll();
            
            return View(_mapper.Map(travelClasses));
        }
        
        // GET
        public IActionResult Create()
        {
            return View();
        }
        
        // POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async  Task<IActionResult> Create(TravelClassViewModel model)
        {
            if (ModelState.IsValid) {
                await _travelClassesService.Create(_mapper.Map(model));
                return RedirectToAction("All");
            }
            
            ModelState.AddModelError(string.Empty, GeneralExceptions.InvalidInput);
            return View();
        }
        
        // GET
        public async Task<IActionResult> Edit(int id)
        {
            try {
                TravelClassDTO dto = await _travelClassesService.GetById(id);

                return View(_mapper.Map(dto));
            }
            catch (EntityNotFoundException)
            {
                ModelState.AddModelError(string.Empty, TravelClassesExceptions.TravelClassNotFound);
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
        public async Task<IActionResult> Edit(TravelClassViewModel model)
        {
            try {
                if (ModelState.IsValid) {
                    await _travelClassesService.Update(_mapper.Map(model));
                    return RedirectToAction("All");
                }
                
                ModelState.AddModelError(string.Empty, GeneralExceptions.InvalidInput);
                return View();
            }
            catch (EntityNotFoundException) {
                ModelState.AddModelError(string.Empty, TravelClassesExceptions.TravelClassNotFound);
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
            try {
                TravelClassDTO dto = await _travelClassesService.GetById(id);
                return View(_mapper.Map(dto));
            }
            catch (EntityNotFoundException) {
                ModelState.AddModelError(string.Empty, TravelClassesExceptions.TravelClassNotFound);
                return View();
            }
            catch (Exception) {
                ModelState.AddModelError(string.Empty, GeneralExceptions.UnknownError);
                return View();
            }
        }
        
        // POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async  Task<IActionResult> Delete(TravelClassViewModel model)
        {
            try {
                await _travelClassesService.Delete(model.Id);
                return RedirectToAction("All");
            }
            catch (EntityNotFoundException) {
                ModelState.AddModelError(string.Empty, TravelClassesExceptions.TravelClassNotFound);
                return View();
            }
            catch (Exception) {
                ModelState.AddModelError(string.Empty, GeneralExceptions.UnknownError);
                return View();
            }
        }
    }
}