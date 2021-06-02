﻿using CSharpFunctionalExtensions;
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
        private readonly IUserRepository _userRepository;
        private readonly UserSearchResultFactory userSearchResultFactory;
        //private readonly PostSingleFactory postSingleFactory;

        public UsersController(UserService userService, IUserRepository userRepository, UserSearchResultFactory userSearchResultFactory)
        {
            this.userService = userService;
            _userRepository = userRepository;
            this.userSearchResultFactory = userSearchResultFactory;
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

        [HttpGet]
        public IActionResult Search([FromQuery] Guid id, [FromQuery] string name, [FromQuery] string access)
        {
            if (Request.Query.Count == 0) return BadRequest();
            if (id == Guid.Empty && String.IsNullOrWhiteSpace(name) && String.IsNullOrEmpty(access)) return BadRequest();
            return Ok(_userRepository.GetBy(name, access)
                .Select(user => userSearchResultFactory.Create(user)));
        }
    }
}