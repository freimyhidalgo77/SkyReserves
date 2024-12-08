using Microsoft.EntityFrameworkCore;
using SkyReserves.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class AsientoDetalleService(IDbContextFactory<Context> DbFactory)
    {

        private readonly Context _context;

       /* public async Task<List<AsientoDetalle>> Listar(Expression<Func<AsientoDetalle, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.AsientoDetalles1.Where(criterio).ToListAsync();
        }*/

        public async Task<List<Asiento2>> Listar(Expression<Func<Asiento2, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Asientos2.Where(criterio).ToListAsync();
        }


    }
}
