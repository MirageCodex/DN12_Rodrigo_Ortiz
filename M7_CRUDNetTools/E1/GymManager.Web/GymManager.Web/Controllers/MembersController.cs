using GymManager.Core.Members;
using GymManagerApplicationServices.Members;
using GymManager.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace GymManager.Web.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {
        private readonly IMembersAppService _membersAppService;
        private readonly ILogger<MembersController> _logger;
        public MembersController(IMembersAppService membersAppService, ILogger<MembersController> logger)
        {
            _membersAppService = membersAppService;
            _logger = logger;
        }

        public async Task <IActionResult> Index()
        {
            _logger.LogInformation("User executed Member´s Index at "+ DateTime.Now); 

            List<Member> members = await _membersAppService.GetMembersAsync();

            MemberListViewModel viewModel = new MemberListViewModel();

            viewModel.NewMembersCount = 2;
            viewModel.Members = members;

            
            return View(viewModel);
        }
        
        public IActionResult Test()
        {
            return View();
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Member member)
        {
           
            await _membersAppService.AddMemberAsync(member);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int memberId)
        {
            
            await _membersAppService.DeleteMemberAsync(memberId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int memberId)
        {
            
            Member member =  await _membersAppService.GetMemberAsync(memberId);

            return View(member);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Member member)
        {
           
             await _membersAppService.EditMemberAsync(member);
            return RedirectToAction("Index");
        }
    }
}
