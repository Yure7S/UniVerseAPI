using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Interface
{
    public interface IBaseInterface<T> where T : class
    {
        public Task<T?> GetByIdAsync(Guid id);
        public Task<List<T>> GetAllAsync();
        public Task<T> CreateAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<T> DeleteAsync(T entity);
    }
}
