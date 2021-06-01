using PostMicroservice.Api.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace PostMicroservice.Api.Factories
{
    public class LocationFactory
    {
        public Location Create(Core.Model.Location location)
        {
            return new Location
            {
                Id = location.Id,
                Street = location.Street,
                CityName = location.CityName,
                Country = location.Country
            };
        }

        public IEnumerable<Location> CreateLocations(IEnumerable<Core.Model.Location> locations)
        {
            return locations.Select(location => Create(location)).ToList();
        }
    }
}