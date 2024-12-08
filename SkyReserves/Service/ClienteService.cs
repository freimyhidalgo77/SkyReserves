using Microsoft.EntityFrameworkCore;
using SkyReserves.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class ClienteService(IDbContextFactory<Context> DbFactory)
    {
        private async Task<bool> Existe(int clienteId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Cliente2.AnyAsync(e => e.ClienteId == clienteId);
        }

        private async Task<bool> Insertar(Cliente2 cliente)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Cliente2.Add(cliente);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Cliente2 cliente)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Cliente2.Update(cliente);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Cliente2 cliente)
        {
            if (!await Existe(cliente.ClienteId))
                return await Insertar(cliente);
            else
                return await Modificar(cliente);
        }

        public async Task<bool> Eliminar(int clienteId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Cliente2
                .Where(e => e.ClienteId == clienteId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Cliente2> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Cliente2
                .FirstOrDefaultAsync(e => e.ClienteId == id);
        }

        public async Task<List<Cliente2>> Listar(Expression<Func<Cliente2, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Cliente2
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }
}
