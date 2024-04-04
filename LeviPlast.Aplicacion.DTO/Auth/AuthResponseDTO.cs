using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeviPlast.Aplicacion.DTO.Auth
{
    public class AuthResponseDTO
    {
        public string Message { get; set; }
        public bool State { get; set; }
        public string? Token { get; set; }
        public DateTime? Time { get; set; }
    }
}
