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
    public class SubjectRepository : BaseRepository<Subject>, ISubject
    {

        public SubjectRepository(UniDBContext db) : base(db)
        {
        }

        public async Task<Subject?> GetByCodeAsync(string code)
        {
            return await _db.Subject.SingleOrDefaultAsync(c => c.Code == code);
        }

        public async Task<List<Subject>> GetAllSubjects()
        {
            return await _db.Subject.Where(s => true)
                .Include(s => s.Teacher)
                .Include(s => s.Course)
                .Include(s => s.Class)
                .ToListAsync();
        }

        public async Task<Subject> GetSubjectDetailAsync(string code)
        {
            return await _db.Subject.Where(s => s.Code == code)
                .Include(s => s.Teacher)
                .Include(s => s.Course)
                .Include(s => s.Class)
                .FirstAsync();
        }

    }
}
