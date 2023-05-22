using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Models;

namespace UniVerseAPI.Infra.Data.Repositoryes
{
    internal class StudentRepository : IStudentInterface
    {
        public readonly UniDBContext _db;

        public StudentRepository(UniDBContext db)
        {
            _db = db;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _db.Student.ToListAsync();
        }

        public async Task<Student> GetById(Guid id)
        {
            Student _student = await _db.Student.SingleOrDefaultAsync(x => x.Id == id);
            return _student;
        }

        public async Task<Student> CreateStudent(Student _student)
        {
            Student studentAdd = await _db.Student.AddAsync(_student);
            return studentAdd;
        }

        public Task<Student> DeleteStudent(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
