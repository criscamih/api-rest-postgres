using api_stock.Models;
using System.Collections.Generic;
using System.Linq;
using api_stock.DataAccess;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_stock.common.interfaces;

namespace api_stock.Providers.Interfaces{
    public interface IDetalleInventario{
        Task<InventarioDetalleModel> GetInventarioDetalle(int id);
    }

}