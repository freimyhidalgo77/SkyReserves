using Microsoft.EntityFrameworkCore;
using SkyReserve.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class NacionalidadService(IDbContextFactory<Context> DbFactory)
    {

        private async Task<bool> Existe(int nationalityId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Nacionalidad.AnyAsync(e => e.NacionalidadId == nationalityId);
        }

        private async Task<bool> Insertar(Nacionalidad nacionalidadId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Nacionalidad.Add(nacionalidadId);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Nacionalidad nacionalidad)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Nacionalidad.Update(nacionalidad);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Nacionalidad nacionalidad)
        {
            if (!await Existe(nacionalidad.NacionalidadId))
                return await Insertar(nacionalidad);
            else
                return await Modificar(nacionalidad);
        }

        public async Task<bool> Eliminar(int nacionalidadId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Nacionalidad
                .Where(e => e.NacionalidadId == nacionalidadId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Nacionalidad> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Nacionalidad
                .FirstOrDefaultAsync(e => e.NacionalidadId == id);
        }

        public async Task<List<Nacionalidad>> Listar(Expression<Func<Nacionalidad, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Nacionalidad
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }
}
