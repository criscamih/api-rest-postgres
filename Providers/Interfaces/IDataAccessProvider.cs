using api_stock.Models;
using System.Collections.Generic;

namespace api_stock.Providers.Interfaces{
    public interface IDataAccessProvider{

        InventarioDetalleModel GetProductById(int id);
        IEnumerable<InventarioDetalleModel> GetAllProducts();
        void AddInventarioRecord(InventarioModel inventario);
        void UpdateInventario(InventarioModel inventario);

        void DeleteInventario(int id);

    }
}