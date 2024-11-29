using Microsoft.EntityFrameworkCore;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class HoraService(IDbContextFactory<Context> DbFactory)
    {

        private async Task<bool> Existe(int horaId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Hora.AnyAsync(e => e.HoraID == horaId);
        }

        private async Task<bool> Insertar(Hora hora)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Hora.Add(hora);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Hora hora)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Hora.Update(hora);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Hora hora)
        {
            if (!await Existe(hora.HoraID))
                return await Insertar(hora);
            else
                return await Modificar(hora);
        }

        public async Task<bool> Eliminar(int horaId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Hora
                .Where(e => e.HoraID == horaId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Hora> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Hora
                .FirstOrDefaultAsync(e => e.HoraID == id);
        }

        public async Task<List<Hora>> Listar(Expression<Func<Hora, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Hora
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }
}
