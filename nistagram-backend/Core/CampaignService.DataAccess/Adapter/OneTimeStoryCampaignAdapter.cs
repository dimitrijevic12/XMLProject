using CampaignService.DataAccess.Adaptee;
using CampaignService.DataAccess.Target;
using System.Data;

namespace CampaignService.DataAccess.Adapter
{
    public class OneTimeStoryCampaignAdapter : ITarget
    {
        private readonly OneTimeStoryCampaignAdaptee oneTimeStoryCampaignAdaptee;

        public OneTimeStoryCampaignAdapter(OneTimeStoryCampaignAdaptee oneTimeStoryCampaignAdaptee)
        {
            this.oneTimeStoryCampaignAdaptee = oneTimeStoryCampaignAdaptee;
        }

        public object ConvertSql(DataRow dataRow)
        {
            return oneTimeStoryCampaignAdaptee.ConvertSqlDataReaderToOneTimeStoryCampaign(dataRow);
        }
    }
}