using System.Data;

namespace CampaignService.DataAccess.Target
{
    public interface ITarget
    {
        public object ConvertSql(DataRow dataRow);
    }
}