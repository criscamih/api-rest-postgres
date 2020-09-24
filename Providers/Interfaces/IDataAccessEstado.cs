using api_stock.Models;
using System.Collections.Generic;

namespace api_stock.Providers.Interfaces{
    public interface IDataAccessEstado{
        IEnumerable<EstadoModel> GetAllEstados();
    }
}