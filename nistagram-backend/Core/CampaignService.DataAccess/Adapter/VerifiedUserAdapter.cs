using CampaignService.DataAccess.Adaptee;
using CampaignService.DataAccess.Target;
using System.Data;

namespace CampaignService.DataAccess.Adapter
{
    public class VerifiedUserAdapter : ITarget
    {
        private readonly VerifiedUserAdaptee verifiedUserAdaptee;

        public VerifiedUserAdapter(VerifiedUserAdaptee verifiedUserAdaptee)
        {
            this.verifiedUserAdaptee = verifiedUserAdaptee;
        }

        public object ConvertSql(DataRow dataRow)
        {
            return verifiedUserAdaptee.ConvertSqlDataReaderToVerifiedUser(dataRow);
        }
    }
}