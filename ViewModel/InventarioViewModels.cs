namespace P_SGI_BE.ViewModel
{
    public class InventarioViewModels
    {
        public int IdProducto { get; set; }
        public double Cantidad { get; set; }
        public int IdProveedor { get; set; }
        public int IdPropietario { get; set; }
    }
    public class MovimientosInventarioViewModels
    {
        public double Cantidad { get; set; }
        public int IdProducto { get; set; }
        public double ValorTotal { get; set; }
        public int NumFactura { get; set; }
        public int IdUsuario { get; set; }
        public int IdPropietario { get; set; }
    }
    public class CostosViewModels
    {
        public int NumFactura { get; set; }
        public double valorTotal { get; set; }
        public int IdUsuario { get; set; }
        public int IdPropietario { get; set; }
    }

}
