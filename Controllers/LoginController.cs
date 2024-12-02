using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P_SGI_BE.Models;

namespace P_SGI_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly AplicationDbContext _context;
        public LoginController(AplicationDbContext context) { _context = context; }
        [HttpGet("auth")]
        public async Task<IActionResult> Login(string usuario, string password)
        {
            try
            {
                var user = await (from usu in _context.Usuarios
                                     join pro in _context.Propietarios on usu.IdPropietario equals pro.Id
                                     join tip in _context.TipoUsuarios on usu.IdTipoUsuario equals tip.Id
                                     where usu.Usuario == usuario && usu.Password == password
                                     select new
                                     {
                                         usu.Id,
                                         NombreUsuario = string.Concat(usu.Nombre, " ", usu.Apellido),
                                         Empresa = pro.NombreEmpresa,
                                         EmpresaId = pro.Id,
                                         TipoUsuario = tip.Nombre,
                                         IdTipoUsuario = tip.Id,
                                     }).ToArrayAsync();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
