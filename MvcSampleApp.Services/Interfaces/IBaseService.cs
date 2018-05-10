using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSampleApp.Services.Interfaces
{
    public interface IBaseService<TObject, TKey>
    {
        Task<TKey> CreateAsync(TObject objectDto);
        Task<IEnumerable<TObject>> GetAllAsync();
        Task<TObject> GetByIdAsync(TKey id);
        Task<TKey> UpdateAsync(TObject objectDto);
        Task DeleteAsync(TObject objectDto);
        Task DeleteByIdAsync(TKey id);
    }
}
