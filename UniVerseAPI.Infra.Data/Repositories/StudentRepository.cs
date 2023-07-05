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

        public Task<List<Student>> GetAllStudentAsync()
        {
            return _db.Student
                .Include(s => s.People)
                .ThenInclude(s => s.AddressEntity)
                .ToListAsync();
        }

        public async Task<Student> GetStudentDetailAsync(string registration)
        {
            return await _db.Student.Where(s => s.Registration == registration)
                .Include(s => s.People)
                .ThenInclude(s => s.AddressEntity)
                .FirstAsync();
        }

        public async Task<Student?> GetStudentByEmailAsync(string email)
        {
            return await _db.Student
                .Include(s => s.People)
                .FirstOrDefaultAsync(p => p.People.Email == email);
        }
    }
}
