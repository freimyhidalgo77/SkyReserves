using Microsoft.EntityFrameworkCore;
using SkyReserves.Models;
using System.Linq.Expressions;
using System.Resources;

namespace SkyReserves.Service
{
    public class VueloService(IDbContextFactory<Context> DbFactory)
    {

        private async Task<bool> Existe(int reservaId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Vuelo.AnyAsync(e => e.VueloId == reservaId);
        }

        private async Task<bool> Insertar(Vuelo reservaId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Vuelo.Add(reservaId);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Vuelo reservaId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Vuelo.Update(reservaId);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Vuelo reserva)
        {
            if (!await Existe(reserva.VueloId))
                return await Insertar(reserva);
            else
                return await Modificar(reserva);
        }

        public async Task<bool> Eliminar(int reservaId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Vuelo
				.Where(e => e.VueloId == reservaId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Vuelo> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Vuelo
                .FirstOrDefaultAsync(e => e.VueloId == id);
        }

        public async Task<List<Vuelo>> Listar(Expression<Func<Vuelo, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Vuelo
                 .Include(v => v.Origen) // Incluye la entidad relacionada Origen
                .Include(v => v.Destino) // Incluye la entidad relacionada Destino
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }


        public async Task<Vuelo?> BuscarVuelo(int origenId, int destinoId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Vuelo
                .FirstOrDefaultAsync(v => v.OrigenId == origenId && v.DestinoId == destinoId);
        }


    }
}
