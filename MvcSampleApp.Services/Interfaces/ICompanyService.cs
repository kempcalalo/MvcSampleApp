using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcSampleApp.DTO;

namespace MvcSampleApp.Services.Interfaces
{
    public interface ICompanyService : IBaseService<CompanyDto, Guid>
    {
        IEnumerable<CompanyDto> GetCompanySelectList();
    }

}
