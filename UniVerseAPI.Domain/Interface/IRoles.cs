using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Domain.Enums;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Domain.Interface
{
    public interface IRoles
    {
        public Task<Roles?> GetRoleByRoleValue(RolesEnum roles);
    }
}
