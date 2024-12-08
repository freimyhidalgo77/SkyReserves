using Microsoft.EntityFrameworkCore;
using SkyReserves.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class HoraService(IDbContextFactory<Context> DbFactory)
    {

        private async Task<bool> Existe(int horaId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Hora2.AnyAsync(e => e.HoraID == horaId);
        }

        private async Task<bool> Insertar(Hora2 hora)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Hora2.Add(hora);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Hora2 hora)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Hora2.Update(hora);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Hora2 hora)
        {
            if (!await Existe(hora.HoraID))
                return await Insertar(hora);
            else
                return await Modificar(hora);
        }

        public async Task<bool> Eliminar(int horaId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Hora2
                .Where(e => e.HoraID == horaId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Hora2> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Hora2
                .FirstOrDefaultAsync(e => e.HoraID == id);
        }

        public async Task<List<Hora2>> Listar(Expression<Func<Hora2, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Hora2
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }
}
