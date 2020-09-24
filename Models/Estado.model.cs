using System;
using System.ComponentModel.DataAnnotations;

namespace api_stock.Models
{
    public class EstadoModel
    {   
        [Key]
        public int id_estado { get; set; }   
        public string nombre { get; set; }
        public string descripcion { get; set; }

    }
}