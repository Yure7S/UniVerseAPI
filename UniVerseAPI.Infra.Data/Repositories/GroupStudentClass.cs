﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Domain.Entities.MasterEntities;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;
using UniVerseAPI.Infra.Data.Repositoryes;

namespace UniVerseAPI.Infra.Data.Repositories
{
    public class GroupStudentClassRepository : BaseRepository<GroupStudentClass>, IGroupStudentClass
    {
        public GroupStudentClassRepository(UniDBContext db) : base(db)
        {
        }

        public async Task<GroupStudentClass?> GetByClassIdAndStudentId(Guid? studentId, Guid? classId)
        {
            return await _db.GroupStudentClass.FirstOrDefaultAsync(gsc => gsc.ClassId == classId && gsc.StudentId == studentId);
        }
    }
}
