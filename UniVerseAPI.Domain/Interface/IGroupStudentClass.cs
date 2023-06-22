using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Domain.Entities.MasterEntities;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Domain.Interface
{
    public interface IGroupStudentClass : IBaseInterface<GroupStudentClass>
    {
        public Task<GroupStudentClass?> GetByClassIdAndStudentId(Guid? studentId, Guid? classId);

        public Task<List<GroupStudentClass>> GetByStudentId(Guid studentId);

    }
}
