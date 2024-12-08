using Microsoft.EntityFrameworkCore;
using SkyReserves.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;
using System.Resources;

namespace SkyReserves.Service
{
    public class ReservaService(IDbContextFactory<Context> DbFactory)
    {

        private async Task<bool> Existe(int reservaId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Reserva.AnyAsync(e => e.ReservaId == reservaId);
        }

        private async Task<bool> Insertar(Reserva reserva)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Reserva.Add(reserva);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Reserva reservaId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Reserva.Update(reservaId);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Reserva reserva)
        {
            if (!await Existe(reserva.ReservaId))
                return await Insertar(reserva);
            else
                return await Modificar(reserva);
        }
         
        public async Task<bool> Eliminar(int reservaId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Reserva
                .Where(e => e.ReservaId == reservaId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Reserva> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Reserva
                .FirstOrDefaultAsync(e => e.ReservaId == id);
        }

        public async Task<List<Reserva>> Listar(Expression<Func<Reserva, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Reserva
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }


        public async Task<Reserva?> BuscarConDetalle(int Id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Reserva
                .Include(t => t.AsientoDetalle)
                .FirstOrDefaultAsync(t => t.ReservaId == Id);
        }




    }
}
