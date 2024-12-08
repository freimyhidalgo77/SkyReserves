using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
            return await context.Reserva2.AnyAsync(e => e.ReservaId == reservaId);
        }

        private async Task<bool> Insertar(Reserva2 reserva)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Reserva2.Add(reserva);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Reserva2 reservaId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Reserva2.Update(reservaId);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Reserva2 reserva)
        {
            if (!await Existe(reserva.ReservaId))
                return await Insertar(reserva);
            else
                return await Modificar(reserva);
        }
         
        public async Task<bool> Eliminar(int reservaId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Reserva2
                .Where(e => e.ReservaId == reservaId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Reserva2> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Reserva2
                .FirstOrDefaultAsync(e => e.ReservaId == id);
        }

        public async Task<List<Reserva2>> Listar(Expression<Func<Reserva2, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Reserva2
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }


        public async Task<Reserva2?> BuscarConDetalle(int reservaId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Reserva2
                .Where(r => r.ReservaId == reservaId)
                .Include(r => r.AsientoDetalle)
                .ThenInclude(ad => ad.Asiento)
                .Include(r => r.ClaseVueloDetalle)
                .ThenInclude(cd => cd.ClaseVuelo)
                .FirstOrDefaultAsync();
        }




    }
}
