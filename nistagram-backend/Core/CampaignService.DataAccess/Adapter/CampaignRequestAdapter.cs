using CampaignService.DataAccess.Adaptee;
using CampaignService.DataAccess.Target;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignService.DataAccess.Adapter
{
    public class CampaignRequestAdapter : ITarget
    {
        private readonly CampaignRequestAdaptee campaignRequestAdaptee;

        public CampaignRequestAdapter(CampaignRequestAdaptee campaignRequestAdaptee)
        {
            this.campaignRequestAdaptee = campaignRequestAdaptee;
        }

        public object ConvertSql(DataRow dataRow)
        {
            return campaignRequestAdaptee.ConvertSqlDataReaderToCampaignRequest(dataRow);
        }
    }
}