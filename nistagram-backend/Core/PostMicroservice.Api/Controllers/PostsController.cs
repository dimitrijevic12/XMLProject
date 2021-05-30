using Microsoft.AspNetCore.Mvc;
using PostMicroservice.Api.Factories;
using PostMicroservice.Core.Interface.Service;
using PostMicroservice.Core.Model;
using System;
using System.Linq;

namespace PostMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly PostSingleFactory postSingleFactory;

        public PostsController(IPostService postService, PostSingleFactory postSingleFactory)
        {
            _postService = postService;
            this.postSingleFactory = postSingleFactory;
        }

        [HttpGet("user/{id}")]
        public IActionResult GetByUserId(Guid id)
        {
            return Ok(_postService.GetByUserId(id).ToList().
                Select(post => postSingleFactory.Create((PostSingle)post)));
        }
    }
}