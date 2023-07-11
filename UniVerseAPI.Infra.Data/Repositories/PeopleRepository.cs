using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;
using UniVerseAPI.Infra.Data.Repositoryes;

namespace UniVerseAPI.Infra.Data.Repositories
{
    public class PeopleRepository : BaseRepository<People>, IPeople
    {
        public PeopleRepository(UniDBContext db) : base(db)
        {
        }

        public async Task<People?> GetByEmailAndPassword(string email, string password)
        {
            return await _db.People.FirstOrDefaultAsync(p => p.Email == email && p.Password == password);
        }
    }
}
