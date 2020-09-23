using System;
using System.ComponentModel.DataAnnotations;

namespace api_stock.Models
{
    public class ProductoModel
    { 
        [Key]
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal valor { get; set; }
        public int id_proveedor { get; set; }
        public int id_tipo_producto { get; set; }
    }
}