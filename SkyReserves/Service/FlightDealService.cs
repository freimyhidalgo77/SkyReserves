using Microsoft.EntityFrameworkCore;
using SkyReserves.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class FlightDealService
{
    private readonly Context _context;

    // Constructor para inyectar el contexto de la base de datos
    public FlightDealService(Context context)
    {
        _context = context;
    }

    // Método para obtener todas las ofertas de vuelo desde la base de datos
    public async Task<List<FlightDeal>> GetAllFlightDeals()
    {
        // Aquí asumo que tienes una entidad "FlightDeal" en tu base de datos
        return await _context.FlightDeals.ToListAsync();
    }

    // Método para obtener ofertas de vuelo filtradas por algún criterio (ejemplo: descripción)
    public async Task<List<FlightDeal>> GetFilteredFlightDeals(string filter)
    {
        return await _context.FlightDeals
            .Where(f => f.Description.Contains(filter))  // Ejemplo de filtro por descripción
            .ToListAsync();
    }
}
