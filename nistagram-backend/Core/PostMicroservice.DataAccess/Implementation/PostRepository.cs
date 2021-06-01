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
        public PostAdapter _target = new PostAdapter(new PostAdaptee());
        public ITarget _commentTarget = new CommentAdapter(new CommentAdaptee());
        public ITarget _hashTagTarget = new HashTagAdapter(new HashTagAdaptee());
        public ITarget _registeredUserTarget = new RegisteredUserAdapter(new RegisteredUserAdaptee());

        public PostRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<Post> GetAll()
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT p.id, p.timestamp, p.description, " +
                "p.type, l.id, l.city_name, l.street, l.country, r.id, r.username, r.first_name, " +
                "r.last_name, r.profilePicturePath, r.isPrivate, r.isAcceptingTags, c.content_path ");
            queryBuilder.Append("FROM dbo.Post AS p, dbo.Location AS l, dbo.RegisteredUser AS r, " +
                "dbo.Content AS c ");
            queryBuilder.Append("WHERE p.location_id=l.id AND p.registered_user_id=r.id AND p.id=c.post_id;");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>();

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows
                    select (Post)_target.ConvertSqlWithAttributes(dataRow, GetLikesForPost((Guid)dataRow[0]),
                    GetDislikesForPost((Guid)dataRow[0]), GetHashTagsForPost((Guid)dataRow[0]),
                    GetCommentsForPost((Guid)dataRow[0]), GetTaggedPeopleForPost((Guid)dataRow[0]))).ToList();
        }

        public Post GetById(Guid id)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT p.id, p.timestamp, p.description, " +
                "p.type, l.id, l.street, l.city_name, l.country, r.id, r.username, r.first_name, " +
                "r.last_name, r.profilePicturePath, r.isPrivate, r.isAcceptingTags, c.content_path ");
            queryBuilder.Append("FROM dbo.Post AS p, dbo.Location AS l, dbo.RegisteredUser AS r, " +
                "dbo.Content AS c ");
            queryBuilder.Append("WHERE p.location_id=l.id AND p.registered_user_id=r.id AND p.id=c.post_id " +
                "AND p.Id = @Id;");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            return (Post)_target.ConvertSqlWithAttributes(ExecuteQuery(query, parameters).Rows[0],
                 GetLikesForPost(id), GetDislikesForPost(id), GetHashTagsForPost(id), GetCommentsForPost(id),
                 GetTaggedPeopleForPost(id));
        }

        public Post Save(Post obj)
        {
            throw new NotImplementedException();
        }

        public Post SaveSinglePost(PostSingle post)
        {
            StringBuilder queryBuilder = new StringBuilder("INSERT INTO dbo.Post ");
            queryBuilder.Append("(id, timestamp, description, registered_user_id, type, location_id) ");
            queryBuilder.Append("VALUES (@id, @timestamp, @description, @registered_user_id, @type, @location_id);");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = post.Id },
                new SqlParameter("@timestamp", SqlDbType.NVarChar) { Value = post.TimeStamp },
                new SqlParameter("@description", SqlDbType.NVarChar) { Value = post.Description.ToString() },
                new SqlParameter("@registered_user_id", SqlDbType.UniqueIdentifier) { Value = post.RegisteredUser.Id },
                new SqlParameter("@type", SqlDbType.NVarChar) { Value = "single" },
                new SqlParameter("@location_id", SqlDbType.UniqueIdentifier) { Value = post.Location.Id }
            };

            ExecuteQuery(query, parameters);

            SaveContentPath(post);

            return post;
        }

        public Post Edit(Post post)
        {
            throw new System.NotImplementedException();
        }

        public Post Delete(Post post)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Post> GetBy(Guid id, string hashTag, string access)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT p.id, p.timestamp, p.description, " +
                "p.type, l.id, l.street, l.city_name, l.country, r.id, r.username, r.first_name, " +
                "r.last_name, r.profilePicturePath, r.isPrivate, r.isAcceptingTags, c.content_path ");
            queryBuilder.Append("FROM dbo.Post AS p, dbo.Location AS l, dbo.RegisteredUser AS r, " +
                "dbo.Content AS c, dbo.HashTags AS h ");
            queryBuilder.Append("WHERE p.location_id=l.id AND p.registered_user_id=r.id AND p.id=c.post_id AND h.post_id = p.id ");

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (id != Guid.Empty || !String.IsNullOrWhiteSpace(hashTag) || !String.IsNullOrWhiteSpace(access))
            {
                if (id != Guid.Empty)
                {
                    queryBuilder.Append("AND r.Id = @Id ");

                    SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id };
                    parameters.Add(parameterId);
                }
                if (!String.IsNullOrWhiteSpace(hashTag))
                {
                    queryBuilder.Append("AND h.text = @HashTag ");

                    SqlParameter parameterHashTag = new SqlParameter("@HashTag", SqlDbType.NVarChar) { Value = hashTag };
                    parameters.Add(parameterHashTag);
                }
                if (!String.IsNullOrWhiteSpace(access) && access.Equals("private"))
                {
                    queryBuilder.Append("AND r.isPrivate = @Access ");

                    SqlParameter parameterHashTag = new SqlParameter("@Access", SqlDbType.Bit) { Value = 1 };
                    parameters.Add(parameterHashTag);
                }
                else if (!String.IsNullOrWhiteSpace(access) && access.Equals("public"))
                {
                    queryBuilder.Append("AND r.isPrivate = @Access ");

                    SqlParameter parameterHashTag = new SqlParameter("@Access", SqlDbType.Bit) { Value = 0 };
                    parameters.Add(parameterHashTag);
                }
            }

            string query = queryBuilder.ToString();

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows
                    select (Post)_target.ConvertSqlWithAttributes(dataRow, GetLikesForPost((Guid)dataRow[0]),
                    GetDislikesForPost((Guid)dataRow[0]), GetHashTagsForPost((Guid)dataRow[0]),
                    GetCommentsForPost((Guid)dataRow[0]), GetTaggedPeopleForPost((Guid)dataRow[0]))).ToList();
        }

        public IEnumerable<Post> GetByHashTag(string hashTag)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT p.id, p.timestamp, p.description, " +
                "p.type, l.id, l.street, l.city_name, l.country, r.id, r.username, r.first_name, " +
                "r.last_name, r.profilePicturePath, r.isPrivate, r.isAcceptingTags, c.content_path ");
            queryBuilder.Append("FROM dbo.Post AS p, dbo.Location AS l, dbo.RegisteredUser AS r, " +
                "dbo.Content AS c, dbo.HashTags AS h ");
            queryBuilder.Append("WHERE p.location_id=l.id AND p.registered_user_id=r.id AND p.id=c.post_id " +
                "AND h.text = @HashTag;");

            string query = queryBuilder.ToString();

            SqlParameter parameterHashTag = new SqlParameter("@HashTag", SqlDbType.UniqueIdentifier) { Value = "%" + hashTag + "%" };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterHashTag };

            DataTable dataTable = ExecuteQuery(query, parameters);

            int rowsCount = dataTable.Rows.Count;

            return (from DataRow dataRow in dataTable.Rows
                    select (Post)_target.ConvertSqlWithAttributes(dataRow, GetLikesForPost((Guid)dataRow[0]),
                    GetDislikesForPost((Guid)dataRow[0]), GetHashTagsForPost((Guid)dataRow[0]),
                    GetCommentsForPost((Guid)dataRow[0]), GetTaggedPeopleForPost((Guid)dataRow[0]))).ToList();
        }

        private List<Comment> GetCommentsForPost(Guid id)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT c.id, c.timestamp, c.comment_text, " +
                "r.id, r.username, r.first_name, r.last_name, r.isPrivate, r.isAcceptingTags, " +
                "r.profilePicturePath ");
            queryBuilder.Append("FROM dbo.Comment AS c, dbo.RegisteredUser AS r ");
            queryBuilder.Append("WHERE c.registered_user_id = r.id AND c.post_id = @Id;");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows
                    select (Comment)_commentTarget.ConvertSql(dataRow)).ToList();
        }

        private List<HashTag> GetHashTagsForPost(Guid id)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT text ");
            queryBuilder.Append("FROM dbo.HashTags ");
            queryBuilder.Append("WHERE post_id = @Id;");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows
                    select (HashTag)_hashTagTarget.ConvertSql(dataRow)).ToList();
        }

        private List<RegisteredUser> GetDislikesForPost(Guid id)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT r.id, r.username, r.first_name, " +
                "r.last_name, r.isPrivate, r.isAcceptingTags, r.profilePicturePath ");
            queryBuilder.Append("FROM dbo.Dislikes AS l, dbo.RegisteredUser AS r ");
            queryBuilder.Append("WHERE l.registered_user_id = r.id AND post_id = @Id;");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows
                    select (RegisteredUser)_registeredUserTarget.ConvertSql(dataRow)).ToList();
        }

        private List<RegisteredUser> GetLikesForPost(Guid id)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT r.id, r.username, r.first_name, " +
                "r.last_name, r.isPrivate, r.isAcceptingTags, r.profilePicturePath ");
            queryBuilder.Append("FROM dbo.Likes AS l, dbo.RegisteredUser AS r ");
            queryBuilder.Append("WHERE l.registered_user_id = r.id AND post_id = @Id;");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows
                    select (RegisteredUser)_registeredUserTarget.ConvertSql(dataRow)).ToList();
        }

        private List<RegisteredUser> GetTaggedPeopleForPost(Guid id)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT r.id, r.username, r.first_name, " +
                "r.last_name, r.isPrivate, r.isAcceptingTags, r.profilePicturePath ");
            queryBuilder.Append("FROM dbo.PostProfileTags AS l, dbo.RegisteredUser AS r ");
            queryBuilder.Append("WHERE l.registered_user_id = r.id AND post_id = @Id;");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows
                    select (RegisteredUser)_registeredUserTarget.ConvertSql(dataRow)).ToList();
        }

        private void SaveContentPath(PostSingle post)
        {
            StringBuilder queryBuilder = new StringBuilder("INSERT INTO dbo.Content ");
            queryBuilder.Append("(id, post_id, content_path) ");
            queryBuilder.Append("VALUES (@id, @post_id, @content_path);");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = Guid.NewGuid() },
                new SqlParameter("@post_id", SqlDbType.UniqueIdentifier) { Value = post.Id },
                new SqlParameter("@content_path", SqlDbType.NVarChar) { Value = post.ContentPath.ToString() }
            };

            ExecuteQuery(query, parameters);
        }
    }
}