using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using StoryMicroservice.Core.DTOs;
using StoryMicroservice.Core.Interface.Repository;
using StoryMicroservice.Core.Model;
using StoryMicroservice.Core.Services;
using StoryMicroservice.DataAccess.Factories;
using StoryMicroservice.DataAccess.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegisteredUser = StoryMicroservice.Core.DTOs.RegisteredUser;

namespace StoryMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly RegisteredUserFactory userFactory;
        private readonly UserService userService;
        private readonly IUserRepository _userRepository;

        public UsersController(UserService userService, RegisteredUserFactory userFactory, IUserRepository userRepository)
        {
            this.userService = userService;
            this.userFactory = userFactory;
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult RegisterUser(RegisteredUser dto)
        {
            Result<Username> username = Username.Create(dto.Username);
            Result<FirstName> firstName = FirstName.Create(dto.FirstName);
            Result<LastName> lastName = LastName.Create(dto.LastName);
            Result result = Result.Combine(username, firstName, lastName);
            if (result.IsFailure) return BadRequest();

            if (userService.Create(userFactory.Create(dto, _userRepository.GetUsersById(dto.BlockedByUsers),
                _userRepository.GetUsersById(dto.BlockedByUsers), _userRepository.GetUsersById(dto.Followers),
                _userRepository.GetUsersById(dto.Following), _userRepository.GetUsersById(dto.CloseFriendTo)
                , _userRepository.GetUsersById(dto.MyCloseFriends))).IsFailure)
                return BadRequest();
            return Created(this.Request.Path + "/" + dto.Id, "");
        }
    }
}