using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api_stock.Models
{
    public class AreaModel
    { 
        [Key]
        public int id_area { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}