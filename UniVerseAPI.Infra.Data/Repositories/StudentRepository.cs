using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Infra.Data.Repositoryes
{
    public class StudentRepository : /*BaseRepository<Student>,*/ IStudentInterface
    {
        /*
            public StudentRepository(UniDBContext db) : base(db)
            {
            } 
        */

        // Injecting base repository and dbcontext
        private readonly UniDBContext _dbContext;
        private readonly IBaseInterface<Student> _BaseRepository;

        public StudentRepository(UniDBContext dbContext, IBaseInterface<Student> baseRepository)
        {
            _dbContext = dbContext;
            _BaseRepository = baseRepository;   
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _dbContext.Student.ToListAsync();
        }
    }
}
