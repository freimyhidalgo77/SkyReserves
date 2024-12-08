using Microsoft.EntityFrameworkCore;
using SkyReserves.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class ClaseVueloService(IDbContextFactory<Context> DbFactory)
    {

        private async Task<bool> Existe(int claseVueloId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.ClaseVuelo.AnyAsync(e => e.ClaseVueloId == claseVueloId);
        }

        private async Task<bool> Insertar(ClaseVuelo2 claseVuelo)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.ClaseVuelo.Add(claseVuelo);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(ClaseVuelo2 claseVuelo)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.ClaseVuelo.Update(claseVuelo);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(ClaseVuelo2 claseVuelo)
        {
            if (!await Existe(claseVuelo.ClaseVueloId))
                return await Insertar(claseVuelo);
            else
                return await Modificar(claseVuelo);
        }

        public async Task<bool> Eliminar(int clienteId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.ClaseVuelo
                .Where(e => e.ClaseVueloId == clienteId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<ClaseVuelo2> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.ClaseVuelo
                .FirstOrDefaultAsync(e => e.ClaseVueloId == id);
        }

        public async Task<List<ClaseVuelo2>> Listar(Expression<Func<ClaseVuelo2, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.ClaseVuelo
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }
}
