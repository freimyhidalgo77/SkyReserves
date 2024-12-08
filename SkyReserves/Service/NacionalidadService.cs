using Microsoft.EntityFrameworkCore;
using SkyReserves.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class NacionalidadService(IDbContextFactory<Context> DbFactory)
    {

        private async Task<bool> Existe(int nationalityId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Nacionalida1.AnyAsync(e => e.NacionalidadId == nationalityId);
        }

        private async Task<bool> Insertar(Nacionalidad1 nacionalidadId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Nacionalida1.Add(nacionalidadId);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Nacionalidad1 nacionalidad)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Nacionalida1.Update(nacionalidad);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Nacionalidad1 nacionalidad)
        {
            if (!await Existe(nacionalidad.NacionalidadId))
                return await Insertar(nacionalidad);
            else
                return await Modificar(nacionalidad);
        }

        public async Task<bool> Eliminar(int nacionalidadId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Nacionalida1
                .Where(e => e.NacionalidadId == nacionalidadId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Nacionalidad1> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Nacionalida1
                .FirstOrDefaultAsync(e => e.NacionalidadId == id);
        }

        public async Task<List<Nacionalidad1>> Listar(Expression<Func<Nacionalidad1, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Nacionalida1
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }
}
