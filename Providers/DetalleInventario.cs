using api_stock.Models;
using System.Collections.Generic;
using System.Linq;
using api_stock.DataAccess;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_stock.common.interfaces;
using api_stock.Providers.Interfaces;
using api_stock.enums;

namespace api_stock.Providers{
    public class DetalleInventario : IDetalleInventario{
        
        private readonly DataAccessContext _context;
        public DetalleInventario(DataAccessContext context)
        {
            _context = context;
        }

        public async Task<InventarioDetalleModel> GetInventarioDetalle(int id) =>
                    await (from inv in _context.tbl_inventario
                            join prop in _context.tbl_producto
                            on inv.id_producto equals prop.id_producto
                            join pv in _context.tbl_proveedor
                            on prop.id_proveedor equals pv.id_proveedor
                            join em in _context.tbl_empleado
                            on inv.id_empleado equals em.id_empleado
                            join ar in _context.tbl_area
                            on inv.id_area equals ar.id_area
                            where inv.id_inventario == id
                            select new InventarioDetalleModel
                            {
                                id_inventario = inv.id_inventario,
                                nombre = prop.nombre,
                                descripcion = prop.descripcion,
                                tipo = prop.id_tipo_producto == 1 ? Enum.GetName(typeof(TipoProducto), TipoProducto.tecnologico) : prop.id_tipo_producto == 2 ? Enum.GetName(typeof(TipoProducto), TipoProducto.miscelaneo) : Enum.GetName(typeof(TipoProducto), TipoProducto.inmueble),
                                serial = inv.codigo_serial,
                                valor = prop.valor,
                                fecha = inv.fecha,
                                estado = inv.id_estado == 1 ? Enum.GetName(typeof(EstadoProducto), EstadoProducto.activo) : prop.id_tipo_producto == 2 ? Enum.GetName(typeof(EstadoProducto), EstadoProducto.reparado) : Enum.GetName(typeof(EstadoProducto), EstadoProducto.no_funcional)
                            }).FirstOrDefaultAsync();
    }
}