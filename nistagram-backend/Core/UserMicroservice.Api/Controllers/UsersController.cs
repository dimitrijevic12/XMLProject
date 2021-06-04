using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Api.DTOs;
using UserMicroservice.Api.Factories;
using UserMicroservice.Core.Interface.Repository;
using UserMicroservice.Core.Interface.Service;
using UserMicroservice.Core.Model;
using UserMicroservice.Core.Services;
using UserMicroservice.DataAccess.Implementation;

namespace UserMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService userService;
        private readonly RegisterUserFactory registerUserFactory;
        private readonly IUserRepository _userRepository;

        public UsersController(UserService userService, IUserRepository userRepository, RegisterUserFactory registerUserFactory)
        {
            this.userService = userService;
            _userRepository = userRepository;
            this.registerUserFactory = registerUserFactory;
        }

        //[Authorize(Roles = "ApprovedAgent")]
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
            dto.Id = id;
            return Ok(/*this.Request.Path + id, ""*/ dto);
        }

        [HttpPost("login")]
        public IActionResult Login(UserModel login)
        {
            IActionResult response = Unauthorized();
            var user = userService.FindUser(login.Username, login.Password);
            if (user != null)
            {
                var tokenString = userService.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        [HttpGet("{idUser}")]
        public IActionResult GetById(Guid idUser)
        {
            Core.Model.RegisteredUser user = userService.GetUserById(idUser);
            if (user == null) return BadRequest();
            return Ok(registerUserFactory.Create(user));
        }

        [HttpPut("edit")]
        public IActionResult Edit(DTOs.RegisteredUser dto)
        {
            Result<Username> username = Username.Create(dto.Username);
            Result<EmailAddress> emailAddress = EmailAddress.Create(dto.EmailAddress);
            Result<FirstName> firstName = FirstName.Create(dto.FirstName);
            Result<LastName> lastName = LastName.Create(dto.LastName);
            Result<PhoneNumber> phoneNumber = PhoneNumber.Create(dto.PhoneNumber);
            Result<Gender> gender = Gender.Create(dto.Gender);
            Result<WebsiteAddress> websiteAddress = WebsiteAddress.Create(dto.WebsiteAddress);
            Result<Bio> bio = Bio.Create(dto.Bio);
            Result<Password> password = Password.Create("password");

            Result result = Result.Combine(username, emailAddress, firstName, lastName, phoneNumber, gender, websiteAddress, bio, password);
            if (result.IsFailure) return BadRequest(result.Error);

            return Ok(userService.Edit((Core.Model.RegisteredUser.Create(dto.Id,
                                          username.Value,
                                          emailAddress.Value,
                                          firstName.Value,
                                          lastName.Value,
                                          dto.DateOfBirth,
                                          phoneNumber.Value,
                                          gender.Value,
                                          websiteAddress.Value,
                                          bio.Value,
                                          true,
                                          true,
                                          true,
                                          password.Value,
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>()).Value)));
        }

        [HttpGet]
        public IActionResult Search([FromQuery] Guid id, [FromQuery] string name, [FromQuery] string access)
        {
            if (Request.Query.Count == 0) return BadRequest();
            if (id == Guid.Empty && String.IsNullOrWhiteSpace(name) && String.IsNullOrEmpty(access)) return BadRequest();
            return Ok(_userRepository.GetBy(name, access)
                .Select(user => registerUserFactory.Create(user)));
        }

        [HttpPost("follow")]
        public IActionResult Follow(Follow follow)
        {
            Guid id = Guid.NewGuid();
            if (userService.Follow(id, follow.FollowedById, follow.FollowingId).IsFailure) return BadRequest();
            return Created(this.Request.Path + id, "");
        }

        [HttpPost("followprivate")]
        public IActionResult FollowPrivate(Follow follow)
        {
            Guid id = Guid.NewGuid();
            _userRepository.Follow(id, follow.FollowedById, follow.FollowingId);
            return Created(this.Request.Path + id, "");
        }

        [HttpPut("handlerequest")]
        public IActionResult HandleFollowRequest(Follow follow)
        {
            Guid newId = Guid.NewGuid();
            userService.HandleFollowRequest(follow.Id, follow.FollowedById, follow.FollowingId, follow.Type, follow.IsApproved, newId);
            return Ok();
        }
    }
}