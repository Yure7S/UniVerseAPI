using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats;
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
    public class CourseRepository : BaseRepository<Course>, ICourse
    {

        public CourseRepository(UniDBContext db) : base(db)
        {
        }

        public async Task<Course?> GetByCodeAsync(string code)
        {
            return await _db.Course.FirstOrDefaultAsync(c => c.Code == code);
        }
    }
}
