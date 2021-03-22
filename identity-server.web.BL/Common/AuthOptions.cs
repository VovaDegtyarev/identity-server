using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace identity_server.web.BL.Common
{
    public class AuthOptions
    {
        // тот кто сгенерировал токен
        public string Issuer { get; set; }

        // для кого предназначен токен
        public string Audience { get; set; }

        // секретная строка для генерации ключа симметричного шифрования
        public string Secret { get; set; }

        // время жизни токена
        public int TokenLifeTime { get; set; } // сек

        // метод генерации ключа шифрования
        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}
