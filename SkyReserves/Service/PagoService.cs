using Microsoft.EntityFrameworkCore;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class PagoService
    {
        private readonly IDbContextFactory<Context> _dbFactory;

        public PagoService(IDbContextFactory<Context> DbFactory)
        {
            _dbFactory = DbFactory;
        }

        private async Task<bool> Existe(int pagoId)
        {
            await using var context = await _dbFactory.CreateDbContextAsync();
            return await context.Pago.AnyAsync(e => e.PagoId == pagoId);
        }

        private async Task<bool> Insertar(Pago pago)
        {
            await using var context = await _dbFactory.CreateDbContextAsync();
            context.Pago.Add(pago);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Pago pago)
        {
            await using var context = await _dbFactory.CreateDbContextAsync();
            context.Pago.Update(pago);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Pago pago)
        {
            if (!await Existe(pago.PagoId))
                return await Insertar(pago);
            else
                return await Modificar(pago);
        }

        public async Task<bool> Eliminar(int pagoId)
        {
            await using var context = await _dbFactory.CreateDbContextAsync();
            return await context.Pago
                .Where(e => e.PagoId == pagoId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Pago> Buscar(int id)
        {
            await using var context = await _dbFactory.CreateDbContextAsync();
            return await context.Pago
                .FirstOrDefaultAsync(e => e.PagoId == id);
        }

        public async Task<List<Pago>> Listar(Expression<Func<Pago, bool>> criterio)
        {
            await using var context = await _dbFactory.CreateDbContextAsync();
            return await context.Pago
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<bool> GuardarPago(Pago pago)
        {
            if (!await Existe(pago.PagoId))
            {
                
                return await Insertar(pago);
            }
            else
            {
                
                return await Modificar(pago);
            }
        }


    }
}
