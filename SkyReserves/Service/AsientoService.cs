using Microsoft.EntityFrameworkCore;
using SkyReserves.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class AsientoService(IDbContextFactory<Context> DbFactory)
    {

        private async Task<bool> Existe(int asientoId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Asientos2.AnyAsync(e => e.AsientoId == asientoId);
        }

        private async Task<bool> Insertar(Asiento2 asientoId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Asientos2.Add(asientoId);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Asiento2 asientosdId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Asientos2.Update(asientosdId);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Asiento2 asientoId)
        {
            if (!await Existe(asientoId.AsientoId))
                return await Insertar(asientoId);
            else
                return await Modificar(asientoId);
        }

        public async Task<bool> Eliminar(int asientoId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Asientos2
                .Where(e => e.AsientoId == asientoId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Asiento2?> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
           return await context.Asientos2
           .Include(d => d.AsientoId)
           .FirstOrDefaultAsync(d => d.AsientoId== id);
        }

        public async Task<List<Asiento2>> Listar(Expression<Func<Asiento2, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Asientos2
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }


     



    }
}

