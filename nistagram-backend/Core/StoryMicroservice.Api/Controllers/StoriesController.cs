using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using StoryMicroservice.Core.Interface.Repository;
using StoryMicroservice.Core.Model;
using StoryMicroservice.Core.Services;
using StoryMicroservice.DataAccess.Factories;
using System;
using System.Collections.Generic;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Story = StoryMicroservice.Core.DTOs.Story;

namespace StoryMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : Controller
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly StoryFactory storyFactory;
        private readonly HashTagFactory hashTagFactory;
        private readonly StoryService storyService;

        public StoriesController(IStoryRepository storyRepository, StoryFactory storyFactory, IUserRepository userRepository,
            ILocationRepository locationRepository, HashTagFactory hashTagFactory, StoryService storyService)
        {
            _storyRepository = storyRepository;
            _userRepository = userRepository;
            _locationRepository = locationRepository;
            this.storyFactory = storyFactory;
            this.hashTagFactory = hashTagFactory;
            this.storyService = storyService;
        }

        [HttpGet]
        public IActionResult Search([FromQuery(Name = "story-owner-id")] string storyOwnerId, [FromQuery(Name = "following-id")] string followingId,
            [FromQuery(Name = "last-24h")] string last24h)
        {
            if (Request.Query.Count == 0) return BadRequest();
            return Ok(storyFactory.CreateStories(_storyRepository.GetBy(storyOwnerId, followingId, last24h)));
        }

        [HttpPost]
        public IActionResult Create(Story story)
        {
            story.Id = Guid.NewGuid().ToString();
            story.TimeStamp = DateTime.Now;
            Maybe<Core.Model.RegisteredUser> registeredUser = _userRepository.GetById(new Guid(story.RegisteredUser.Id));
            if (registeredUser.HasNoValue) return BadRequest("Registered user doesn't exist.");
            Maybe<Core.Model.Location> location = _locationRepository.GetById(new Guid(story.Location.Id));
            if (location.HasNoValue) return BadRequest("Location doesn't exist.");
            if (storyService.Create(storyFactory.Create(story, _userRepository.GetUsersByDTO(story.SeenByUsers),
                _userRepository.GetUsersByDTO(story.TaggedUsers))).IsFailure) return BadRequest();
            return Created(this.Request.Path + "/" + story.Id, "");
        }
    }
}