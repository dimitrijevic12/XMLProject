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
using System.Linq;

namespace NotificationMicroservice.DataAccess.Implementation
{
    public class NotificationOptionsRepository : Repository, INotificationOptionsRepository
    {
        public ITarget _notificationOptionsTarget = new NotificationOptionsAdapter(new NotificationOptionsAdaptee());

        public NotificationOptionsRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public NotificationOptions Edit(NotificationOptions notificationOptions)
        {
            StringBuilder queryBuilder = new StringBuilder("UPDATE dbo.NotificationOptions ");
            queryBuilder.Append("SET is_notified_by_follow_requests = @is_notified_by_follow_requests,  " +
                "is_notified_by_messages = @is_notified_by_messages, is_notified_by_posts = @is_notified_by_posts, " +
                "is_notified_by_stories = @is_notified_by_stories, is_notified_by_comments = @is_notified_by_comments ");
            queryBuilder.Append("WHERE id = @id;");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = notificationOptions.Id },
                 new SqlParameter("@is_notified_by_follow_requests", SqlDbType.Bit) { Value = notificationOptions.IsNotifiedByFollowRequests },
                 new SqlParameter("@is_notified_by_messages", SqlDbType.Bit) { Value = notificationOptions.IsNotifiedByMessages },
                 new SqlParameter("@is_notified_by_posts", SqlDbType.Bit) { Value = notificationOptions.IsNotifiedByPosts },
                 new SqlParameter("@is_notified_by_stories", SqlDbType.Bit) { Value = notificationOptions.IsNotifiedByStories },
                 new SqlParameter("@is_notified_by_comments", SqlDbType.Bit) { Value = notificationOptions.IsNotifiedByComments }
            };

            ExecuteQuery(query, parameters);

            return notificationOptions;
        }

        public IEnumerable<NotificationOptions> GetAll()
        {
            throw new NotImplementedException();
        }

        public Maybe<NotificationOptions> GetById(Guid id)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT n.id, n.is_notified_by_follow_requests, " +
                "n.is_notified_by_messages, n.is_notified_by_posts, n.is_notified_by_stories, n.is_notified_by_comments, " +
                "r.id, r.username, r.profilePicturePath, r2.id, r2.username, r2.profilePicturePath ");
            queryBuilder.Append("FROM dbo.NotificationOptions AS n, dbo.RegisteredUser AS r, dbo.RegisteredUser AS r2 ");
            queryBuilder.Append("WHERE n.logged_user_id = r.id AND n.notification_by_user_id=r2.id AND n.id=@Id;");

            string query = queryBuilder.ToString();

            SqlParameter parameter = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameter };

            DataTable dataTable = ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                return (NotificationOptions)_notificationOptionsTarget.ConvertSql(
                dataTable.Rows[0]);
            }
            return Maybe<NotificationOptions>.None;
        }

        public NotificationOptions Save(NotificationOptions notificationOptions)
        {
            StringBuilder queryBuilder = new StringBuilder("INSERT INTO dbo.NotificationOptions ");
            queryBuilder.Append("(id, is_notified_by_follow_requests, is_notified_by_messages, is_notified_by_posts, " +
                "is_notified_by_stories, is_notified_by_comments, logged_user_id, notification_by_user_id) ");
            queryBuilder.Append("VALUES (@id, @is_notified_by_follow_requests, @is_notified_by_messages, " +
                "@is_notified_by_posts, @is_notified_by_stories, @is_notified_by_comments, @logged_user_id, @notification_by_user_id);");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
             {
                 new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = notificationOptions.Id },
                 new SqlParameter("@is_notified_by_follow_requests", SqlDbType.Bit) { Value = notificationOptions.IsNotifiedByFollowRequests },
                 new SqlParameter("@is_notified_by_messages", SqlDbType.Bit) { Value = notificationOptions.IsNotifiedByMessages },
                 new SqlParameter("@is_notified_by_posts", SqlDbType.Bit) { Value = notificationOptions.IsNotifiedByPosts },
                 new SqlParameter("@is_notified_by_stories", SqlDbType.Bit) { Value = notificationOptions.IsNotifiedByStories },
                 new SqlParameter("@is_notified_by_comments", SqlDbType.Bit) { Value = notificationOptions.IsNotifiedByComments },
                 new SqlParameter("@logged_user_id", SqlDbType.UniqueIdentifier) { Value = notificationOptions.LoggedUser.Id },
                 new SqlParameter("@notification_by_user_id", SqlDbType.UniqueIdentifier) { Value = notificationOptions.NotificationByUser.Id },
             };

            ExecuteQuery(query, parameters);

            return notificationOptions;
        }

        public Maybe<NotificationOptions> GetBy(Guid loggedUserId, Guid notificationByUserId)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT n.id, n.is_notified_by_follow_requests, " +
                "n.is_notified_by_messages, n.is_notified_by_posts, n.is_notified_by_stories, n.is_notified_by_comments, " +
                "r.id, r.username, r.profilePicturePath, r2.id, r2.username, r2.profilePicturePath ");
            queryBuilder.Append("FROM dbo.NotificationOptions AS n, dbo.RegisteredUser AS r, dbo.RegisteredUser AS r2 ");
            queryBuilder.Append("WHERE n.logged_user_id = r.id AND n.notification_by_user_id=r2.id AND " +
                "n.logged_user_id=@logged_user_id AND n.notification_by_user_id=@notification_by_user_id;");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                 new SqlParameter("@logged_user_id", SqlDbType.UniqueIdentifier) { Value = loggedUserId },
                 new SqlParameter("@notification_by_user_id", SqlDbType.UniqueIdentifier) { Value = notificationByUserId },
            };

            DataTable dataTable = ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                return (NotificationOptions)_notificationOptionsTarget.ConvertSql(
                dataTable.Rows[0]);
            }
            return Maybe<NotificationOptions>.None;
        }
    }
}