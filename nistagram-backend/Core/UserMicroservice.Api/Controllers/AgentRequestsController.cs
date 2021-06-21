using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using System;
using UserMicroservice.Api.Factories;
using UserMicroservice.Core.Interface.Repository;
using UserMicroservice.Core.Model;

namespace UserMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentRequestsController : ControllerBase
    {
        private readonly AgentRequestFactory agentRequestFactory;
        private readonly IAgentRequestRepository _agentRequestRepository;
        private readonly IUserRepository _userRepository;

        public AgentRequestsController(AgentRequestFactory agentRequestFactory,
            IAgentRequestRepository agentRequestRepository, IUserRepository userRepository)
        {
            this.agentRequestFactory = agentRequestFactory;
            _agentRequestRepository = agentRequestRepository;
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Create(DTOs.AgentRequest agentRequest)
        {
            Guid id = Guid.NewGuid();
            Maybe<RegisteredUser> user = _userRepository.GetById(agentRequest.RegisteredUser.Id);
            if (user.HasNoValue) return BadRequest("Registered user doesn't exist.");

            if (_agentRequestRepository.Save(AgentRequest.Create(id, agentRequest.IsApproved, user.Value).Value) == null)
                return BadRequest("Couldn't create agent request");

            return Created(this.Request.Path + id, "");
        }

        [HttpGet]
        public IActionResult Search([FromQuery(Name = "is-approved")] string isApproved)
        {
            if (Request.Query.Count == 0) return BadRequest();
            if (String.IsNullOrEmpty(isApproved)) return BadRequest();
            return Ok(agentRequestFactory.CreateAgentRequests(_agentRequestRepository.GetBy(isApproved)));
        }
    }
}