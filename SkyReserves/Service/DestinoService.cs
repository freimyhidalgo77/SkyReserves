using Microsoft.EntityFrameworkCore;
using SkyReserves.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class DestinoService(IDbContextFactory<Context> DbFactory)
    {
        private async Task<bool> Existe(int destinoId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Destino2.AnyAsync(e => e.DestinoId == destinoId);
        }

        private async Task<bool> Insertar(Destino2 destino)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Destino2.Add(destino);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Destino2 destino)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Destino2.Update(destino);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Destino2 destino)
        {
            if (!await Existe(destino.DestinoId))
                return await Insertar(destino);
            else
                return await Modificar(destino);
        }

        public async Task<bool> Eliminar(int destinoId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Destino2
                .Where(e => e.DestinoId == destinoId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Destino2?> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Destino2
                .FirstOrDefaultAsync(e => e.DestinoId == id);
        }

        public async Task<Destino2?> BuscarDestino(string destino)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Destino2
                .FirstOrDefaultAsync(e => e.destino == destino);
        }


        public async Task<List<Destino2>> Listar(Expression<Func<Destino2, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Destino2
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }
}
