﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Domain.Interface
{
    public interface IGrades : IBaseInterface<Grades>
    {
        public Task<List<Grades>> AllGradesForThisStudent(string registration);
    }
}
