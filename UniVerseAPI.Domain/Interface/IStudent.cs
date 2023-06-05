﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Interface
{
    public interface IStudent : IBaseInterface<Student> 
    {
        public Task<ICollection<Student>> GetStudentDetailAsync(Guid id);
    }
}