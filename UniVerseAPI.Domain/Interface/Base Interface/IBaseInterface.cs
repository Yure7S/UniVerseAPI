using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Interface
{
    public interface IBaseInterface<T> where T : class
    {
        public Task<T?> GetById(Guid id);
        public Task<List<T>> GetAll();
        public Task<T> Create(T entity);
        public Task<T> Update(T entity);
        public Task<T> Delete(T entity);
    }
}
