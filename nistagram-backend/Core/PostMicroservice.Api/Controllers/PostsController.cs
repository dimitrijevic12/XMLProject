using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostMicroservice.Api.Factories;
using PostMicroservice.Core.Interface.Repository;
using PostMicroservice.Core.Interface.Service;
using PostMicroservice.Core.Model;
using PostMicroservice.Core.Model.File;
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
            FileContentResult fileContentResult = File(_postService.GetImage(_env.WebRootPath, fileName),
                "image/jpeg");
            return Ok(fileContentResult);
        }

        [HttpPost("contents")]
        public IActionResult SaveImg([FromForm] FileModel file)
        {
            string fileName = _postService.ImageToSave(_env.WebRootPath, file);

            return Ok(fileName);
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
            List<HashTag> hashTags = (from DTOs.HashTag hashTag in post.HashTags
                                      select HashTag.Create(HashTagText.Create(hashTag.HashTagText).Value).Value).ToList();
            List<RegisteredUser> taggedUsers = (from DTOs.RegisteredUser registered in post.TaggedUsers
                                                select RegisteredUser.Create(registered.Id, Username.Create(registered.Username).Value,
                                                FirstName.Create(registered.FirstName).Value, LastName.Create(registered.LastName).Value,
                                                ProfileImagePath.Create(registered.ProfileImagePath).Value, false, true,
                                                new List<RegisteredUser>(), new List<RegisteredUser>(), new List<RegisteredUser>(),
                                                new List<RegisteredUser>()).Value).ToList();
            Guid id = Guid.NewGuid();
            if (_postService.SaveSinglePost(PostSingle.Create(id, timeStamp.Value, description.Value,
                registeredUser, new List<RegisteredUser>(), new List<RegisteredUser>(),
                new List<Comment>(), location, taggedUsers, hashTags,
                contentPath.Value).Value) == null) return BadRequest();
            return Created(this.Request.Path + "/" + id, "");
        }

        [HttpPut("{id}/users/{userId}/likes"), ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Like([FromRoute] Guid id, [FromRoute] Guid userId)
        {
            _postService.Like(id, userId);
            return NoContent();
        }

        [HttpPut("{id}/users/{userId}/dislikes"), ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Dislike([FromRoute] Guid id, [FromRoute] Guid userId)
        {
            _postService.Dislike(id, userId);
            return NoContent();
        }

        [HttpPost("{id}/comments"), ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult CommentPost([FromRoute] Guid id, [FromBody] DTOs.Comment comment)
        {
            Result<DateTime> timeStamp = DateTime.Now;
            Result<CommentText> commentText = CommentText.Create(comment.CommentText);
            Result result = Result.Combine(timeStamp, commentText);
            if (result.IsFailure) return BadRequest();
            RegisteredUser registeredUser = userService.GetById(comment.RegisteredUser.Id);
            Guid commentId = Guid.NewGuid();
            _postService.CommentPost(id, Comment.Create(commentId, timeStamp.Value, commentText.Value, registeredUser,
                new List<RegisteredUser>()).Value);
            return NoContent();
        }
    }
}