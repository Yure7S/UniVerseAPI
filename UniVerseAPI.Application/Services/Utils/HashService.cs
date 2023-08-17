using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UniVerseAPI.Application.Services.Utils
{
    public static class HashService
    {
        private static byte[] CreateSalt()
        {
            byte[] salt = new byte[32];
            var random = RandomNumberGenerator.Create();
            random.GetBytes(salt);
            return salt;
        }

        public static string GetHash(string password)
        {
            Argon2id argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = CreateSalt(),
            };

            return "ksfjlksjf";
        }
    }
}
