﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Models;

namespace UniVerseAPI.Application.Interface
{
    public interface IStudentInterface
    {
        public Task<List<Student>> GetAllStudents();

    }
}
