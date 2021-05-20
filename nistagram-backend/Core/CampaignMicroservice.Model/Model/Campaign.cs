using CSharpFunctionalExtensions;
using System;

namespace CampaignMicroservice.Core.Model
{
    public class Campaign
    {
        private readonly Guid id;
        private readonly TargetAudience targetAudience;
        private readonly Agent agent;
        private readonly CampaignStatistics campaignStatistics;

        protected Campaign(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics)
        {
            this.id = id;
            this.targetAudience = targetAudience;
            this.agent = agent;
            this.campaignStatistics = campaignStatistics;
        }

        public static Result<Campaign> Create(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics)
        {
            return Result.Success(new Campaign(id, targetAudience, agent,
            campaignStatistics));
        }
    }
}