using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Rest_Api_DBfirst.Context;
using Rest_Api_DBfirst.Models;

namespace Rest_Api_DBfirst.Repositories;

public class TripRepository
{
    private ApbdContext _context;

    public TripRepository(ApbdContext context)
    {
        _context = context;
    }

    public async Task<DBPagination> GetTrips(DBPagination dbPagination)
    {
        var dbPaginationPageSize = dbPagination.PageSize * (dbPagination.PageNum - 1);
        var trips = await _context.Trips.Skip(dbPaginationPageSize)
            .Take(dbPagination.PageSize)
            .Include(x => x.IdCountries)
            .Include(x => x.ClientTrips)
            .ThenInclude(x => x.IdClientNavigation)
            .ToListAsync();
        dbPagination.trip = trips;
        dbPagination.AllPages = _context.Trips.Count() / dbPagination.PageSize;
        return dbPagination;
    }
}