using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using GymManagerApplicationServices.EquipmentTypes;
using GymManager.Core.EquipmentTypes;
using GymManager.Web.Models;

namespace GymManager.Web.Controllers
{
    [Authorize]
    public class EquipmentTypesController : Controller
    {
        private readonly IEquipmentTypeAppService _equipmentTypeAppService;
        private readonly ILogger<EquipmentTypesController> _logger;
        public EquipmentTypesController(IEquipmentTypeAppService equipmentTypesAppService, ILogger<EquipmentTypesController> logger)
        {
            _equipmentTypeAppService = equipmentTypesAppService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("User executed Equipment Types's Index at " + DateTime.Now);
            List<EquipmentType> equipmentTypes = await _equipmentTypeAppService.GetEquipmentTypesAsync();

            EquipmentTypeListViewModel viewModel = new EquipmentTypeListViewModel();

            viewModel.EquipmentTypes = equipmentTypes;

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EquipmentType equipmentType)
        {
            await _equipmentTypeAppService.AddEquipmentTypeAsync(equipmentType);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int equipmentId)
        {
            await _equipmentTypeAppService.DeleteEquipmentTypeAsync(equipmentId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int equipmentId)
        {
            EquipmentType equipmentType = await _equipmentTypeAppService.GetEquipmentTypeAsync(equipmentId);
            return View(equipmentType);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EquipmentType equipmentType)
        {
            await _equipmentTypeAppService.EditEquipmentTypeAsync(equipmentType);
            return RedirectToAction("Index");
        }
    }
}
