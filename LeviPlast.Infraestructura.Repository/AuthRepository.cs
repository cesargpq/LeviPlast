using LeviPlast.Aplicacion.DTO.Auth;
using LeviPlast.Dominio.Entity;
using LeviPlast.Infraestructura.Data;
using LeviPlast.Infraestructura.Interface;
using LeviPlast.Transversal.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeviPlast.Infraestructura.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ConnectionFactory _context;

        public AuthRepository(ConnectionFactory context)
        {
            this._context = context;
        }
       

        public async Task<AuthResponseDTO> Auth(Auth auth)
        {
            
            var data = await _context.User.Where(x=>x.UserName.Equals(auth.UserName) && x.Password.Equals(auth.Password)).FirstOrDefaultAsync();
            if (data != null)
            {
                return true;
            }
            else{
                return false;
            }
            
        }

       
    }
}
