using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Domain.Interface
{
    public interface ISubject : IBaseInterface<Subject>
    {
        public Task<Subject?> GetByCodeAsync(string code);
        public Task<Subject> GetSubjectDetailAsync(string code);
        public Task<List<Subject>> GetAllSubjects();

    }
}
