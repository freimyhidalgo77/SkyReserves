using Microsoft.EntityFrameworkCore;
using SkyReserve.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class OrigenService(IDbContextFactory<Context> DbFactory)
    {
        private async Task<bool> Existe(int origenId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Origen.AnyAsync(e => e.OrigenId == origenId);
        }

        private async Task<bool> Insertar(Origen origen)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Origen.Add(origen);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar( Origen origen)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Origen.Update(origen);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Origen origen)
        {
            if (!await Existe(origen.OrigenId))
                return await Insertar(origen);
            else
                return await Modificar(origen);
        }

        public async Task<bool> Eliminar(int origenId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Origen
                .Where(e => e.OrigenId == origenId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Origen> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Origen
                .FirstOrDefaultAsync(e => e.OrigenId == id);
        }

        public async Task<List<Origen>> Listar(Expression<Func<Origen, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Origen
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();

        }

    }
}
