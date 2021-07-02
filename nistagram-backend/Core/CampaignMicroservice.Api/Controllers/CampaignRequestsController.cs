using CampaignMicroservice.Core.Interface;
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

        public CampaignRequestsController(ICampaignRequestRepository campaignRequestRepository)
        {
            _campaignRequestRepository = campaignRequestRepository;
        }
    }
}