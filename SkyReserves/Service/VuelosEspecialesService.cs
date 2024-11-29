using Microsoft.EntityFrameworkCore;
using SkyReserve.DAL;
using SkyReserves.Models;
using System.Linq.Expressions;

namespace SkyReserves.Service
{
    public class VuelosEspecialesService(IDbContextFactory<Context> DbFactory)
    {

        private async Task<bool> Existe(int vuelosEspecialesId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.VuelosEspeciales.AnyAsync(e => e.VuelosEspecialesId == vuelosEspecialesId);
        }

        private async Task<bool> Insertar(VuelosEspeciales vuelosEspeciales)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.VuelosEspeciales.Add(vuelosEspeciales);
            return await context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(VuelosEspeciales veulosEspecialesId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.VuelosEspeciales.Update(veulosEspecialesId);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(VuelosEspeciales vuelosEspecialesId)
        {
            if (!await Existe(vuelosEspecialesId.VuelosEspecialesId))
                return await Insertar(vuelosEspecialesId);
            else
                return await Modificar(vuelosEspecialesId);
        }

        public async Task<bool> Eliminar(int vuelosEspeciales)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.VuelosEspeciales
                .Where(e => e.VuelosEspecialesId == vuelosEspeciales)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<VuelosEspeciales> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.VuelosEspeciales
                .FirstOrDefaultAsync(e => e.VuelosEspecialesId == id);
        }

        public async Task<List<VuelosEspeciales>> Listar(Expression<Func<VuelosEspeciales, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.VuelosEspeciales
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }


    }
}
