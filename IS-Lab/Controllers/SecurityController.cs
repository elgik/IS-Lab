using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Lab.Domain;
using System.Security.Cryptography;

namespace IS_Lab.Controllers
{
    /// <summary>
    /// Предоставляет общие методы для шифрования/проверки паролей
    /// </summary>
    public static class SecurityController
    {
        public static string Encrypt(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
        }

        public static bool Verify(string password, User user)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }
    }
}
