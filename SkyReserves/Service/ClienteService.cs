﻿using Microsoft.EntityFrameworkCore;
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
            return await context.Clientes.AnyAsync(e => e.ClienteId == clienteId);
        }

        private async Task<bool> Insertar(Cliente cliente)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Clientes.Add(cliente);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Cliente cliente)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Clientes.Update(cliente);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Cliente cliente)
        {
            if (!await Existe(cliente.ClienteId))
                return await Insertar(cliente);
            else
                return await Modificar(cliente);
        }

        public async Task<bool> Eliminar(int clienteId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Clientes
                .Where(e => e.ClienteId == clienteId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Cliente> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Clientes
                .FirstOrDefaultAsync(e => e.ClienteId == id);
        }

        public async Task<List<Cliente>> Listar(Expression<Func<Cliente, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Clientes
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }
}
