﻿using LeviPlast.Aplicacion.DTO.Auth;
using LeviPlast.Dominio.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeviPlast.Application.Common
{
    public class UtilitiesServices
    {
        private const string PasswordHash = "pass75dc@avz10";
        private const string SaltKey = "s@lAvz10";
        private const string VIKey = "@1B2c3D4e5F6g7H8";
        private const int KeySize = 128;
        private readonly IConfiguration _configuration;
        private readonly string _pathroot;

        public UtilitiesServices(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            var env = serviceProvider.GetService<IHostingEnvironment>();
            this._configuration = configuration;
        }

        public string Encriptar(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return default;

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);

            var keyBytes = new Rfc2898DeriveBytes(PasswordHash, System.Text.Encoding.ASCII.GetBytes(SaltKey)).GetBytes(KeySize / 8);
            var symmetricKey = new RijndaelManaged { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, System.Text.Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        public string Desencriptar(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText))
                return default;

            var cipherTextBytes = Convert.FromBase64String(encryptedText);
            var keyBytes = new Rfc2898DeriveBytes(PasswordHash, System.Text.Encoding.ASCII.GetBytes(SaltKey)).GetBytes(KeySize / 8);
            var symmetricKey = new RijndaelManaged { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, System.Text.Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            var plainTextBytes = new byte[cipherTextBytes.Length];

            var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return System.Text.Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }

        public AuthResponseDTO GenerateToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim("$I$Usr$@I@D", user.UserId.ToString()),
                new Claim("JTime", Guid.NewGuid().ToString())
            };

            var llave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["llaveJwt"]));
            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);
            var expiracion = DateTime.UtcNow.AddDays(10);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiracion, signingCredentials: creds);

            var jwt = new AuthResponseDTO   
            {
                Message = "Ingreso Satisfactorio",
                State = true,
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Time = expiracion
            };
            return jwt;

        }
    }
}
