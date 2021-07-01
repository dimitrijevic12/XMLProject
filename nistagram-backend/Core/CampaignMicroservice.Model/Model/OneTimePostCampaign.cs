using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace CampaignMicroservice.Core.Model
{
    public class OneTimePostCampaign : Campaign
    {
        private readonly ExposureDate exposureDate;

        private OneTimePostCampaign(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics, ExposureDate exposureDate, IEnumerable<Ad> ads)
            : base(id, targetAudience, agent, campaignStatistics, ads)
        {
            this.exposureDate = exposureDate;
        }

        public static Result<OneTimePostCampaign> Create(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics, ExposureDate exposureDate, IEnumerable<Ad> ads)
        {
            return Result.Success(new OneTimePostCampaign(id, targetAudience, agent,
            campaignStatistics, exposureDate, ads));
        }
    }
}