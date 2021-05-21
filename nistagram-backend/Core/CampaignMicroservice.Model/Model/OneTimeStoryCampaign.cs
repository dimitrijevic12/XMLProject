using CSharpFunctionalExtensions;
using System;

namespace CampaignMicroservice.Core.Model
{
    public class OneTimeStoryCampaign : Campaign
    {
        private readonly DateTime exposureDate;

        private OneTimeStoryCampaign(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics, DateTime exposureDate)
            : base(id, targetAudience, agent, campaignStatistics)
        {
            this.exposureDate = exposureDate;
        }

        public static Result<OneTimeStoryCampaign> Create(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics, DateTime exposureDate)
        {
            return Result.Success(new OneTimeStoryCampaign(id, targetAudience, agent,
            campaignStatistics, exposureDate));
        }
    }
}