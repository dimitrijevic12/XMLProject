using CSharpFunctionalExtensions;
using System;

namespace CampaignMicroservice.Core.Model
{
    public class OneTimePostCampaign : Campaign
    {
        private readonly DateTime exposureDate;

        private OneTimePostCampaign(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics, DateTime exposureDate)
            : base(id, targetAudience, agent, campaignStatistics)
        {
            this.exposureDate = exposureDate;
        }

        public static Result<OneTimePostCampaign> Create(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics, DateTime exposureDate)
        {
            return Result.Success(new OneTimePostCampaign(id, targetAudience, agent,
            campaignStatistics, exposureDate));
        }
    }
}