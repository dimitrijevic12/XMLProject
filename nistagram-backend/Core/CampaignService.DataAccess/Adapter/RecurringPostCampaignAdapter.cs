using CampaignService.DataAccess.Adaptee;
using CampaignService.DataAccess.Target;
using System.Data;

namespace CampaignService.DataAccess.Adapter
{
    public class RecurringPostCampaignAdapter /*: ITarget*/
    {
        private readonly RecurringPostCampaignAdaptee recurringPostCampaignAdaptee;

        public RecurringPostCampaignAdapter(RecurringPostCampaignAdaptee recurringPostCampaignAdaptee)
        {
            this.recurringPostCampaignAdaptee = recurringPostCampaignAdaptee;
        }

        /* public object ConvertSql(DataRow dataRow)
         {
             return recurringPostCampaignAdaptee.ConvertSqlDataReaderToReccuringStoryCampaign(dataRow);
         }*/
    }
}