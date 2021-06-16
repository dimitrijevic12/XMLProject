using CSharpFunctionalExtensions;
using Microsoft.Extensions.Configuration;
using NotificationMicroservice.Core.Interface.Repository;
using NotificationMicroservice.Core.Model;
using NotificationMicroservice.DataAccess.Adaptee;
using NotificationMicroservice.DataAccess.Adapter;
using NotificationMicroservice.DataAccess.Target;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace NotificationMicroservice.DataAccess.Implementation
{
    public class RegisteredUserRepository : Repository, IRegisteredUserRepository
    {
        public ITarget _registeredUserTarget = new RegisteredUserAdapter(new RegisteredUserAdaptee());

        public RegisteredUserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<RegisteredUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public Maybe<RegisteredUser> GetById(Guid id)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT r.id, r.username, r.profilePicturePath, " +
                "n.id, n.is_notified_by_follow_requests, n.is_notified_by_messages, n.is_notified_by_posts, " +
                "n.is_notified_by_stories, n.is_notified_by_comments ");
            queryBuilder.Append("FROM dbo.RegisteredUser AS r, dbo.NotificationOptions AS n ");
            queryBuilder.Append("WHERE r.notification_options_id = n.id AND r.id = @Id;");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            DataTable dataTable = ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                return (RegisteredUser)_registeredUserTarget.ConvertSql(
                dataTable.Rows[0]);
            }
            return Maybe<RegisteredUser>.None;
        }

        public RegisteredUser Save(RegisteredUser obj)
        {
            throw new NotImplementedException();
        }

        public RegisteredUser Edit(RegisteredUser registeredUser)
        {
            return EditNotificationOptions(registeredUser);
        }

        private RegisteredUser EditNotificationOptions(RegisteredUser registeredUser)
        {
            StringBuilder queryBuilder = new StringBuilder("UPDATE dbo.NotificationOptions ");
            queryBuilder.Append("SET is_notified_by_follow_requests = @is_notified_by_follow_requests,  " +
                "is_notified_by_messages = @is_notified_by_messages, is_notified_by_posts = @is_notified_by_posts, " +
                "is_notified_by_stories = @is_notified_by_stories, is_notified_by_comments = @is_notified_by_comments ");
            queryBuilder.Append("WHERE id = @id;");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = registeredUser.NotificationOptions.Id },
                 new SqlParameter("@is_notified_by_follow_requests", SqlDbType.Bit) { Value = registeredUser.NotificationOptions.IsNotifiedByFollowRequests },
                 new SqlParameter("@is_notified_by_messages", SqlDbType.Bit) { Value = registeredUser.NotificationOptions.IsNotifiedByMessages },
                 new SqlParameter("@is_notified_by_posts", SqlDbType.Bit) { Value = registeredUser.NotificationOptions.IsNotifiedByPosts },
                 new SqlParameter("@is_notified_by_stories", SqlDbType.Bit) { Value = registeredUser.NotificationOptions.IsNotifiedByStories },
                 new SqlParameter("@is_notified_by_comments", SqlDbType.Bit) { Value = registeredUser.NotificationOptions.IsNotifiedByComments }
            };

            ExecuteQuery(query, parameters);

            return registeredUser;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}