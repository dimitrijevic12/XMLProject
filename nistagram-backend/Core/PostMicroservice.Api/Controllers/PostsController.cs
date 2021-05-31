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
        private readonly PostSingleFactory postSingleFactory;

        public PostsController(PostService postService, IPostRepository postRepository, PostSingleFactory postSingleFactory)
        {
            _postService = postService;
            _postRepository = postRepository;
            this.postSingleFactory = postSingleFactory;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(postSingleFactory.Create((PostSingle)_postRepository.GetById(id)));
        }

        [HttpGet]
        public IActionResult Search([FromQuery] Guid userId, [FromQuery] string hashTag)
        {
            if (Request.Query.Count == 0) return BadRequest();
            if (userId == Guid.Empty && String.IsNullOrWhiteSpace(hashTag)) return BadRequest();
            return Ok(_postRepository.GetBy(userId, hashTag).Select(post => postSingleFactory.Create((PostSingle)post)));
        }
    }
}