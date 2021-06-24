using CampaignMicroservice.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignMicroservice.Core.Interface
{
    public interface ICampaignRepository
    {
        public void Save(Campaign campaign);

        public void Update(Campaign campaign);

        public void Remove(Guid id);
    }
}