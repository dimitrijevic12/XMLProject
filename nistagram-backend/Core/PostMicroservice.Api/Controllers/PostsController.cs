using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PostMicroservice.Api.Factories;
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
        private readonly IPostService _postService;
        private readonly UserService userService;
        private readonly LocationService locationService;
        private readonly PostSingleFactory postSingleFactory;
        private readonly IWebHostEnvironment _env;

        public PostsController(IPostService postService, PostSingleFactory postSingleFactory,
            IWebHostEnvironment env, UserService userService, LocationService locationService)
        {
            _postService = postService;
            this.postSingleFactory = postSingleFactory;
            _env = env;
            this.userService = userService;
            this.locationService = locationService;
        }

        [HttpGet("users/{id}")]
        public IActionResult GetByUserId(Guid id)
        {
            return Ok(_postService.GetByUserId(id).ToList().
                Select(post => postSingleFactory.Create((PostSingle)post)));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            Post post = _postService.GetById(id);
            return Ok(postSingleFactory.Create((PostSingle)_postService.GetById(id)));
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