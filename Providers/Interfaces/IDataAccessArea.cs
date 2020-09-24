using api_stock.Models;
using System.Collections.Generic;

namespace api_stock.Providers.Interfaces{
    public interface IDataAccessArea{
        IEnumerable<AreaModel> GetAllAreas();
    }
}