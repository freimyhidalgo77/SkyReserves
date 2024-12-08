using Microsoft.EntityFrameworkCore;
using SkyReserves.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class PagoService(IDbContextFactory<Context> DbFactory)
    {

        private async Task<bool> Existe(int pagoId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Pago2.AnyAsync(e => e.PagoId == pagoId);
        }

        private async Task<bool> Insertar(Pago2 pago)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Pago2.Add(pago);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Pago2 pago)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Pago2.Update(pago);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Pago2 pago)
        {
            if (!await Existe(pago.PagoId))
                return await Insertar(pago);
            else
                return await Modificar(pago);
        }

        public async Task<bool> Eliminar(int pagoId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Pago2
                .Where(e => e.PagoId == pagoId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Pago2> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Pago2
                .FirstOrDefaultAsync(e => e.PagoId == id);
        }

        public async Task<List<Pago2>> Listar(Expression<Func<Pago2, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Pago2
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }
}
