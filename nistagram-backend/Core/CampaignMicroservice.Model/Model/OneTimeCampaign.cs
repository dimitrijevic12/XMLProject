using CSharpFunctionalExtensions;
using System;

namespace CampaignMicroservice.Core.Model
{
    public class OneTimeCampaign : Campaign
    {
        private readonly DateTime exposureDate;

        private OneTimeCampaign(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics, DateTime exposureDate)
            : base(id, targetAudience, agent, campaignStatistics)
        {
            this.exposureDate = exposureDate;
        }

        public static Result<OneTimeCampaign> Create(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics, DateTime exposureDate)
        {
            return Result.Success(new OneTimeCampaign(id, targetAudience, agent,
            campaignStatistics, exposureDate));
        }
    }
}