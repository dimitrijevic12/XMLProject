using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PostMicroservice.Api.Factories;
using PostMicroservice.Core.Interface.Repository;
using PostMicroservice.Core.Interface.Service;
using PostMicroservice.Core.Model;
using PostMicroservice.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PostMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostService _postService;
        private readonly IPostRepository _postRepository;
        private readonly UserService userService;
        private readonly LocationService locationService;
        private readonly PostSingleFactory postSingleFactory;
        private readonly IWebHostEnvironment _env;

        public PostsController(PostService postService, IPostRepository postRepository, PostSingleFactory postSingleFactory,
            IWebHostEnvironment env, UserService userService, LocationService locationService)
        {
            _postService = postService;
            _postRepository = postRepository;
            this.postSingleFactory = postSingleFactory;
            _env = env;
            this.userService = userService;
            this.locationService = locationService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(postSingleFactory.Create((PostSingle)_postRepository.GetById(id)));
        }

        [HttpGet]
        public IActionResult Search([FromQuery] Guid userId, [FromQuery] string hashTag, [FromQuery] string country,
            [FromQuery] string city, [FromQuery] string street, [FromQuery] string access)
        {
            if (Request.Query.Count == 0) return BadRequest();
            if (userId == Guid.Empty && String.IsNullOrWhiteSpace(hashTag) && String.IsNullOrEmpty(access)) return BadRequest();
            return Ok(_postRepository.GetBy(userId, hashTag, country, city, street, access)
                .Select(post => postSingleFactory.Create((PostSingle)post)));
        }

        [HttpGet("contents/{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            FileContentResult fileContentResult = File(_postService.GetImage(_env.WebRootPath, fileName), "image/jpeg");
            return Ok(fileContentResult);
        }

        [HttpPost]
        public IActionResult Save(DTOs.PostSingle post)
        {
            Result<DateTime> timeStamp = DateTime.Now;
            Result<Description> description = Description.Create(post.Description);
            Result<ContentPath> contentPath = ContentPath.Create(post.ContentPath);
            Result result = Result.Combine(timeStamp, description, contentPath);
            if (result.IsFailure) return BadRequest();
            RegisteredUser registeredUser = userService.GetById(post.RegisteredUser.Id);
            Location location = locationService.GetById(post.Location.Id);
            Guid id = Guid.NewGuid();
            if (_postService.SaveSinglePost(PostSingle.Create(id, timeStamp.Value, description.Value,
                registeredUser, new List<RegisteredUser>(), new List<RegisteredUser>(),
                new List<Comment>(), location, new List<RegisteredUser>(), new List<HashTag>(),
                contentPath.Value).Value) == null) return BadRequest();
            return Created(this.Request.Path + "/" + id, "");
        }
    }
}