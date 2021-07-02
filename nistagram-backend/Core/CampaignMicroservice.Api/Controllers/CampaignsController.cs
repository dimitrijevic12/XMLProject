using CampaignMicroservice.Api.DTOs;
using CampaignMicroservice.Api.Factories;
using CampaignMicroservice.Core.Interface;
using CampaignMicroservice.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ad = CampaignMicroservice.Api.DTOs.Ad;
using Campaign = CampaignMicroservice.Api.DTOs.Campaign;
using ExposureDate = CampaignMicroservice.Api.DTOs.ExposureDate;
using RegisteredUser = CampaignMicroservice.Core.Model.RegisteredUser;

namespace CampaignMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : Controller
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly ExposureDateFactory _exposureDateFactory;
        private readonly AdFactory _adFactory;
        private readonly TargetAudienceFactory _targetAudienceFactory;
        private readonly IUserRepository _userRepository;
        private readonly CampaignFactory _campaignFactory;

        public CampaignsController(ICampaignRepository campaignRepository, ExposureDateFactory exposureDateFactory, AdFactory adFactory,
            TargetAudienceFactory targetAudienceFactory, IUserRepository userRepository, CampaignFactory campaignFactory)
        {
            _campaignRepository = campaignRepository;
            _exposureDateFactory = exposureDateFactory;
            _adFactory = adFactory;
            _targetAudienceFactory = targetAudienceFactory;
            _userRepository = userRepository;
            _campaignFactory = campaignFactory;
        }

        [HttpPost]
        public IActionResult Save(Campaign campaign)
        {
            Agent agent = (Agent)_userRepository.GetById(campaign.AgentId).Value;
            List<CampaignMicroservice.Core.Model.ExposureDate> exposureDates = new List<CampaignMicroservice.Core.Model.ExposureDate>();
            foreach (ExposureDate exposureDate in campaign.ExposureDates)
            {
                List<RegisteredUser> seenBy = new List<RegisteredUser>();
                foreach (Guid registeredUserId in exposureDate.SeenByIds)
                    seenBy.Add(_userRepository.GetById(registeredUserId).Value);
                exposureDates.Add(_exposureDateFactory.Create(exposureDate, seenBy));
            }
            List<CampaignMicroservice.Core.Model.Ad> ads = new List<CampaignMicroservice.Core.Model.Ad>();
            foreach (Ad ad in campaign.Ads)
            {
                RegisteredUser profileOwner = _userRepository.GetById(ad.ProfileOwnerId).Value;
                ads.Add(_adFactory.Create(ad, profileOwner));
            }
            _campaignRepository.Save(RecurringPostCampaign.Create(Guid.NewGuid(), _targetAudienceFactory.Create(campaign.TargetAudience),
                agent,
                CampaignStatistics.Create(LikesCount.Create(0).Value,
                DislikesCount.Create(0).Value, ExposureCount.Create(0).Value, ClickCount.Create(0).Value).Value, campaign.StartDate, campaign.EndDate,
                exposureDates, campaign.DateOfChange, ads
                ).Value);
            return Ok();
        }

        [HttpGet]
        public IActionResult Search([FromQuery] Guid agentId)
        {
            if (Request.Query.Count == 0) return BadRequest();
            if (String.IsNullOrEmpty(agentId.ToString())) return BadRequest();
            return Ok(_campaignFactory.CreateCampaigns(_campaignRepository.GetBy(agentId)));
        }
    }
}