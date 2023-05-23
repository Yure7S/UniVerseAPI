using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Models;

namespace UniVerseAPI.Infra.Data.Repositoryes
{
    //                                  Inheriting methods    implementing interface
    public class StudentRepository : BaseRepository<Student>, IStudentInterface
    {
        public StudentRepository(UniDBContext db) : base(db)
        {
        }
    }
}
