﻿using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace CampaignMicroservice.Core.Model
{
    public class RecurringPostCampaign : Campaign
    {
        private readonly DateTime startDate;
        private readonly DateTime endDate;
        private readonly IEnumerable<ExposureDate> exposureDates;
        private readonly DateTime dateOfChange;

        private RecurringPostCampaign(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics, DateTime startDate, DateTime endDate,
            IEnumerable<ExposureDate> exposureDates, DateTime dateOfChange, IEnumerable<Ad> ads)
            : base(id, targetAudience, agent, campaignStatistics, ads)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.exposureDates = exposureDates;
            this.dateOfChange = dateOfChange;
        }

        public static Result<RecurringPostCampaign> Create(Guid id, TargetAudience targetAudience, Agent agent,
            CampaignStatistics campaignStatistics, DateTime startDate, DateTime endDate,
            IEnumerable<ExposureDate> exposureDates, DateTime dateOfChange, IEnumerable<Ad> ads)
        {
            return Result.Success(new RecurringPostCampaign(id, targetAudience, agent, campaignStatistics,
                startDate, endDate, exposureDates, dateOfChange, ads));
        }
    }
}