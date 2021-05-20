using CSharpFunctionalExtensions;
using System;

namespace PostMicroservice.Core.Model
{
    public class Location
    {
        private readonly Guid id;
        private readonly CityName cityName;
        private readonly Street street;
        private readonly Country country;

        private Location(Guid id, CityName cityName, Street street, Country country)
        {
            this.id = id;
            this.cityName = cityName;
            this.street = street;
            this.country = country;
        }

        public static Result<Location> Create(Guid id, CityName cityName, Street street, Country country)
        {
            return Result.Success(new Location(id, cityName, street, country));
        }
    }
}