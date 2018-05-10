using System;
using MvcSampleApp.Services.Interfaces;
using System.Web.Mvc;
using MvcSampleApp.DTO;
using MvcSampleApp.Services.Services;
using Unity;
using Unity.Mvc5;
using MvcSampleApp.Web.Controllers;
using Unity.Injection;

namespace MvcSampleApp.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            #region Registered Types
            container.RegisterType<IBaseService<CompanyDto, Guid>, CompanyService>();
            container.RegisterType<IBaseService<EmployeeDto, Guid>, EmployeeService>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            #endregion
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }


    }
}