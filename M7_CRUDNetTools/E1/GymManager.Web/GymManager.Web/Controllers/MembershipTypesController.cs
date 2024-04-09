using GymManager.Core.MembershipType;
using GymManagerApplicationServices.MembershipTypes;
using GymManager.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using GymManager.MembershipTypes.Dto;

namespace GymManager.Web.Controllers
{
    [Authorize]
    public class MembershipTypesController : Controller
    {
        private readonly IMembershipTypesAppService _membershipTypesAppService;
        private readonly ILogger<MembershipTypesController> _logger;

        public MembershipTypesController(IMembershipTypesAppService membershipTypesAppService, ILogger<MembershipTypesController> logger, IWebHostEnvironment env)
        {
            _membershipTypesAppService = membershipTypesAppService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
                _logger.LogInformation("User executed Membership Types´s Index at " + DateTime.Now);
                List<MembershipTypeDto> membershipTypeDtos = await _membershipTypesAppService.GetMembershipTypesAsync();

                MembershipTypeListViewModel viewModel = new MembershipTypeListViewModel();
                viewModel.MembershipTypes = membershipTypeDtos;

                _logger.LogInformation("Total membership types retrieved: " + membershipTypeDtos.Count);

                return View(viewModel);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MembershipType membershipType)
        {
            await _membershipTypesAppService.AddMembershipTypesAsync(membershipType);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int membershipId)
        {
            await _membershipTypesAppService.DeleteMembershipTypeAsync(membershipId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int membershipId)
        {
            MembershipTypeDto membershipType = await _membershipTypesAppService.GetMembershipTypeAsync(membershipId);
            return View(membershipType);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MembershipType membershipType)
        {
            await _membershipTypesAppService.EditMembershipTypeAsync(membershipType);
            return RedirectToAction("Index");
        }
    }
}

