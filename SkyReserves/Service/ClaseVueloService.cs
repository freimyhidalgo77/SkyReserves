using Microsoft.EntityFrameworkCore;
using SkyReserve.DAL;
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

        private async Task<bool> Insertar(ClaseVuelo claseVuelo)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.ClaseVuelo.Add(claseVuelo);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(ClaseVuelo claseVuelo)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.ClaseVuelo.Update(claseVuelo);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(ClaseVuelo claseVuelo)
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

        public async Task<ClaseVuelo> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.ClaseVuelo
                .FirstOrDefaultAsync(e => e.ClaseVueloId == id);
        }

        public async Task<List<ClaseVuelo>> Listar(Expression<Func<ClaseVuelo, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.ClaseVuelo
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }
}
