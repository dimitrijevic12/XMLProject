using CampaignMicroservice.Core.Interface;
using CampaignMicroservice.Core.Model;
using CampaignService.DataAccess.Adaptee;
using CampaignService.DataAccess.Adapter;
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
        private readonly ExposureDateAdapter exposureDateAdapter = new ExposureDateAdapter(new ExposureDateAdaptee());
        private readonly IUserRepository _userRepository;

        public ExposureDateRepository(IConfiguration configuration, IUserRepository userRepository) : base(configuration)
        {
            _userRepository = userRepository;
        }

        public Maybe<ExposureDate> GetById(Guid id)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT id, exposure_date ");
            queryBuilder.Append("FROM dbo.ExposureDates ");
            queryBuilder.Append("WHERE id = @Id;");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            DataTable dataTable = ExecuteQuery(query, parameters);

            IEnumerable<RegisteredUser> seenBy = _userRepository.GetSeenBy(new Guid(dataTable.Rows[0][0].ToString()));

            if (dataTable.Rows.Count > 0)
            {
                return (ExposureDate)exposureDateAdapter.ConvertSql(
                dataTable.Rows[0], seenBy
                );
            }
            return Maybe<ExposureDate>.None;
        }

        public void Save(ExposureDate exposureDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExposureDate> GetExposureDatesForCampaign(Guid campaignId)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT id, exposure_date ");
            queryBuilder.Append("FROM dbo.ExposureDates ");
            queryBuilder.Append("WHERE campaign_id = @Id;");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = campaignId };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows
                    select (ExposureDate)exposureDateAdapter.ConvertSql(dataRow, _userRepository.GetSeenBy(new Guid(dataRow[0].ToString())))).ToList();
        }
    }
}