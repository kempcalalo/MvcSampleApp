using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcSampleApp.DTO;

namespace MvcSampleApp.Services.Interfaces
{
    public interface IEmployeeService : IBaseService<EmployeeDto, Guid>
    {
    }
}
