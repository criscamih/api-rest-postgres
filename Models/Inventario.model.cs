using System;
using System.ComponentModel.DataAnnotations;

namespace api_stock.Models
{
    public class InventarioModel
    { 
        [Key]
        public int id_inventario { get; set; }
        public string codigo_serial { get; set; }
        public DateTime fecha { get; set; }
        public string  observaciones { get; set; }   
        public int id_producto { get; set; }
        public int? id_empleado { get; set; }

        public int id_area { get; set; }

        public int id_estado { get; set; }

    }
}