using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace CampaignMicroservice.Core.Model
{
    public class RecurringStoryCampaign : Campaign
    {
        private readonly DateTime startDate;
        private readonly DateTime endDate;
        private readonly IEnumerable<ExposureDate> exposureDates;
        private readonly DateTime dateOfChange;

        private RecurringStoryCampaign(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics, DateTime startDate, DateTime endDate,
            IEnumerable<ExposureDate> exposureDates, DateTime dateOfChange)
            : base(id, targetAudience, agent, campaignStatistics)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.exposureDates = exposureDates;
            this.dateOfChange = dateOfChange;
        }

        public static Result<RecurringStoryCampaign> Create(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics, DateTime startDate, DateTime endDate,
            IEnumerable<ExposureDate> exposureDates, DateTime dateOfChange)
        {
            return Result.Success(new RecurringStoryCampaign(id, targetAudience, agent, campaignStatistics,
                startDate, endDate, exposureDates, dateOfChange));
        }
    }
}