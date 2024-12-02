using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P_SGI_BE.Models;
using P_SGI_BE.ViewModel;

namespace P_SGI_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : Controller
    {
        private readonly AplicationDbContext _context;
        public ClientesController(AplicationDbContext context) { _context = context; }
        [HttpGet("obtener-factura")]
        public async Task<IActionResult> OtenerLastFactura(int idCliente)
        {
            try
            {
                var numeroFactura = await (from venta in _context.Ventas
                                           where venta.IdPropietario == idCliente
                                           select venta.NumFactura)
                          .MaxAsync();
                return Ok(numeroFactura);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("metodos-pago-listado")]
        public async Task<IActionResult> ListaMetodosPago(int idCliente)
        {
            try
            {
                var metodosPago = await (from metodos in _context.MetodoPago
                                         where metodos.IdPropietario == idCliente
                                         select new
                                         {
                                             metodos.Id,
                                             metodos.Nombre
                                         }).ToArrayAsync();
                return Ok(metodosPago);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("clientes-listado")]
        public async Task<IActionResult> ListaClientes(int IdCliente)
        {
            try
            {
                var listaClientes = await (from cli in _context.Clientes
                                           where cli.IdPropietario == IdCliente
                                           select new
                                           {
                                               cli.Id,
                                               cli.Nombre,
                                               cli.Apellido,
                                               cli.Direccion,
                                               cli.Telefono
                                           }).ToArrayAsync();
                return Ok(listaClientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("clientes-agregar")]
        public async Task<IActionResult> AgregarClientes(ClienteViewModels clienteModel)
        {
            try
            {
                var cliente = new Clientes
                {
                    Nombre = clienteModel.Nombre,
                    Apellido = clienteModel.Apellido,
                    Telefono = clienteModel.Telefono,
                    Direccion = clienteModel.Direccion,
                    IdPropietario = clienteModel.IdPropietario
                };
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("clientes-editar/{idCliente}")]
        public async Task<IActionResult> EditarClientes(ClienteViewModels clienteModel, int idCliente)
        {
            try
            {
                if(idCliente == 0)
                {
                    return BadRequest();
                }
                var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == idCliente);
                if(cliente == null)
                {
                    cliente = new Clientes
                    {
                        Nombre = clienteModel.Nombre,
                        Apellido = clienteModel.Apellido,
                        Telefono = clienteModel.Telefono,
                        Direccion = clienteModel.Direccion,
                        IdPropietario = clienteModel.IdPropietario
                    };
                    _context.Add(cliente);
                }
                else
                {
                    cliente.Nombre = clienteModel.Nombre;
                    cliente.Apellido = clienteModel.Apellido;
                    cliente.Direccion = clienteModel.Direccion;
                    cliente.Telefono = clienteModel.Telefono;
                    _context.Entry(cliente).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
