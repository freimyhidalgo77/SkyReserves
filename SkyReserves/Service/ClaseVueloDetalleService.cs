using Microsoft.EntityFrameworkCore;
using SkyReserves.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class ClaseVueloDetalleService(IDbContextFactory<Context> DbFactory)
    {

        private readonly Context _context;

        public async Task<List<ClaseVuelo2>> Listar(Expression<Func<ClaseVuelo2, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.ClaseVuelo.Where(criterio).ToListAsync();
        }

    }
}
