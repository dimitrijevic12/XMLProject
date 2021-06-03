using Microsoft.AspNetCore.Mvc;
using StoryMicroservice.Core.DTOs;
using StoryMicroservice.Core.Interface.Repository;
using StoryMicroservice.DataAccess.Factories;
using System;

namespace StoryMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : Controller
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IUserRepository _userRepository;
        private readonly StoryFactory storyFactory;

        public StoriesController(IStoryRepository storyRepository, StoryFactory storyFactory, IUserRepository userRepository)
        {
            _storyRepository = storyRepository;
            _userRepository = userRepository;
            this.storyFactory = storyFactory;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stories = _storyRepository.GetAll();
            var stories2 = storyFactory.CreateStories(stories);
            return Ok(stories2);
            //return Ok(storyFactory.CreateStories(storyRepository.GetAll()));
        }

        [HttpPost]
        public IActionResult Create(Story story)
        {
            story.Id = Guid.NewGuid().ToString();
            story.TimeStamp = DateTime.Now;
            return Ok(_storyRepository.Save(storyFactory.Create(story, _userRepository.GetUsersByDTO(story.TaggedUsers))));
        }
    }
}