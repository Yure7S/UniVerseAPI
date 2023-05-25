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
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Infra.Data.Repositoryes
{
    public class CourseRepository : BaseRepository<Course>, ICourse
    {

        public CourseRepository(UniDBContext db) : base(db)
        {
        }


    }
}
