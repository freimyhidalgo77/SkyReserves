using Microsoft.EntityFrameworkCore;
using SkyReserves.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class PasaporteService(IDbContextFactory<Context> DbFactory)
    {

        private async Task<bool> Existe(int pasaporteId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Pasaportes2.AnyAsync(e => e.PasaporteId == pasaporteId);
        }

        private async Task<bool> Insertar(Pasaporte2 pasaporte)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Pasaportes2.Add(pasaporte);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Pasaporte2 pasaporte)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Pasaportes2.Update(pasaporte);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Pasaporte2 pasaporte)
        {
            if (!await Existe(pasaporte.PasaporteId))
                return await Insertar(pasaporte);
            else
                return await Modificar(pasaporte);

        }

        public async Task<bool> Eliminar(int pasaporteId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Pasaportes2
                .Where(e => e.PasaporteId == pasaporteId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Pasaporte2> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Pasaportes2
                .FirstOrDefaultAsync(e => e.PasaporteId == id);
        }

        public async Task<List<Pasaporte2>> Listar(Expression<Func<Pasaporte2, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Pasaportes2
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }
}
