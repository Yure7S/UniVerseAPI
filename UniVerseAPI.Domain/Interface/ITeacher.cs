using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Interface
{
    public interface ITeacher : IBaseInterface<Teacher> 
    {
        public Task<List<Teacher>> GetAllTeacherAsync();
        public Task<Teacher> GetTeacherDetailAsync(Guid id);
    }

}
