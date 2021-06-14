using CSharpFunctionalExtensions;
using Microsoft.Extensions.Configuration;
using ReportMicroservice.Core.Interface.Repository;
using ReportMicroservice.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ReportMicroservice.DataAccess.Implementation
{
    public class ReportRepository : Repository, IReportRepository
    {
        public ReportRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<Report> GetAll()
        {
            throw new NotImplementedException();
        }

        public Maybe<Report> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Report Save(Report report)
        {
            StringBuilder queryBuilder = new StringBuilder("INSERT INTO dbo.Report ");
            queryBuilder.Append("(id, timestamp, report_reason, registered_user_id, type, content_id) ");
            queryBuilder.Append("VALUES (@id, @timestamp, @report_reason, @registered_user_id, @type, @content_id);");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
             {
                 new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = report.Id },
                 new SqlParameter("@timestamp", SqlDbType.NVarChar) { Value = report.TimeStamp },
                 new SqlParameter("@report_reason", SqlDbType.NVarChar) { Value = report.ReportReason.ToString() },
                 new SqlParameter("@registered_user_id", SqlDbType.UniqueIdentifier) { Value = report.RegisteredUser.Id },
                 new SqlParameter("@type", SqlDbType.NVarChar) { Value = report.Content.GetType().Name },
                 new SqlParameter("@content_id", SqlDbType.UniqueIdentifier) { Value = report.Content.Id }
             };

            ExecuteQuery(query, parameters);

            return report;
        }

        public Report Edit(Report report)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}