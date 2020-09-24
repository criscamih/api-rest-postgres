using api_stock.Models;
using System.Collections.Generic;

namespace api_stock.Providers.Interfaces{
    public interface IDataAccessProducto{
        IEnumerable<ProductoModel> GetAllProductos();
    }
}