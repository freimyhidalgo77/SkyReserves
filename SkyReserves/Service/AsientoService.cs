using Microsoft.EntityFrameworkCore;
using SkyReserve.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class AsientoService(IDbContextFactory<Context> DbFactory)
    {

        private async Task<bool> Existe(int asientoId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Asientos.AnyAsync(e => e.AsientoId == asientoId);
        }

        private async Task<bool> Insertar(Asiento asientoId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Asientos.Add(asientoId);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Asiento asientosdId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Asientos.Update(asientosdId);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Asiento asientoId)
        {
            if (!await Existe(asientoId.AsientoId))
                return await Insertar(asientoId);
            else
                return await Modificar(asientoId);
        }

        public async Task<bool> Eliminar(int asientoId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Asientos
                .Where(e => e.AsientoId == asientoId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Asiento> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Asientos
                .FirstOrDefaultAsync(e => e.AsientoId == id);
        }

        public async Task<List<Asiento>> Listar(Expression<Func<Asiento, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Asientos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }



    }
}

