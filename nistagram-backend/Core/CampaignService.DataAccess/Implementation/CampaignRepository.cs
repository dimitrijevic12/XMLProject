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

            List<SqlParameter> parameters = new List<SqlParameter>
             {
                 new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = campaign.Id },
                 new SqlParameter("@Target_audience_id", SqlDbType.UniqueIdentifier) { Value = Guid.NewGuid()},
                 new SqlParameter("@Agent_id", SqlDbType.UniqueIdentifier) { Value = campaign.Agent.Id },
                 new SqlParameter("@Likes_count", SqlDbType.Int) { Value = campaign.CampaignStatistics.LikesCount },
                 new SqlParameter("@Exposure_count", SqlDbType.Int) { Value = campaign.CampaignStatistics.ExposureCount },
                 new SqlParameter("@Click_count", SqlDbType.Int) { Value = campaign.CampaignStatistics.ClickCount },
                 new SqlParameter("@Type", SqlDbType.NVarChar) { Value = campaign.GetType().Name },
                 /*new SqlParameter("@Start_date", SqlDbType.DateTime) { Value = campaign.sta },
                 new SqlParameter("@End_date", SqlDbType.Bit) { Value = campaign.IsPrivate },
                 new SqlParameter("@Date_of_change", SqlDbType.Bit) { Value = campaign.IsAcceptingMessages },*/
             };

            ExecuteQuery(query, parameters);
        }

        public void Update(Campaign campaign)
        {
            throw new NotImplementedException();
        }
    }
}