using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostMicroservice.Api.Factories;
using PostMicroservice.Core.Model;
using PostMicroservice.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly LocationService locationService;
        private readonly LocationFactory locationFactory;

        public LocationsController(LocationService locationService, LocationFactory locationFactory)
        {
            this.locationService = locationService;
            this.locationFactory = locationFactory;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(locationService.GetAll().ToList().
                Select(location => locationFactory.Create(location)));
        }
    }
}