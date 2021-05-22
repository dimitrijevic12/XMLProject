using CampaignService.DataAccess.Adaptee;
using CampaignService.DataAccess.Target;
using System.Data;

namespace CampaignService.DataAccess.Adapter
{
    public class CapaignAdapter : ITarget
    {
        private readonly CampaignAdaptee campaignAdaptee;

        public CapaignAdapter(CampaignAdaptee campaignAdaptee)
        {
            this.campaignAdaptee = campaignAdaptee;
        }

        public object ConvertSql(DataRow dataRow)
        {
            return campaignAdaptee.ConvertSqlDataReaderToCampaign(dataRow);
        }
    }
}