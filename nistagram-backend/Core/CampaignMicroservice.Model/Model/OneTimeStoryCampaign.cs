using CSharpFunctionalExtensions;
using System;

namespace CampaignMicroservice.Core.Model
{
    public class OneTimeStoryCampaign : Campaign
    {
        private readonly ExposureDate exposureDate;

        private OneTimeStoryCampaign(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics, ExposureDate exposureDate)
            : base(id, targetAudience, agent, campaignStatistics)
        {
            this.exposureDate = exposureDate;
        }

        public static Result<OneTimeStoryCampaign> Create(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics, ExposureDate exposureDate)
        {
            return Result.Success(new OneTimeStoryCampaign(id, targetAudience, agent,
            campaignStatistics, exposureDate));
        }
    }
}