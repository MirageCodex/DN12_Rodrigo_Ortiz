﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wkhtmltopdf.NetCore;

namespace GymManager.Web.Controllers
{
    [Authorize]
    public class InvoicingController : Controller
    {
        private readonly IGeneratePdf _generatePdf;
        public InvoicingController(IGeneratePdf generatePdf) 
        { 
            _generatePdf = generatePdf;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GenerateInvoice() 
        {
            return View();
        }
        public async Task<IActionResult> Print()
        {
            return await _generatePdf.GetPdf("/Views/Invoicing/Print.cshtml");
            //return View();
        }
    }
}
