using StoryMicroservice.Core.Model;
using System;
using Location = StoryMicroservice.Core.DTOs.Location;

namespace StoryMicroservice.DataAccess.Factories
{
    public class LocationFactory
    {
        public Location Create(Core.Model.Location location)
        {
            return new Location
            {
                Id = location.Id.ToString(),
                Country = location.Country,
                CityName = location.CityName,
                Street = location.Street
            };
        }

        public Core.Model.Location Create(Location location)
        {
            return Core.Model.Location.Create(new Guid(location.Id), Street.Create(location.Street).Value, CityName.Create(location.CityName).Value,
                Country.Create(location.Country).Value).Value;
        }
    }
}