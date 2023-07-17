using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats;
using NPOI.OpenXmlFormats.Dml;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Infra.Data.Repositoryes
{
    public class UserRepository : BaseRepository<User>, IUser
    {

        public UserRepository(UniDBContext db) : base(db)
        {
        }
    }
}
