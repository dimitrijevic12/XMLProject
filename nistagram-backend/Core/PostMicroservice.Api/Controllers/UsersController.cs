using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostMicroservice.Api.Factories;
using PostMicroservice.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService userService;
        private readonly RegisteredUserFactory registeredUserFactory;

        public UsersController(UserService userService, RegisteredUserFactory registeredUserFactory)
        {
            this.userService = userService;
            this.registeredUserFactory = registeredUserFactory;
        }

        [HttpGet("taggable")]
        public IActionResult GetTaggable()
        {
            return Ok(userService.GetTaggable().ToList().
                Select(user => registeredUserFactory.Create(user)));
        }
    }
}