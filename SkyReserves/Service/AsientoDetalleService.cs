using Microsoft.EntityFrameworkCore;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class AsientoDetalleService(IDbContextFactory<Context> DbFactory)
    {
        public async Task<List<AsientoDetalle>> Listar(Expression<Func<AsientoDetalle, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.AsientoDetalles
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
