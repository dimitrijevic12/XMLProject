using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.Api.Factories;
using NotificationMicroservice.Core.Interface.Repository;
using NotificationMicroservice.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRegisteredUserRepository _registeredUserRepository;
        private readonly RegisteredUserFactory registeredUserFactory;

        public UsersController(IRegisteredUserRepository registeredUserRepository,
            RegisteredUserFactory registeredUserFactory)
        {
            _registeredUserRepository = registeredUserRepository;
            this.registeredUserFactory = registeredUserFactory;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(registeredUserFactory.Create(_registeredUserRepository.GetById(id).Value));
        }

        [HttpPut]
        public IActionResult Edit(DTOs.RegisteredUser registeredUser)
        {
            Result<Username> username = Username.Create(registeredUser.Username);
            Result<ProfilePicturePath> profilePicturePath = ProfilePicturePath.Create(registeredUser.ProfilePicturePath);

            Result result = Result.Combine(username, profilePicturePath);
            if (result.IsFailure) return BadRequest(result.Error);
            return Ok(registeredUserFactory.Create(_registeredUserRepository.Edit(RegisteredUser.Create(registeredUser.Id,
                username.Value, NotificationOptions.Create(registeredUser.NotificationOptions.Id, registeredUser.NotificationOptions.IsNotifiedByFollowRequests,
                registeredUser.NotificationOptions.IsNotifiedByMessages, registeredUser.NotificationOptions.IsNotifiedByPosts,
                registeredUser.NotificationOptions.IsNotifiedByStories, registeredUser.NotificationOptions.IsNotifiedByComments).Value, profilePicturePath.Value).Value)));
        }
    }
}