using System;
using System.Collections.Generic;
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
    }
}
