using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Infra.Data.Repositoryes
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacher
    {
        public TeacherRepository(UniDBContext db) : base(db)
        {
        }

    }
}
