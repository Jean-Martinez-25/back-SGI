using P_SGI_BE.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace P_SGI_BE.ViewModel
{
    public class ClienteViewModels
    {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }
            public int IdPropietario { get; set; }
    }
}
