using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using MvcSampleApp.Core.Entities;
using MvcSampleApp.DTO;
using MvcSampleApp.Infrastructure.Repository;
using MvcSampleApp.Services.Interfaces;

namespace MvcSampleApp.Services.Services
{
    public class EmployeeService : IBaseService<EmployeeDto, Guid>
    {
        #region Fields
        private readonly UnitOfWork _unitOfWork;

        public EmployeeService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<Guid> CreateAsync(EmployeeDto objectDto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var entity = Mapper.Map<EmployeeDto, Employee>(objectDto);
                entity.CompanyId = objectDto.Company.Id;
                _unitOfWork.EmployeeRepository.Insert(entity);
                await _unitOfWork.SaveAsync();
                scope.Complete();
                return entity.Id;
            }
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var entities = await _unitOfWork.EmployeeRepository.GetAllAsync();
            var enumerable = entities as Employee[] ?? entities.ToArray();
            return enumerable.Any() ? Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(enumerable) : null;
        }

        public async Task<EmployeeDto> GetByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            return entity == null ? null : Mapper.Map<Employee, EmployeeDto>(entity);
        }

        public async Task<Guid> UpdateAsync(EmployeeDto objectDto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {              
                objectDto.CompanyId = objectDto.Company.Id;
                objectDto.Company = null;
                var entity = Mapper.Map<EmployeeDto, Employee>(objectDto);
                _unitOfWork.EmployeeRepository.Update(entity);
                await _unitOfWork.SaveAsync();
                scope.Complete();
                return entity.Id;
            }
        }

        public async Task DeleteAsync(EmployeeDto objectDto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var entity = Mapper.Map<EmployeeDto, Employee>(objectDto);
                _unitOfWork.EmployeeRepository.Delete(entity);
                await _unitOfWork.SaveAsync();
                scope.Complete();
            }
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _unitOfWork.EmployeeRepository.DeleteById(id);
                await _unitOfWork.SaveAsync();
                scope.Complete();
            }
        }
    }
}
