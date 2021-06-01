using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostMicroservice.Api.Factories;
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