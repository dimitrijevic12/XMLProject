using CSharpFunctionalExtensions;
using System;

namespace PostMicroservice.Core.Model
{
    public class Location
    {
        private readonly Guid id;
        private readonly Street street;
        private readonly CityName cityName;
        private readonly Country country;

        private Location(Guid id, Street street, CityName cityName, Country country)
        {
            this.id = id;
            this.cityName = cityName;
            this.street = street;
            this.country = country;
        }

        public static Result<Location> Create(Guid id, Street street, CityName cityName, Country country)
        {
            return Result.Success(new Location(id, street, cityName, country));
        }
    }
}