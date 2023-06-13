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
    public class StudentRepository : BaseRepository<Student>, IStudent
    {
        public StudentRepository(UniDBContext db) : base(db)
        {
        }

        public async Task<List<Student>> GetAllStudentAsync()
        {
            return await _db.Student.Where(std => true)
                .Include(s => s.People)
                .ThenInclude(s => s.AddressEntity)
                .ToListAsync();
        }

        public async Task<Student> GetStudentDetailAsync(Guid id)
        {
            return await _db.Student.Where(s => s.Id == id)
                .Include(s => s.People)
                .ThenInclude(s => s.AddressEntity)
                .FirstAsync();
        } 
    }
}
