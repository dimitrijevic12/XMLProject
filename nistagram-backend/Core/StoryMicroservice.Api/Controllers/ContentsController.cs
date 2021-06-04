using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StoryMicroservice.Core.Model.FileModel;
using StoryMicroservice.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryMicroservice.Api.Controllers
{
    public class ContentsController : Controller
    {
        private readonly StoryService storyService;
        private readonly IWebHostEnvironment _env;

        public ContentsController(StoryService storyService, IWebHostEnvironment env)
        {
            this.storyService = storyService;
            _env = env;
        }

        [HttpPost]
        public IActionResult SaveImg([FromForm] FileModel file)
        {
            string fileName = storyService.ImageToSave(_env.WebRootPath, file);

            return Ok(fileName);
        }
    }
}