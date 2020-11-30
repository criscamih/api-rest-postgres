using System;
using System.ComponentModel.DataAnnotations;

namespace api_stock.Models
{
    public class TipoProductoModel
    {   
        [Key]
        public int id_tipo_producto { get; set; }   
        public string nombre { get; set; }
        public string descripcion { get; set; }

    }
}