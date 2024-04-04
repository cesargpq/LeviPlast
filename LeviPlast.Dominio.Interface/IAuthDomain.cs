using LeviPlast.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeviPlast.Dominio.Interface
{
    public interface IAuthDomain
    {
        Task<bool> Auth(Auth user);
    }
}
