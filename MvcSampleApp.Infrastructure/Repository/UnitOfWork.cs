using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcSampleApp.Core.Entities;
using MvcSampleApp.Infrastructure.Interfaces;

namespace MvcSampleApp.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;
        private MvcSampleAppContext _context;
        private GenericRepository<Employee> _employeeRepository;
        private GenericRepository<Company> _companyRepository;
        public MvcSampleAppContext DbContext => _context ?? (_context = new MvcSampleAppContext());

        public GenericRepository<Employee> EmployeeRepository
        {
            get
            {
                if (this._employeeRepository == null)
                {
                    this._employeeRepository = new GenericRepository<Employee>(DbContext);
                }
                return _employeeRepository;
            }
        }

        public GenericRepository<Company> CompanyRepository
        {
            get
            {
                if (this._companyRepository == null)
                {
                    this._companyRepository = new GenericRepository<Company>(DbContext);
                }
                return _companyRepository;
            }
        }

        public async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        protected void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
