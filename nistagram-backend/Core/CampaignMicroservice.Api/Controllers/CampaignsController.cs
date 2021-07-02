using CampaignMicroservice.Api.DTOs;
using CampaignMicroservice.Api.Factories;
using CampaignMicroservice.Core.Interface;
using CampaignMicroservice.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public CampaignsController(ICampaignRepository campaignRepository, ExposureDateFactory exposureDateFactory, AdFactory adFactory,
            TargetAudienceFactory targetAudienceFactory)
        {
            _campaignRepository = campaignRepository;
            _exposureDateFactory = exposureDateFactory;
            _adFactory = adFactory;
            _targetAudienceFactory = targetAudienceFactory;
        }

        [HttpPost]
        public IActionResult Save(Campaign campaign)
        {
            //Agent agent = _userRepository.GetById(campaign.AgentId);
            List<CampaignMicroservice.Core.Model.ExposureDate> exposureDates = new List<CampaignMicroservice.Core.Model.ExposureDate>();
            /*foreach (ExposureDate exposureDate in campaign.ExposureDates)
            {
                List<RegisteredUser> seenBy = new List<RegisteredUser>();
                foreach (Guid registeredUserId in exposureDate.SeenByIds)
                    seenBy.Add(_userRepository.GetById(registeredUserId));
                exposureDates.Add(_exposureDateFactory.Create(exposureDate, seenBy));
            }*/
            //RegisteredUser adOwner = _userRepository.GetById(campaign.ad);
            List<CampaignMicroservice.Core.Model.Ad> ads = new List<CampaignMicroservice.Core.Model.Ad>();
            /*foreach (Ad ad in campaign.Ads)
            {
                List<RegisteredUser> profileOwner = _userRepository.GetById(ad.ProfileOwnerId);
                ads.Add(_adFactory.Create(ad, profileOwner));
            }*/
            _campaignRepository.Save(RecurringPostCampaign.Create(Guid.NewGuid(), _targetAudienceFactory.Create(campaign.TargetAudience),
                Agent.Create(new Guid("FB42F1A1-04D1-4BD1-9642-F60375BB8F59"), Username.Create("test").Value,
                FirstName.Create("test").Value,
                LastName.Create("test").Value, new DateTime(), Gender.Create("male").Value,
                ProfileImagePath.Create("asd").Value, false, new List<RegisteredUser>(), new List<RegisteredUser>(), new List<RegisteredUser>(),
                new List<RegisteredUser>(), new List<RegisteredUser>(), new List<RegisteredUser>(), false,
                WebsiteAddress.Create("https://github.com/Aleksa1998/XMLProject/blob/main/Documents/campaignmicroserviceERDiagram.jpg").Value).Value,
                CampaignStatistics.Create(LikesCount.Create(0).Value,
                DislikesCount.Create(0).Value, ExposureCount.Create(0).Value, ClickCount.Create(0).Value).Value, campaign.StartDate, campaign.EndDate,
                exposureDates, campaign.DateOfChange, ads
                ).Value);
            return Ok();
        }
    }
}