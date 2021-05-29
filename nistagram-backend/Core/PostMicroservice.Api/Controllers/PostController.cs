using Microsoft.AspNetCore.Mvc;
using PostMicroservice.Api.Factories;
using PostMicroservice.Core.Interface.Service;
using PostMicroservice.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace PostMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly PostSingleFactory postSingleFactory;

        public PostController(IPostService postService, PostSingleFactory postSingleFactory)
        {
            _postService = postService;
            this.postSingleFactory = postSingleFactory;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Post> posts = _postService.GetAll().ToList();
            return Ok(posts.Select(post => postSingleFactory.Create((PostSingle)post)));
        }
    }
}