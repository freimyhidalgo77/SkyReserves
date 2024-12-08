using Microsoft.EntityFrameworkCore;
using SkyReserves.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class AsientoDetalleService
    {
        private readonly IDbContextFactory<Context> _dbContextFactory;

        public AsientoDetalleService(IDbContextFactory<Context> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        public async Task<List<Asiento2>> Listar(Expression<Func<Asiento2, bool>> criterio)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Asientos2.Where(criterio).ToListAsync();
        }

        public async Task<bool> Eliminar(int detalleId)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            var detalle = await context.AsientoDetalles1.FindAsync(detalleId);
            if (detalle != null)
            {
                context.AsientoDetalles1.Remove(detalle);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<AsientoDetalle>> ListarAsientoDetalle(int reservaId)
        {
          
            await using var context = await _dbContextFactory.CreateDbContextAsync();

        
            return await context.AsientoDetalles1
                .Where(a => a.ReservaId == reservaId)  
                .Include(a => a.Asiento)  
                .ToListAsync();  
        }

    }
}
