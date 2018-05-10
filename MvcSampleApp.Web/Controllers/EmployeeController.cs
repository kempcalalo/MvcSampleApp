using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MvcSampleApp.DTO;
using MvcSampleApp.Services.Interfaces;

namespace MvcSampleApp.Web.Controllers
{
    public class EmployeeController : BaseController<EmployeeDto, Guid>
    {
        private static IEnumerable<CompanyDto> _companies;
        private readonly ICompanyService _companyService;

        public EmployeeController(IBaseService<EmployeeDto, Guid> employeeService,
                                     IBaseService<CompanyDto, Guid> companyService) : base(employeeService)
        {
            _companyService = (ICompanyService)companyService;
        }
 
        public override async Task<ActionResult> Edit(Guid id)
        {
            ViewBag.Companies = GetCompanySelectList();
            return await base.Edit(id);
        }

        public override async Task<ActionResult> Edit(EmployeeDto objectDto)
        {
            ViewBag.Companies = GetCompanySelectList();
            return await base.Edit(objectDto);
        }

        public override ActionResult Create()
        {
            ViewBag.Companies = GetCompanySelectList();
            return base.Create();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind(Exclude = "Id")] EmployeeDto employee)
        {
            try
            {
                ViewBag.Companies = GetCompanySelectList();
                if (ModelState.IsValid)
                {
                    employee.Id = Guid.NewGuid();
                    employee.CreatedDateTime = DateTime.Now;
                    Guid.TryParse(User.Identity.GetUserId(), out var userId);
                    employee.CreatedBy = userId;
                    await _service.CreateAsync(employee);
                }
            }
            catch (Exception e)
            {
                ViewData["result"] = "Error Saving!";
                return View();
            }
            
            ViewData["result"] = "Employee details added successfully!";
            return View();
        }

        private SelectList GetCompanySelectList()
        {
            if (_companies != null)
                return new SelectList(_companies, "Id", "CompanyName");
            else
            {
                GetCompanyList();
                return new SelectList(_companies, "Id", "CompanyName");
            }
        }

        private void GetCompanyList()
        {
            var companies = _companyService.GetCompanySelectList();
            _companies = companies;

        }
    }
}