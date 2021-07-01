using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace CampaignMicroservice.Core.Model
{
    public class OneTimeStoryCampaign : Campaign
    {
        private readonly ExposureDate exposureDate;

        private OneTimeStoryCampaign(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics, ExposureDate exposureDate, IEnumerable<Ad> ads)
            : base(id, targetAudience, agent, campaignStatistics, ads)
        {
            this.exposureDate = exposureDate;
        }

        public static Result<OneTimeStoryCampaign> Create(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics, ExposureDate exposureDate, IEnumerable<Ad> ads)
        {
            return Result.Success(new OneTimeStoryCampaign(id, targetAudience, agent,
            campaignStatistics, exposureDate, ads));
        }
    }
}