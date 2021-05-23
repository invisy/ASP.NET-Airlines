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
    public class PlanesController : Controller
    {
        private readonly IMapper<PlaneOverviewDTO, PlaneOverviewViewModel> _planeOverviewMapper;
        private readonly IMapper<PlaneFlatDTO, PlaneFlatViewModel> _planeFlatMapper;
        private readonly IPlanesService _planesService;
        
        public PlanesController(IPlanesService planesService, IMapper<PlaneOverviewDTO, PlaneOverviewViewModel> planeOverviewMapper,
            IMapper<PlaneFlatDTO, PlaneFlatViewModel> planeFlatMapper)
        {
            _planesService = planesService;
            _planeOverviewMapper = planeOverviewMapper;
            _planeFlatMapper = planeFlatMapper;
        }
        
        // GET
        public IActionResult Index()
        {
            return RedirectToAction("All");
        }
        
        // GET
        public async Task<IActionResult> All()
        {
            var planesOverview = await _planesService.GetAll();
            
            return View(_planeOverviewMapper.Map(planesOverview));
        }
        
        // GET
        public IActionResult Create()
        {
            return View();
        }
        
        // POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(PlaneFlatViewModel viewModel)
        {
            if (ModelState.IsValid) {
                await _planesService.Create(_planeFlatMapper.Map(viewModel));
                return RedirectToAction("All");
            }
            
            ModelState.AddModelError(string.Empty, GeneralExceptions.InvalidInput);
            return View();
        }
        
        // GET
        public async Task<IActionResult> Edit(int id)
        {
            try {
                PlaneFlatDTO dto = await _planesService.GetFlatById(id);
                return View(_planeFlatMapper.Map(dto));
            }
            catch (EntityNotFoundException e)
            {
                ModelState.AddModelError(string.Empty, PlanesExceptions.PlaneNotFound);
                return View();
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, GeneralExceptions.UnknownError);
                return View();
            }
        }
        
        // POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(PlaneFlatViewModel viewModel)
        {
            try {
                if (ModelState.IsValid) {
                    await _planesService.Update(_planeFlatMapper.Map(viewModel));
                    return RedirectToAction("All");
                }
                
                ModelState.AddModelError(string.Empty, GeneralExceptions.InvalidInput);
                return View();
            }
            catch (EntityNotFoundException) {
                ModelState.AddModelError(string.Empty, PlanesExceptions.PlaneNotFound);
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
                PlaneOverviewDTO dto = await _planesService.GetOverviewById(id);
                return View(_planeOverviewMapper.Map(dto));
            }
            catch (EntityNotFoundException)
            {
                ModelState.AddModelError(string.Empty, PlanesExceptions.PlaneNotFound);
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
        public async  Task<IActionResult> Delete(PlaneOverviewViewModel viewModel)
        {
            try {
                await _planesService.Delete(viewModel.Id);
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