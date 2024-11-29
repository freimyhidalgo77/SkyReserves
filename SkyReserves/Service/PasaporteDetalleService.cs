using Microsoft.EntityFrameworkCore;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class PasaporteDetalleService(IDbContextFactory<Context> DbFactory)
    {

        public async Task<List<PasaporteDetalle>> Listar(Expression<Func<PasaporteDetalle, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.PasaporteDetalles
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }
}
