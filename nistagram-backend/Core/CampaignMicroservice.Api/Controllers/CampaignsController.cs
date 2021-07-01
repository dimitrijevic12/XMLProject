using CampaignMicroservice.Core.Interface;
using CampaignMicroservice.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : Controller
    {
        private readonly ICampaignRepository _campaignRepository;

        public CampaignsController(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        [HttpPost]
        public IActionResult Save()
        {
            _campaignRepository.Save(RecurringPostCampaign.Create(Guid.NewGuid(), TargetAudience.Create(new DateTime(), new DateTime(),
                Gender.Create("male").Value).Value, Agent.Create(new Guid("FB42F1A1-04D1-4BD1-9642-F60375BB8F59"), Username.Create("test").Value,
                FirstName.Create("test").Value,
                LastName.Create("test").Value, new DateTime(), Gender.Create("male").Value,
                ProfileImagePath.Create("asd").Value, false, new List<RegisteredUser>(), new List<RegisteredUser>(), new List<RegisteredUser>(),
                new List<RegisteredUser>(), new List<RegisteredUser>(), new List<RegisteredUser>(), false,
                WebsiteAddress.Create("https://github.com/Aleksa1998/XMLProject/blob/main/Documents/campaignmicroserviceERDiagram.jpg").Value).Value,
                CampaignStatistics.Create(LikesCount.Create(2).Value,
                DislikesCount.Create(2).Value, ExposureCount.Create(2).Value, ClickCount.Create(2).Value).Value, DateTime.Now, DateTime.Now,
                new List<ExposureDate>(), DateTime.Now, new List<Ad>()
                ).Value);
            return Ok();
        }
    }
}