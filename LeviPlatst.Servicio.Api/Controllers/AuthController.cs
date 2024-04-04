using LeviPlast.Aplicacion.DTO.Auth;
using LeviPlast.Aplicacion.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeviPlatst.Servicio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthApplication _authApplication;

        public AuthController(IAuthApplication authApplication)
        {
            this._authApplication = authApplication;
        }

        [HttpPost]
        public async Task<IActionResult> Auth(AuthDTO authDto)
        {
            var response=await _authApplication.Auth(authDto);
            
            return Ok(response);
        }
    }
}
