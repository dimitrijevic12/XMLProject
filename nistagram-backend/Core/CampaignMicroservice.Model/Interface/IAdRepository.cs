using CampaignMicroservice.Core.Model;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignMicroservice.Core.Interface
{
    public interface IAdRepository
    {
        public void Save(Ad ad, Guid campaignId);

        public Maybe<Ad> GetById(Guid id);

        public IEnumerable<Ad> GetAdsForCampaign(Guid campaignId);
    }
}