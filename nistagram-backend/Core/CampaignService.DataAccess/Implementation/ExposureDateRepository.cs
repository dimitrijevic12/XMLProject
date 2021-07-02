using CampaignMicroservice.Core.Interface;
using CampaignMicroservice.Core.Model;
using CSharpFunctionalExtensions;
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
    public class ExposureDateRepository : Repository, IExposureDateRepository
    {
        public ExposureDateRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Maybe<ExposureDate> GetById(Guid id)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT * ");
            queryBuilder.Append("FROM dbo.ExposureDates ");
            queryBuilder.Append("WHERE id = @Id;");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            DataTable dataTable = ExecuteQuery(query, parameters);

            /*if (dataTable.Rows.Count > 0)
            {
                return (RegisteredUser)_registeredUserTarget.ConvertSql(
                dataTable.Rows[0], GetBlocking(id), GetBlockedBy(id),
                GetMuted(id), GetMutedBy(id), GetFollowing(id), GetFollowers(id),
                GetMyCloseFriends(id), GetCloseFriendsTo(id)
                );
            }*/
            return Maybe<ExposureDate>.None;
        }

        public void Save(ExposureDate exposureDate)
        {
            throw new NotImplementedException();
        }
    }
}