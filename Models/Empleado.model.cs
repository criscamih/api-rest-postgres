using System;
using System.ComponentModel.DataAnnotations;

namespace api_stock.Models
{
    public class EmpleadoModel
    {   
        [Key]
        public int id_empleado { get; set; }   
        public string nombre { get; set; }
        public string dni { get; set; }
        public int id_area { get; set; }

    }
}