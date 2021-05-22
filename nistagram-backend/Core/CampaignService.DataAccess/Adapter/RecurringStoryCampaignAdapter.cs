using CampaignService.DataAccess.Adaptee;
using CampaignService.DataAccess.Target;
using System.Data;

namespace CampaignService.DataAccess.Adapter
{
    public class RecurringStoryCampaignAdapter : ITarget
    {
        private readonly RecurringStoryCampaignAdaptee reccuringStoryCampaignAdaptee;

        public RecurringStoryCampaignAdapter(RecurringStoryCampaignAdaptee reccuringStoryCampaignAdaptee)
        {
            this.reccuringStoryCampaignAdaptee = reccuringStoryCampaignAdaptee;
        }

        public object ConvertSql(DataRow dataRow)
        {
            return reccuringStoryCampaignAdaptee.ConvertSqlDataReaderToReccuringStoryCampaign(dataRow);
        }
    }
}