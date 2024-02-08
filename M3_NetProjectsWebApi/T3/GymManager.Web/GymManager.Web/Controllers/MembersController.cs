using GymManager.Core.Members;
using GymManagerApplicationServices.Members;
using GymManager.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GymManager.Web.Controllers
{
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
    }
}
