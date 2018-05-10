using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MvcSampleApp.Services.Interfaces;

namespace MvcSampleApp.Web.Controllers
{
    public abstract class BaseController<TObject, TKey> : Controller where TObject : class
    {
        #region Fields
        protected readonly IBaseService<TObject, TKey> _service;
        #endregion

        #region Constructors
        protected BaseController(IBaseService<TObject, TKey> service)
        {
            _service = service;
        }
        #endregion

        #region Methods
        public virtual async Task<ActionResult> Index()
        {
            var model = await _service.GetAllAsync();
            return View(model.ToList());
        }

        [HttpGet]
        public virtual async Task<ActionResult> Edit(TKey id)
        {
            var company = await _service.GetByIdAsync(id);
            if (company != null)
                return View(company);
            else return HttpNotFound();
        }

        [HttpPost]
        public virtual async Task<ActionResult> Edit(TObject objectDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateAsync(objectDto);
                }
            }
            catch (Exception e)
            {
                ViewData["result"] = "Error Saving!";
                return View(); ;
            }

            ViewData["result"] = "Company details updated successfully!";
            return View();
        }

        public virtual async Task<ActionResult> Delete(TKey id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.DeleteByIdAsync(id);
                }
            }
            catch (Exception e)
            {
                ViewData["msg"] = "An error has occured.";
                return View("Index", await _service.GetAllAsync());
            }
            ViewData["msg"] = "Record deleted sucessfully.";
            return View("Index", await _service.GetAllAsync());
        }
        [HttpGet]
        public virtual ActionResult Create()
        {
            return View();
        }

        #endregion

    }
}