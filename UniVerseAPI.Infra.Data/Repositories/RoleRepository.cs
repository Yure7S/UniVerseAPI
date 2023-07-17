using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Domain.Enums;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;
using UniVerseAPI.Infra.Data.Repositoryes;

namespace UniVerseAPI.Infra.Data.Repositories
{
    public class RoleRepository : IRoles
    {
        private readonly UniDBContext _db;

        public RoleRepository(UniDBContext db)
        {
            _db = db;
        }

        public async Task<Roles?> GetRoleByRoleValue(RolesEnum role)
        {
            return await _db.Roles.FirstOrDefaultAsync(rl => rl.RoleValue == role.ToString());
        }
    }
}
