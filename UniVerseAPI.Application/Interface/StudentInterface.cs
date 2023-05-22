using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Models;

namespace UniVerseAPI.Application.Interface
{
    public interface IStudentInterface
    {
        public Task<Student> GetById(Guid id);
        public Task<List<Student>> GetAllStudents();
        public Task<Student> CreateStudent(Student student);
        public Task<Student> UpdateStudent(Student student);
        public Task<Student> DeleteStudent(Guid id);

    }
}
