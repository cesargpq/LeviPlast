using LeviPlast.Aplicacion.DTO;
using LeviPlast.Aplicacion.DTO.Auth;
using LeviPlast.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeviPlast.Aplicacion.Interface
{
    public interface IAuthApplication
    {
        Task<Response<bool>> Auth(AuthDTO authDto);
    }
}
