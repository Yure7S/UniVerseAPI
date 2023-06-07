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

        public async Task<List<Teacher>> GetAllTeacherAsync()
        {
            return await _db.Teacher.Where(tchr => true)
                .Include(s => s.People)
                .ThenInclude(s => s.AddressEntity)
                .ToListAsync();
        }

        public async Task<Teacher> GetTeacherDetailAsync(Guid id)
        {
            return await _db.Teacher.Where(s => s.Id == id)
                .Include(s => s.People)
                .ThenInclude(s => s.AddressEntity)
                .FirstAsync();
        }
    }
}
