using Microsoft.AspNetCore.Mvc;
using PostMicroservice.Api.DTOs;
using PostMicroservice.Api.Factories;
using PostMicroservice.Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : Controller
    {
        private readonly ILocationRepository _locationRepository;
        private readonly LocationFactory locationFactory;

        public LocationsController(ILocationRepository locationRepository, LocationFactory locationFactory)
        {
            _locationRepository = locationRepository;
            this.locationFactory = locationFactory;
        }

        [HttpGet]
        public IActionResult GetBy([FromQuery] string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return Ok(_locationRepository.GetAll().ToList().
                Select(location => locationFactory.Create(location)));
            }
            List<Location> locations = new List<Location>();
            IEnumerable<Core.Model.Location> queryResult;
            queryResult = _locationRepository.GetCountryByText(text);
            if (queryResult.Any()) locations.Add(new Location()
            { Country = queryResult.First().Country, CityName = "", Street = "" });
            queryResult = _locationRepository.GetCityByText(text);
            if (queryResult.Any()) locations.Add(new Location()
            { Country = queryResult.First().Country, CityName = queryResult.First().CityName, Street = "" });
            queryResult = _locationRepository.GetStreetByText(text);
            if (queryResult.Any()) locations.Add(new Location()
            { Country = queryResult.First().Country, CityName = queryResult.First().CityName, Street = queryResult.First().Street });
            return Ok(locations);
        }
    }
}