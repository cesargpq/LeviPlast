using LeviPlast.Dominio.Entity;
using LeviPlast.Dominio.Interface;
using LeviPlast.Infraestructura.Interface;
using LeviPlast.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeviPlast.Dominio.Core
{
    public class AuthDomain : IAuthDomain
    {
        private readonly IAuthRepository _authRepository;

        public AuthDomain(IAuthRepository authRepository)
        {
            this._authRepository = authRepository;
        }
       

        public async Task<bool> Auth(Auth user)
        {
           return await _authRepository.Auth(user);
        }
    }
}
