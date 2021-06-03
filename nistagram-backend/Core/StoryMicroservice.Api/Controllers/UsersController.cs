using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using StoryMicroservice.Core.Model;
using StoryMicroservice.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService userService;

        public UsersController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult RegisterUser(DTOs.RegisteredUser dto)
        {
            Guid id = dto.Id;

            Result<Username> username = Username.Create(dto.Username);
            Result<FirstName> firstName = FirstName.Create(dto.FirstName);
            Result<LastName> lastName = LastName.Create(dto.LastName);
            Result result = Result.Combine(username, firstName, lastName);
            if (result.IsFailure) return BadRequest();

            if (userService.Create(Core.Model.RegisteredUser
                                       .Create(dto.Id,
                                          username.Value,
                                          firstName.Value,
                                          lastName.Value,
                                          dto.isPrivate,
                                          dto.isAcceptingTags).Value).IsFailure) return BadRequest();
            return Created(this.Request.Path + id, "");
        }

        [HttpPut("edit")]
        public IActionResult Edit(DTOs.RegisteredUser dto)
        {
            Result<Username> username = Username.Create(dto.Username);
            Result<FirstName> firstName = FirstName.Create(dto.FirstName);
            Result<LastName> lastName = LastName.Create(dto.LastName);

            Result result = Result.Combine(username, firstName, lastName);
            if (result.IsFailure) return BadRequest(result.Error);

            return Ok(userService.Edit((Core.Model.RegisteredUser.Create(dto.Id,
                                          username.Value,
                                          firstName.Value,
                                          lastName.Value,
                                          true,
                                          true).Value)));
        }
    }
}