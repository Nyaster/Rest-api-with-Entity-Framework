using Rest_Api_DBfirst.Models;
using Rest_Api_DBfirst.Repositories;

namespace Rest_Api_DBfirst.Services;

public class TripService
{
    private TripRepository _repository;

    public TripService(TripRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaginationDTO> GetTrips(int pageSize = 10, int page = 1)
    {
        if (pageSize <= 0)
        {
            pageSize = 10;
        }

        if (page <= 0)
        {
            page = 1;
        }

        var pagination = new DBPagination() { PageSize = pageSize, PageNum = page };
        var collection = await _repository.GetTrips(pagination);
        var paginationDto = new PaginationDTO()
        {
            AllPages = collection.AllPages,
            PageNum = collection.PageNum,
            PageSize = collection.PageSize,
            Trip = collection.trip.Select(x =>
            {
                return new TripDTO()
                {
                    Name = x.Name,
                    Description = x.Description,
                    DateFrom = x.DateFrom,
                    DateTo = x.DateTo,
                    MaxPeople = x.MaxPeople,
                    ClientTrips = x.ClientTrips.Select(x => new ClientDTO()
                            { FirstName = x.IdClientNavigation.FirstName, LastName = x.IdClientNavigation.LastName })
                        .ToList(),
                    IdCountries = x.IdCountries.Select(x => new CountryDTO() { Name = x.Name }).ToList()
                };
            }).ToList()
        };
        return paginationDto;
    }
}