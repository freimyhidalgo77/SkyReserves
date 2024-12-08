using Microsoft.EntityFrameworkCore;
using SkyReserves.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class OrigenService(IDbContextFactory<Context> DbFactory)
    {
        private async Task<bool> Existe(int origenId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Origen2.AnyAsync(e => e.OrigenId == origenId);
        }

        private async Task<bool> Insertar(Origen2 origen)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Origen2.Add(origen);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Origen2 origen)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Origen2.Update(origen);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Origen2 origen)
        {
            if (!await Existe(origen.OrigenId))
                return await Insertar(origen);
            else
                return await Modificar(origen);
        }

        public async Task<bool> Eliminar(int origenId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Origen2
                .Where(e => e.OrigenId == origenId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Origen2?> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Origen2
                .FirstOrDefaultAsync(e => e.OrigenId == id);
        }

        public async Task<Origen2?> BuscarOrigen(string origen)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Origen2
                .FirstOrDefaultAsync(e => e.origen == origen);
        }


        public async Task<List<Origen2>> Listar(Expression<Func<Origen2, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Origen2
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();

        }

    }
}
