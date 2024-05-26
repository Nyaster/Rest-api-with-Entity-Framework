﻿namespace Rest_Api_DBfirst.Models;

public class TripDTO
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public int MaxPeople { get; set; }

    public virtual ICollection<ClientDTO> ClientTrips { get; set; } = new List<ClientDTO>();

    public virtual ICollection<CountryDTO> IdCountries { get; set; } = new List<CountryDTO>();
}