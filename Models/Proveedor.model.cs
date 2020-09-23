using System;
using System.ComponentModel.DataAnnotations;

namespace api_stock.Models
{
    public class ProveedorModel
    { 
        [Key]
        public int id_proveedor { get; set; }
        public string nombre { get; set; }
        public string nit { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
    }
}