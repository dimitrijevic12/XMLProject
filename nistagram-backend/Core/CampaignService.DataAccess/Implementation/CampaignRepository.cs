using CampaignMicroservice.Core.Interface;
using CampaignMicroservice.Core.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignService.DataAccess.Implementation
{
    public class CampaignRepository : Repository, ICampaignRepository
    {
        public CampaignRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Campaign campaign)
        {
            StringBuilder queryBuilder = new StringBuilder("INSERT INTO dbo.Campaign ");
            queryBuilder.Append("(id, target_audience_id, agent_id, likes_count, dislikes_count, exposure_count, click_count, type, start_date, end_date, date_of_change) ");
            queryBuilder.Append("VALUES (@Id, @Target_audience_id, @Agent_id, @Likes_count, @Dislikes_count, @Exposure_count, @Click_count, @Type, @Start_date, @End_date, @Date_of_change);");

            string query = queryBuilder.ToString();
            var campaign2 = (RecurringPostCampaign)campaign;
            var test = int.Parse(campaign.CampaignStatistics.LikesCount.ToString());

            List<SqlParameter> parameters = new List<SqlParameter>
             {
                 new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = campaign.Id },
                 new SqlParameter("@Target_audience_id", SqlDbType.UniqueIdentifier) { Value = new Guid("8C062887-1E37-489F-BA89-942FA64058BE")},
                 new SqlParameter("@Agent_id", SqlDbType.UniqueIdentifier) { Value = campaign.Agent.Id },
                 new SqlParameter("@Likes_count", SqlDbType.Int) { Value = int.Parse(campaign.CampaignStatistics.LikesCount.ToString()) },
                 new SqlParameter("@Dislikes_count", SqlDbType.Int) { Value = int.Parse(campaign.CampaignStatistics.DislikesCount.ToString()) },
                 new SqlParameter("@Exposure_count", SqlDbType.Int) { Value = int.Parse(campaign.CampaignStatistics.ExposureCount.ToString()) },
                 new SqlParameter("@Click_count", SqlDbType.Int) { Value = int.Parse(campaign.CampaignStatistics.ClickCount.ToString()) },
                 new SqlParameter("@Type", SqlDbType.NVarChar) { Value = campaign.GetType().Name },
                 new SqlParameter("@Start_date", SqlDbType.DateTime) { Value = campaign2.StartDate },
                 new SqlParameter("@End_date", SqlDbType.DateTime) { Value = campaign2.EndDate },
                 new SqlParameter("@Date_of_change", SqlDbType.DateTime) { Value = campaign2.DateOfChange },
             };

            ExecuteQuery(query, parameters);
        }

        public void Update(Campaign campaign)
        {
            throw new NotImplementedException();
        }
    }
}