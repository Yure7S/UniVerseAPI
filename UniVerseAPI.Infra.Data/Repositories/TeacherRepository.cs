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

        public async Task<Teacher?> GetByCodeAsync(string code)
        {
            return await _db.Teacher.FirstOrDefaultAsync(tchr => tchr.Code == code);
        }

        public async Task<List<Teacher>> GetAllTeacherAsync()
        {
            return await _db.Teacher.Where(tchr => true)
                .Include(s => s.People)
                .ThenInclude(s => s.AddressEntity)
                .Include(s => s.People.User)
                .ToListAsync();
        }

        public async Task<Teacher> GetTeacherDetailAsync(string code)
        {
            return await _db.Teacher.Where(s => s.Code == code)
                .Include(s => s.People)
                .ThenInclude(s => s.AddressEntity)
                .Include(s => s.People.User)
                .FirstAsync();
        }
    }
}
