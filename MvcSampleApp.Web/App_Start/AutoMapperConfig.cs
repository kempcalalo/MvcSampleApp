using AutoMapper;
using MvcSampleApp.Core.Entities;
using MvcSampleApp.DTO;

namespace MvcSampleApp.Web
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                //Create all maps here
                cfg.CreateMap<CompanyDto, Company>();
                cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<Company, CompanyDto>();
                cfg.CreateMap<EmployeeDto, Employee>()
                    .ForMember(dest => dest.Company, opt => opt.Ignore());
            });
        }
    }
}