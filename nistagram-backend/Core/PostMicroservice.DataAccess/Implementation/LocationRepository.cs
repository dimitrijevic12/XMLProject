using Microsoft.Extensions.Configuration;
using PostMicroservice.Core.Interface.Repository;
using PostMicroservice.Core.Model;
using PostMicroservice.DataAccess.Adaptee;
using PostMicroservice.DataAccess.Adapter;
using PostMicroservice.DataAccess.Target;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostMicroservice.DataAccess.Implementation
{
    public class LocationRepository : Repository, ILocationRepository
    {
        public ITarget _locationTarget = new LocationAdapter(new LocationAdaptee());

        public LocationRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<Location> GetAll()
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT l.id, l.street, l.city_name, l.country ");
            queryBuilder.Append("FROM dbo.Location AS l;");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>();

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows
                    select (Location)_locationTarget.ConvertSql(dataRow)).ToList();
        }

        public Location GetById(Guid id)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT l.id, l.street, l.city_name, l.country ");
            queryBuilder.Append("FROM dbo.Location AS l ");
            queryBuilder.Append("WHERE l.Id = @Id;");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            return (Location)_locationTarget.ConvertSql(
                ExecuteQuery(query, parameters).Rows[0]
            );
        }

        public Location Save(Location obj)
        {
            throw new NotImplementedException();
        }

        public Location Edit(Location obj)
        {
            throw new NotImplementedException();
        }

        public Location Delete(Location obj)
        {
            throw new NotImplementedException();
        }
    }
}