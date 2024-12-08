using Microsoft.EntityFrameworkCore;
using SkyReserves.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class VueloService(IDbContextFactory<Context> DbFactory)
    {
      

        private async Task<bool> Existe(int vueloId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Vuelo2.AnyAsync(e => e.VueloID == vueloId);
        }

        private async Task<bool> ExisteDestino(int destinoId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Destino2.AnyAsync(d => d.DestinoId == destinoId);
        }

        private async Task<bool> Insertar(Vuelo2 vuelo)
        {

            await using var context = await DbFactory.CreateDbContextAsync();
            context.Vuelo2.Add(vuelo);
            return await context.SaveChangesAsync() > 0;


            // Verificar si el DestinoId existe en la base de datos antes de insertar
            /* if (!await ExisteDestino(vuelo.DestinoId))
             {
                 throw new Exception("El DestinoId no existe en la tabla Destino2.");
             }

             await using var context = await DbFactory.CreateDbContextAsync();
             context.Vuelo2.Add(vuelo);
             return await context.SaveChangesAsync() > 0;*/
        }

        private async Task<bool> Modificar(Vuelo2 vuelo)
        {
            // Verificar si el DestinoId existe en la base de datos antes de modificar
            if (!await ExisteDestino(vuelo.DestinoId))
            {
                throw new Exception("El DestinoId no existe en la tabla Destino2.");
            }

            await using var context = await DbFactory.CreateDbContextAsync();
            context.Vuelo2.Update(vuelo);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(Vuelo2 vuelo)
        {
            if (!await Existe(vuelo.VueloID))
                return await Insertar(vuelo);
            else
                return await Modificar(vuelo);
        }

        public async Task<bool> Eliminar(int vueloId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Vuelo2
                .Where(e => e.VueloID == vueloId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Vuelo2?> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Vuelo2
                .FirstOrDefaultAsync(e => e.VueloID == id);
                
        }

        public async Task<Vuelo2?> BuscarVuelo(int origenId, int destinoId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Vuelo2
                .FirstOrDefaultAsync(v => v.OrigenId == origenId && v.DestinoId == destinoId);
        }


        public async Task<List<Vuelo2>> Listar(Expression<Func<Vuelo2, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Vuelo2
                 .Include(v => v.Origen) // Incluye la entidad relacionada Origen
                .Include(v => v.Destino) // Incluye la entidad relacionada Destino
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
