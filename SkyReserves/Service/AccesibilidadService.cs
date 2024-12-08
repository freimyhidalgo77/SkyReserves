using Microsoft.EntityFrameworkCore;
using SkyReserves.DAL;
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
            return await context.Accesibilidad2.AnyAsync(e => e.AccesibilidadId == accesibilidadId);
        }

        private async Task<bool> Insertar(Accesibilidad2 accesibilidad)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Accesibilidad2.Add(accesibilidad);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Accesibilidad2 accesibilidad)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Accesibilidad2.Update(accesibilidad);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Accesibilidad2 accesibilidad)
        {
            if (!await Existe(accesibilidad.AccesibilidadId))
                return await Insertar(accesibilidad);
            else
                return await Modificar(accesibilidad);
        }

        public async Task<bool> Eliminar(int accecibilidadId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Accesibilidad2
                .Where(e => e.AccesibilidadId == accecibilidadId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Accesibilidad2> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Accesibilidad2
                .FirstOrDefaultAsync(e => e.AccesibilidadId == id);
        }

        public async Task<Accesibilidad2?> BuscarAccesibilidad(string descripcion)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Accesibilidad2  
                .FirstOrDefaultAsync(e => e.Descripcion == descripcion);
        }
      

        public async Task<List<Accesibilidad2>> Listar(Expression<Func<Accesibilidad2, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Accesibilidad2
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }

}

