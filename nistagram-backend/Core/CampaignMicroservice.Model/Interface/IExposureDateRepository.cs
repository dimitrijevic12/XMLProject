using CampaignMicroservice.Core.Model;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignMicroservice.Core.Interface
{
    public interface IExposureDateRepository
    {
        public void Save(ExposureDate exposureDate);

        public Maybe<ExposureDate> GetById(Guid id);
    }
}