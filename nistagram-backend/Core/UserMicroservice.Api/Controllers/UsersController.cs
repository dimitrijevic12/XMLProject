using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "default")]
        [HttpPost]
        public IActionResult RegisterUser(DTOs.RegisteredUser dto)
        {
            Guid id = Guid.NewGuid();

            Result<Username> username = Username.Create(dto.Username);
            Result<EmailAddress> emailAddress = EmailAddress.Create(dto.EmailAddress);
            Result<FirstName> firstName = FirstName.Create(dto.FirstName);
            Result<LastName> lastName = LastName.Create(dto.LastName);
            Result<PhoneNumber> phoneNumber = PhoneNumber.Create(dto.PhoneNumber);
            Result<Gender> gender = Gender.Create(dto.Gender);
            Result<WebsiteAddress> websiteAddress = WebsiteAddress.Create(dto.WebsiteAddress);
            Result<Bio> bio = Bio.Create(dto.Bio);
            Result<Password> password = Password.Create(dto.Password);

            Result result = Result.Combine(username, emailAddress, firstName, lastName, phoneNumber, gender, websiteAddress, bio, password);
            if (result.IsFailure) return BadRequest();

            if (userService.Create(Core.Model.RegisteredUser
                                       .Create(id,
                                          username.Value,
                                          emailAddress.Value,
                                          firstName.Value,
                                          lastName.Value,
                                          dto.DateOfBirth,
                                          phoneNumber.Value,
                                          gender.Value,
                                          websiteAddress.Value,
                                          bio.Value,
                                          dto.IsPrivate,
                                          dto.IsAcceptingMessages,
                                          dto.IsAcceptingTags,
                                          password.Value,
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

        [HttpPost("login")]
        public IActionResult Login(Core.Model.UserModel login)
        {
            IActionResult response = Unauthorized();
            var user = userService.FindUser(login);
            if (user != null)
            {
                var tokenString = userService.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }
    }
}