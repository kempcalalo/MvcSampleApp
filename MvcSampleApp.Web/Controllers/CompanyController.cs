using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MvcSampleApp.DTO;
using MvcSampleApp.Services.Interfaces;

namespace MvcSampleApp.Web.Controllers
{
    public class CompanyController : BaseController<CompanyDto, Guid>
    {

        public CompanyController(IBaseService<CompanyDto, Guid> companyService) : base(companyService)
        {
        }
        
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Exclude = "Id")] CompanyDto company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    company.Id = Guid.NewGuid();
                    company.CreatedDateTime = DateTime.Now;
                    Guid.TryParse(User.Identity.GetUserId(), out var userId);
                    company.CreatedBy = userId;
                    await _service.CreateAsync(company);
                }
            }
            catch (Exception e)
            {
                ViewData["result"] = "Error Saving!";
                return View();
            }

            ViewData["result"] = "Company details added successfully!";
            return View();
        }
    }
}