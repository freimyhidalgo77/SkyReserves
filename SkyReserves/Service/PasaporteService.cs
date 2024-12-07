using Microsoft.EntityFrameworkCore;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class PasaporteService
    {
        private readonly IDbContextFactory<Context> DbFactory;

        public PasaporteService(IDbContextFactory<Context> dbFactory)
        {
            DbFactory = dbFactory;
        }

        // Método para verificar si el pasaporte existe
        private async Task<bool> Existe(int pasaporteId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Pasaportes.AnyAsync(e => e.PasaporteId == pasaporteId);
        }

        // Método para insertar un nuevo pasaporte
        private async Task<bool> Insertar(Pasaporte pasaporte)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Pasaportes.Add(pasaporte);
            return await context.SaveChangesAsync() > 0;
        }

        // Método para modificar un pasaporte existente
        private async Task<bool> Modificar(Pasaporte pasaporte)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Pasaportes.Update(pasaporte);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        // Método para guardar un pasaporte
        public async Task<bool> Guardar(Pasaporte pasaporte)
        {
            if (!await Existe(pasaporte.PasaporteId))
                return await Insertar(pasaporte);
            else
                return await Modificar(pasaporte);
        }

        // Método para eliminar un pasaporte
        public async Task<bool> Eliminar(int pasaporteId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Pasaportes
                .Where(e => e.PasaporteId == pasaporteId)
                .ExecuteDeleteAsync() > 0;
        }

        // Método para buscar un pasaporte por ID
        public async Task<Pasaporte> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Pasaportes
                .FirstOrDefaultAsync(e => e.PasaporteId == id);
        }

        // Método para listar pasaportes según un criterio
        public async Task<List<Pasaporte>> Listar(Expression<Func<Pasaporte, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Pasaportes
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        // Método para actualizar un pasaporte
        public async Task<bool> Actualizar(Pasaporte pasaporte)
        {
            await using var context = await DbFactory.CreateDbContextAsync();

            // Actualizamos el pasaporte
            context.Pasaportes.Update(pasaporte);

            // Si hay detalles asociados, los actualizamos
            if (pasaporte.PasaporteDetalle != null && pasaporte.PasaporteDetalle.Any())
            {
                context.PasaporteDetalles.UpdateRange(pasaporte.PasaporteDetalle);
            }

            // Guardamos los cambios en la base de datos
            var resultado = await context.SaveChangesAsync();
            return resultado > 0;
        }

        // Método para obtener un pasaporte por su ID
        public async Task<Pasaporte> ObtenerPorId(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();

            // Obtenemos el pasaporte por su ID, incluyendo los detalles si existen
            return await context.Pasaportes
                .Include(p => p.PasaporteDetalle)  // Incluir los detalles relacionados
                .FirstOrDefaultAsync(p => p.PasaporteId == id);
        }

        // Método para obtener la lista de géneros
        public async Task<List<Generos>> ObtenerGeneros()
        {
            await using var context = await DbFactory.CreateDbContextAsync();

            // Retorna la lista de géneros desde la base de datos
            return await context.Generos
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
