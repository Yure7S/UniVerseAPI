using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;
using UniVerseAPI.Infra.Data.Repositoryes;
f
namespace UniVerseAPI.Infra.Data.Repositories
{
    public class GradesRepository : BaseRepository<Grades>, IGrades
    {
        public GradesRepository(UniDBContext db) : base(db)
        {
        }

        public async Task<List<Grades>> AllGradesForThisStudent(string registration)
        {
            return await _db.Grades
                .Include(grade => grade.Student)
                .Where(grade => grade.Student.Registration == registration)
                .ToListAsync();
        }
    }
}
