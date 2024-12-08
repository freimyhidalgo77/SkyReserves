using Microsoft.EntityFrameworkCore;
using SkyReserves.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class PasaporteDetalleService(IDbContextFactory<Context> DbFactory)
    {

        public async Task<List<PasaporteDetalle2>> Listar(Expression<Func<PasaporteDetalle2, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.PasaportesDetalle
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }
}
