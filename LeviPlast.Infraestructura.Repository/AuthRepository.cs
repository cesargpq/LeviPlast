using LeviPlast.Infraestructura.Interface;
using LeviPlast.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeviPlast.Infraestructura.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public AuthRepository(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }

        public bool Auth()
        {
            
        }
    }
}
