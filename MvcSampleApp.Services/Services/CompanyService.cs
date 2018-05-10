using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Threading.Tasks;
using MvcSampleApp.DTO;
using MvcSampleApp.Infrastructure.Repository;
using MvcSampleApp.Services.Interfaces;
using AutoMapper;
using MvcSampleApp.Core.Entities;

namespace MvcSampleApp.Services.Services
{
    public class CompanyService : ICompanyService
    {
        #region Fields
        private readonly UnitOfWork _unitOfWork;

        public CompanyService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        public async Task<Guid> CreateAsync(CompanyDto objectDto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var entity = Mapper.Map<CompanyDto, Company>(objectDto);
                _unitOfWork.CompanyRepository.Insert(entity);
                await _unitOfWork.SaveAsync();
                scope.Complete();
                return entity.Id;
            }
        }

        public async Task<IEnumerable<CompanyDto>> GetAllAsync()
        {
            var entities = await _unitOfWork.CompanyRepository.GetAllAsync(includeProperties: "Employees");
            var enumerable = entities as Company[] ?? entities.ToArray();
            return enumerable.Any() ? Mapper.Map<IEnumerable<Company>, IEnumerable<CompanyDto>> (enumerable) : null;
        }

        public async Task<CompanyDto> GetByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.CompanyRepository.GetByIdAsync(id);
            return entity == null ? null : Mapper.Map<Company, CompanyDto>(entity);
        }

        public async Task<Guid> UpdateAsync(CompanyDto objectDto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                objectDto.UpdatedDateTime = DateTime.Now;
                var entity = Mapper.Map<CompanyDto, Company>(objectDto);
                _unitOfWork.CompanyRepository.Update(entity);
                await _unitOfWork.SaveAsync();
                scope.Complete();
                return entity.Id;
            }
        }

        public async Task DeleteAsync(CompanyDto objectDto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var entity = Mapper.Map<CompanyDto, Company>(objectDto);
                _unitOfWork.CompanyRepository.Delete(entity);
                await _unitOfWork.SaveAsync();
                scope.Complete();        
            }
        }
        public async Task DeleteByIdAsync(Guid id)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _unitOfWork.CompanyRepository.DeleteById(id);
                await _unitOfWork.SaveAsync();
                scope.Complete();
            }
        }

        public IEnumerable<CompanyDto> GetCompanySelectList()
        {
            var entities = _unitOfWork.CompanyRepository.GetAll();
            var enumerable = entities as Company[] ?? entities.ToArray();
            return enumerable.Any() ? Mapper.Map<IEnumerable<Company>, IEnumerable<CompanyDto>>(enumerable) : null;
        }
    }
}
