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

        public MembersController(IMembersAppService membersAppService)
        {
            _membersAppService = membersAppService;
        }

        public IActionResult Index()
        {
            
            List<Member> members = _membersAppService.GetMembers();

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
        public IActionResult Create(Member member)
        {
            _membersAppService.AddMember(member);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int memberId)
        {
            _membersAppService.DeleteMember(memberId);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int memberId)
        {

            Member member = _membersAppService.GetMember(memberId);

            return View(member);
        }

        [HttpPost]
        public IActionResult Edit(Member member)
        {
        
            _membersAppService.EditMember(member);
            return RedirectToAction("Index");
        }
    }
}
