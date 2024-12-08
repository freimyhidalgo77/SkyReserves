using Microsoft.EntityFrameworkCore;
using SkyReserves.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class AsientoDetalleService(IDbContextFactory<Context> DbFactory)
    {

        private readonly Context _context;


        public async Task<List<Asiento2>> Listar(Expression<Func<Asiento2, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Asientos2.Where(criterio).ToListAsync();
        }


        public async Task<bool> Eliminar(int detalleId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var detalle = await contexto.AsientoDetalles1.FindAsync(detalleId);
            if (detalle != null)
            {

                contexto.AsientoDetalles1.Remove(detalle);
                await contexto.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<AsientoDetalle>> ListarAsientoDetalle(Expression<Func<AsientoDetalle, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.AsientoDetalles1
                .Where(criterio)
                .ToListAsync();
        }





    }
}
