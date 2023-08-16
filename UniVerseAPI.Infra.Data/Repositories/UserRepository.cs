using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NPOI.OpenXmlFormats;
using NPOI.OpenXmlFormats.Dml;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;
using IUser = UniVerseAPI.Domain.Interface.IUser;

namespace UniVerseAPI.Infra.Data.Repositoryes
{
    public class UserRepository : BaseRepository<User>, IUser
    {

        public UserRepository(UniDBContext db) : base(db)
        {
        }

        public User? GetByEmailAndPassword(string email, string password)
        {
            return _db.User
                .Include(user => user.Roles)
                .FirstOrDefault(user => user.Email == email && user.Password == password);
        }
    }
}
