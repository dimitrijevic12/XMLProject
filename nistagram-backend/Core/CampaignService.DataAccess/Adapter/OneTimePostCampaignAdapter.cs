using CampaignService.DataAccess.Adaptee;
using CampaignService.DataAccess.Target;
using System.Data;

namespace CampaignService.DataAccess.Adapter
{
    public class OneTimePostCampaignAdapter/* : ITarget*/
    {
        private readonly OneTimePostCampaignAdaptee oneTimePostCampaignAdaptee;

        public OneTimePostCampaignAdapter(OneTimePostCampaignAdaptee oneTimePostCampaignAdaptee)
        {
            this.oneTimePostCampaignAdaptee = oneTimePostCampaignAdaptee;
        }

        /* public object ConvertSql(DataRow dataRow)
         {
             return oneTimePostCampaignAdaptee.ConvertSqlDataReaderToOneTimePostCampaign(dataRow);
         }*/
    }
}