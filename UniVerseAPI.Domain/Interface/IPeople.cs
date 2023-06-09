﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Domain.Interface
{
    public interface IPeople : IBaseInterface<People>
    {
        public Task<People?> GetByEmailAndPassword(string email, string password);
    }
}
