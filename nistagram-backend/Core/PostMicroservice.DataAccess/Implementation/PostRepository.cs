using Microsoft.Extensions.Configuration;
using PostMicroservice.Core.Model;
using PostMicroservice.DataAccess.Adaptee;
using PostMicroservice.DataAccess.Adapter;
using PostMicroservice.DataAccess.Target;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using PostMicroservice.Core.Interface.Repository;
using System;

namespace PostMicroservice.DataAccess.Implementation
{
    public class PostRepository : Repository, IPostRepository
    {
        public ITarget _target = new PostAdapter(new PostAdaptee());

        public PostRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<Post> GetAll()
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT p.id, p.timestamp, p.description, " +
                "p.type, l.id, l.city_name, l.street, l.country, r.id, r.username, r.first_name, " +
                "r.last_name, r.profilePicturePath, r.isPrivate, r.isAcceptingTags, c.content_path ");
            queryBuilder.Append("FROM dbo.Post as p, dbo.Location as l, dbo.RegisteredUser as r, " +
                "dbo.Content as c ");
            queryBuilder.Append("WHERE p.location_id=l.id and p.registered_user_id=r.id and p.id=c.post_id;");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>();

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows
                    select (Post)_target.ConvertSql(dataRow)).ToList();
        }

        public Post GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Post Save(Post obj)
        {
            throw new System.NotImplementedException();
        }

        public Post Edit(Post obj)
        {
            throw new System.NotImplementedException();
        }

        public Post Delete(Post obj)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Post> GetByUserId(Guid id)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT p.id, p.timestamp, p.description, " +
                "p.type, l.id, l.city_name, l.street, l.country, r.id, r.username, r.first_name, " +
                "r.last_name, r.profilePicturePath, r.isPrivate, r.isAcceptingTags, c.content_path ");
            queryBuilder.Append("FROM dbo.Post as p, dbo.Location as l, dbo.RegisteredUser as r, " +
                "dbo.Content as c ");
            queryBuilder.Append("WHERE p.location_id=l.id and p.registered_user_id=r.id and p.id=c.post_id " +
                "AND r.Id = @Id;");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows
                    select (Post)_target.ConvertSql(dataRow)).ToList();
        }
    }
}