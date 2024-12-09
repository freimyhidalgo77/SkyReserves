using Microsoft.EntityFrameworkCore;
using SkyReserves.Models;
using System.Linq.Expressions;
using System.Security.AccessControl;

namespace SkyReserves.Service
{
    public class AccesibilidadService(IDbContextFactory<Context> DbFactory)

    {
        private async Task<bool> Existe(int accesibilidadId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Accesibilidad.AnyAsync(e => e.AccesibilidadId == accesibilidadId);
        }

        private async Task<bool> Insertar(Accesibilidad accesibilidad)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Accesibilidad.Add(accesibilidad);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Accesibilidad accesibilidad)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Accesibilidad.Update(accesibilidad);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Accesibilidad accesibilidad)
        {
            if (!await Existe(accesibilidad.AccesibilidadId))
                return await Insertar(accesibilidad);
            else
                return await Modificar(accesibilidad);
        }

        public async Task<bool> Eliminar(int accecibilidadId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Accesibilidad
                .Where(e => e.AccesibilidadId == accecibilidadId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Accesibilidad> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Accesibilidad
                .FirstOrDefaultAsync(e => e.AccesibilidadId == id);
        }

        public async Task<List<Accesibilidad>> Listar(Expression<Func<Accesibilidad, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Accesibilidad
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }


        public async Task<Accesibilidad?> BuscarAccesibilidad(string descripcion)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Accesibilidad
                .FirstOrDefaultAsync(e => e.Descripcion == descripcion);
        }

    }

}

