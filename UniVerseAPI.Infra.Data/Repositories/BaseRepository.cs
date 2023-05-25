using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Operators;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Infra.Data.Repositoryes
{
    public class BaseRepository<T> : IBaseInterface<T> where T : class
    {   
        public readonly UniDBContext _db;

        public BaseRepository(UniDBContext db)
        {
            _db = db;
        }

        public Task<List<T>> GetAll()
        {
            return _db.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<T> Create(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            _db.SaveChanges();
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _db.Set<T>().Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
