using Microsoft.EntityFrameworkCore;
using SkyReserves.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class FlightDealService
{
    private readonly Context _context;
    public FlightDealService(Context context)
    {
        _context = context;
    }

  
    public async Task<List<FlightDeal>> GetAllFlightDeals()
    {
        
        return await _context.FlightDeals.ToListAsync();
    }

    
    public async Task<List<FlightDeal>> GetFilteredFlightDeals(string filter)
    {
        return await _context.FlightDeals
            .Where(f => f.Description.Contains(filter))
            .ToListAsync();
    }
}
