using NPOI.SS.Formula.Functions;
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
    public class AddressEntityRepository : BaseRepository<AddressEntity>, IAddressEntity
    {
        public AddressEntityRepository(UniDBContext db) : base(db)
        {
        }
    }
}
