using PostMicroservice.Api.DTOs;

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
    }
}