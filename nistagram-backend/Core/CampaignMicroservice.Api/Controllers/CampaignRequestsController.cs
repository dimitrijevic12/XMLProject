using CampaignMicroservice.Core.Interface;
using CampaignMicroservice.Core.Model;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignRequestsController : ControllerBase
    {
        private readonly ICampaignRequestRepository _campaignRequestRepository;
        private readonly IUserRepository _userRepository;

        public CampaignRequestsController(ICampaignRequestRepository campaignRequestRepository,
            IUserRepository userRepository)
        {
            _campaignRequestRepository = campaignRequestRepository;
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Create(DTOs.CampaignRequest campaignRequest)
        {
            Guid id = Guid.NewGuid();
            Result<CampaignRequestAction> username = CampaignRequestAction.Create(campaignRequest.CampaignRequestAction);

            Result result = Result.Combine(username);
            if (result.IsFailure) return BadRequest();

            Maybe<RegisteredUser> user = _userRepository.GetById(campaignRequest.VerifiedUser.Id);
            if (user.HasNoValue) return BadRequest("Registered user doesn't exist.");

            /*if (_campaignRequestRepository.Save(CampaignRequest.Create(id, campaignRequest.IsApproved,
                ).Value) == null)
                return BadRequest("Couldn't create agent request");*/

            return Created(this.Request.Path + id, "");
        }
    }
}