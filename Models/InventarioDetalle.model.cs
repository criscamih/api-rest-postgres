using System;

namespace api_stock.Models
{
    public class InventarioDetalleModel
    {
        public int id_inventario { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string tipo { get; set; }
        public string  serial { get; set; }
        public decimal valor { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }
    }
}