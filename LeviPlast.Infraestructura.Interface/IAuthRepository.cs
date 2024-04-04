using LeviPlast.Aplicacion.DTO.Auth;
using LeviPlast.Dominio.Entity;
using LeviPlast.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeviPlast.Infraestructura.Interface
{
    public interface IAuthRepository
    {
        Task<bool> Auth(Auth auth);
    }
}
