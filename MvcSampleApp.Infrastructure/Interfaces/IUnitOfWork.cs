using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcSampleApp.Core.Entities;
using MvcSampleApp.Infrastructure.Repository;

namespace MvcSampleApp.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        MvcSampleAppContext DbContext { get; }

        GenericRepository<Employee> EmployeeRepository { get; }
        GenericRepository<Company> CompanyRepository { get; }
    }
}
