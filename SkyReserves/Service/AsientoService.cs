using Microsoft.EntityFrameworkCore;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class AsientoService
    {
        private readonly IDbContextFactory<Context> _dbFactory;

        // Constructor
        public AsientoService(IDbContextFactory<Context> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        // Verifica si el asiento existe
        private async Task<bool> Existe(int asientoId)
        {
            await using var context = await _dbFactory.CreateDbContextAsync();
            return await context.Asientos.AnyAsync(e => e.AsientoId == asientoId);
        }

        // Inserta un nuevo asiento
        private async Task<bool> Insertar(Asiento asiento)
        {
            await using var context = await _dbFactory.CreateDbContextAsync();
            context.Asientos.Add(asiento);
            return await context.SaveChangesAsync() > 0;
        }

        // Modifica un asiento existente
        private async Task<bool> Modificar(Asiento asiento)
        {
            await using var context = await _dbFactory.CreateDbContextAsync();
            context.Asientos.Update(asiento);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        // Guarda un asiento: lo inserta si no existe, o lo modifica si ya existe
        public async Task<bool> Guardar(Asiento asiento)
        {
            if (!await Existe(asiento.AsientoId))
                return await Insertar(asiento);
            else
                return await Modificar(asiento);
        }

        // Elimina un asiento
        public async Task<bool> Eliminar(int asientoId)
        {
            await using var context = await _dbFactory.CreateDbContextAsync();
            var asiento = await context.Asientos.FindAsync(asientoId);
            if (asiento != null)
            {
                context.Asientos.Remove(asiento);
                return await context.SaveChangesAsync() > 0;
            }
            return false;
        }

        // Busca un asiento por su ID
        public async Task<Asiento> Buscar(int id)
        {
            await using var context = await _dbFactory.CreateDbContextAsync();
            return await context.Asientos
                .FirstOrDefaultAsync(e => e.AsientoId == id);
        }

        // Lista los asientos con un criterio específico
        public async Task<List<Asiento>> Listar(Expression<Func<Asiento, bool>> criterio)
        {
            await using var context = await _dbFactory.CreateDbContextAsync();
            return await context.Asientos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
