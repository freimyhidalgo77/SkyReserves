using Microsoft.EntityFrameworkCore;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class DestinoService(IDbContextFactory<Context> DbFactory)
    {
        private async Task<bool> Existe(int destinoId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Destino.AnyAsync(e => e.DestinoId == destinoId);
        }

        private async Task<bool> Insertar(Destino destino)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Destino.Add(destino);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Destino destino)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Destino.Update(destino);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Destino destino)
        {
            if (!await Existe(destino.DestinoId))
                return await Insertar(destino);
            else
                return await Modificar(destino);
        }

        public async Task<bool> Eliminar(int destinoId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Destino
                .Where(e => e.DestinoId == destinoId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Destino> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Destino
                .FirstOrDefaultAsync(e => e.DestinoId == id);
        }

        public async Task<List<Destino>> Listar(Expression<Func<Destino, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Destino
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<Destino?> BuscarDestino(string destino)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Destino
                .FirstOrDefaultAsync(e => e.destino == destino);
        }


    }
}
