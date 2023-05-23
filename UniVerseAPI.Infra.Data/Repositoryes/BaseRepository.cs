using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Models;

namespace UniVerseAPI.Infra.Data.Repositoryes
{
    public class BaseRepository<T> : IBaseInterface<T> where T : class
    {   
        public readonly UniDBContext _db;

        public BaseRepository(UniDBContext db)
        {
            _db = db;
        }

        public Task<T> Create(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<T> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
