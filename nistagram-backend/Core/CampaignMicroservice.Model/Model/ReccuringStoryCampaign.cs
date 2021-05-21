using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace CampaignMicroservice.Core.Model
{
    public class ReccuringStoryCampaign : Campaign
    {
        private readonly DateTime startDate;
        private readonly DateTime endDate;
        private readonly List<DateTime> exposureDates;
        private readonly DateTime dateOfChange;

        private ReccuringStoryCampaign(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics, DateTime startDate, DateTime endDate,
            List<DateTime> exposureDates, DateTime dateOfChange)
            : base(id, targetAudience, agent, campaignStatistics)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.exposureDates = exposureDates;
            this.dateOfChange = dateOfChange;
        }

        public static Result<ReccuringStoryCampaign> Create(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics, DateTime startDate, DateTime endDate,
            List<DateTime> exposureDates, DateTime dateOfChange)
        {
            return Result.Success(new ReccuringStoryCampaign(id, targetAudience, agent, campaignStatistics,
                startDate, endDate, exposureDates, dateOfChange));
        }
    }
}