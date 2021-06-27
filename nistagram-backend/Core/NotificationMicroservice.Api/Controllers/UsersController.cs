using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.Api.Factories;
using NotificationMicroservice.Core.Interface.Repository;
using NotificationMicroservice.Core.Model;
using NotificationMicroservice.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRegisteredUserRepository _registeredUserRepository;
        private readonly RegisteredUserFactory registeredUserFactory;
        private readonly RegisteredUserService registeredUserService;

        public UsersController(IRegisteredUserRepository registeredUserRepository,
            RegisteredUserFactory registeredUserFactory, RegisteredUserService registeredUserService)
        {
            _registeredUserRepository = registeredUserRepository;
            this.registeredUserFactory = registeredUserFactory;
            this.registeredUserService = registeredUserService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(registeredUserFactory.Create(_registeredUserRepository.GetById(id).Value));
        }
    }
}