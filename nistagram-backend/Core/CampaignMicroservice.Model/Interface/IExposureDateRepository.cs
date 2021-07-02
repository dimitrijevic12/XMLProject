using CampaignMicroservice.Core.Model;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace CampaignMicroservice.Core.Interface
{
    public interface IExposureDateRepository
    {
        public void Save(ExposureDate exposureDate);

        public Maybe<ExposureDate> GetById(Guid id);

        public IEnumerable<ExposureDate> GetExposureDatesForCampaign(Guid campaignId);
    }
}