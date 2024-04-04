using AutoMapper;
using LeviPlast.Aplicacion.DTO;
using LeviPlast.Aplicacion.DTO.Auth;
using LeviPlast.Aplicacion.Interface;
using LeviPlast.Dominio.Entity;
using LeviPlast.Dominio.Interface;
using LeviPlast.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeviPlast.Aplicacion.Main
{
    public class AuthApplication : IAuthApplication
    {
        private readonly IMapper _mapper;
        private readonly IAuthDomain _authDomain;

        public AuthApplication(IMapper mapper, IAuthDomain authDomain)
        {
            this._mapper = mapper;
            this._authDomain = authDomain;
        }
        public async Task<Response<bool>> Auth(AuthDTO authDto)
        {
            var response = new Response<bool>();
            try
            {
                
                var auth = _mapper.Map<Auth>(authDto);
                response.Data = await _authDomain.Auth(auth);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Información correcta";
                    return response;
                }
                response.IsSuccess = false;
                response.Message = "Información incorrecta";

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
    }
}
