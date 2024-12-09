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

       
        private async Task<bool> Existe(int pasaporteId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Pasaportes.AnyAsync(e => e.PasaporteId == pasaporteId);
        }

        
        private async Task<bool> Insertar(Pasaporte pasaporte)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Pasaportes.Add(pasaporte);
            return await context.SaveChangesAsync() > 0;
        }

       
        private async Task<bool> Modificar(Pasaporte pasaporte)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Pasaportes.Update(pasaporte);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

       
        public async Task<bool> Guardar(Pasaporte pasaporte)
        {
            if (!await Existe(pasaporte.PasaporteId))
                return await Insertar(pasaporte);
            else
                return await Modificar(pasaporte);
        }

       
        public async Task<bool> Eliminar(int pasaporteId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Pasaportes
                .Where(e => e.PasaporteId == pasaporteId)
                .ExecuteDeleteAsync() > 0;
        }

        
        public async Task<Pasaporte> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Pasaportes
                .FirstOrDefaultAsync(e => e.PasaporteId == id);
        }

      
        public async Task<List<Pasaporte>> Listar(Expression<Func<Pasaporte, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Pasaportes
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

 
        public async Task<bool> Actualizar(Pasaporte pasaporte)
        {
            await using var context = await DbFactory.CreateDbContextAsync();

           
            context.Pasaportes.Update(pasaporte);

         
            if (pasaporte.PasaporteDetalle != null && pasaporte.PasaporteDetalle.Any())
            {
                context.PasaporteDetalles.UpdateRange(pasaporte.PasaporteDetalle);
            }

           
            var resultado = await context.SaveChangesAsync();
            return resultado > 0;
        }

      
        public async Task<Pasaporte> ObtenerPorId(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();

        
            return await context.Pasaportes
                .Include(p => p.PasaporteDetalle)  
                .FirstOrDefaultAsync(p => p.PasaporteId == id);
        }

       
        public async Task<List<Generos>> ObtenerGeneros()
        {
            await using var context = await DbFactory.CreateDbContextAsync();

          
            return await context.Generos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Accesibilidad>> ObtenerAccesibilidades()


        { await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Accesibilidad.
               ToListAsync();
        }

    }
}
