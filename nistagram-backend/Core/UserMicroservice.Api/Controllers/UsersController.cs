using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Api.DTOs;
using UserMicroservice.Core.Interface.Service;
using UserMicroservice.Core.Model;
using UserMicroservice.Core.Services;

namespace UserMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService userService;
        //private readonly PostSingleFactory postSingleFactory;

        public UsersController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult RegisterUser(DTOs.RegisteredUser dto)
        {
            Guid id = Guid.NewGuid();
            if (userService.Create(Core.Model.RegisteredUser
                                       .Create(id,
                                          Username.Create(dto.Username).Value,
                                          EmailAddress.Create(dto.EmailAddress).Value,
                                          FirstName.Create(dto.FirstName).Value,
                                          LastName.Create(dto.LastName).Value,
                                          dto.DateOfBirth,
                                          PhoneNumber.Create(dto.PhoneNumber).Value,
                                          Gender.Create(dto.Gender).Value,
                                          WebsiteAddress.Create(dto.WebsiteAddress).Value,
                                          Bio.Create(dto.Bio).Value,
                                          dto.IsPrivate,
                                          dto.IsAcceptingMessages,
                                          dto.IsAcceptingTags,
                                          Password.Create(dto.Password).Value,
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>()).Value).IsFailure) return BadRequest();
            return Created(this.Request.Path + id, "");
        }
    }
}