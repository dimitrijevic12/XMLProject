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
    public class NotificationRepository : Repository, INotificationRepository
    {
        public ITarget _notificationTarget = new NotificationAdapter(new NotificationAdaptee());
        private readonly INotificationOptionsRepository _notificationOptionsRepository;

        public NotificationRepository(IConfiguration configuration,
            INotificationOptionsRepository notificationOptionsRepository) : base(configuration)
        {
            _notificationOptionsRepository = notificationOptionsRepository;
        }

        public IEnumerable<Notification> GetAll()
        {
            throw new NotImplementedException();
        }

        public Maybe<Notification> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Notification Save(Notification notification)
        {
            StringBuilder queryBuilder = new StringBuilder("INSERT INTO dbo.Notification ");
            queryBuilder.Append("(id, timestamp, type, content_id, registered_user_id) ");
            queryBuilder.Append("VALUES (@id, @timestamp, @type, @content_id, @registered_user_id);");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
             {
                 new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = notification.Id },
                 new SqlParameter("@timestamp", SqlDbType.NVarChar) { Value = notification.TimeStamp },
                 new SqlParameter("@type", SqlDbType.NVarChar) { Value = notification.Content.GetType().Name },
                 new SqlParameter("@content_id", SqlDbType.UniqueIdentifier) { Value = notification.Content.Id },
                 new SqlParameter("@registered_user_id", SqlDbType.UniqueIdentifier) { Value = notification.RegisteredUser.Id },
             };

            ExecuteQuery(query, parameters);

            return notification;
        }

        public Notification Edit(Notification notification)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Notification> GetNotificationsForFollowing(IEnumerable<RegisteredUser> users,
            RegisteredUser loggedUser)
        {
            List<Notification> notifications = new List<Notification>();
            foreach (RegisteredUser registeredUser in users)
            {
                notifications.AddRange(GetNotificationsForRegisteredUser(registeredUser, loggedUser));
            }
            return notifications;
        }

        private IEnumerable<Notification> GetNotificationsForRegisteredUser(RegisteredUser registeredUser,
            RegisteredUser loggedUser)
        {
            List<Notification> notifications = new List<Notification>();
            if (_notificationOptionsRepository.GetBy(loggedUser.Id, registeredUser.Id).HasNoValue)
            {
                return new List<Notification>();
            }
            NotificationOptions notificationOptions = _notificationOptionsRepository.GetBy(loggedUser.Id, registeredUser.Id).Value;

            if (notificationOptions.IsNotifiedByFollowRequests)
            {
                notifications.AddRange(GetFollowRequestsNotificationsForRegisteredUser(registeredUser));
            }
            if (notificationOptions.IsNotifiedByPosts)
            {
                notifications.AddRange(GetPostsNotificationsForRegisteredUser(registeredUser));
            }
            if (notificationOptions.IsNotifiedByStories)
            {
                notifications.AddRange(GetStoriesNotificationsForRegisteredUser(registeredUser));
            }
            if (notificationOptions.IsNotifiedByComments)
            {
                notifications.AddRange(GetCommentsNotificationsForRegisteredUser(registeredUser));
            }
            if (notificationOptions.IsNotifiedByMessages)
            {
                notifications.AddRange(GetMessagesNotificationsForRegisteredUser(registeredUser));
            }
            return notifications;
        }

        private IEnumerable<Notification> GetFollowRequestsNotificationsForRegisteredUser(RegisteredUser registeredUser)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT notif.id, notif.timestamp, notif.type, " +
                "notif.content_id, r.id, r.username, r.profilePicturePath ");
            queryBuilder.Append("FROM dbo.Notification AS notif, dbo.RegisteredUser AS R ");
            queryBuilder.Append("WHERE notif.registered_user_id = @Id AND r.id = @Id AND " +
                "notif.type = \'FollowRequest\'");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = registeredUser.Id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows
                    select (Notification)_notificationTarget.ConvertSql(dataRow)).ToList();
        }

        private IEnumerable<Notification> GetPostsNotificationsForRegisteredUser(RegisteredUser registeredUser)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT DISTINCT notif.id, notif.timestamp, notif.type, " +
                "notif.content_id, r.id, r.username, r.profilePicturePath ");
            queryBuilder.Append("FROM  dbo.Notification AS notif, dbo.RegisteredUser AS r ");
            queryBuilder.Append("WHERE notif.registered_user_id = @Id AND r.id = @Id AND " +
                "notif.type = \'Post\'");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = registeredUser.Id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows
                    select (Notification)_notificationTarget.ConvertSql(dataRow)).ToList();
        }

        private IEnumerable<Notification> GetStoriesNotificationsForRegisteredUser(RegisteredUser registeredUser)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT notif.id, notif.timestamp, notif.type, " +
                "notif.content_id, r.id, r.username, r.profilePicturePath ");
            queryBuilder.Append("FROM  dbo.Notification AS notif, dbo.RegisteredUser AS r ");
            queryBuilder.Append("WHERE notif.registered_user_id = @Id AND r.id = @Id AND " +
                "notif.type = \'Story\'");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = registeredUser.Id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows
                    select (Notification)_notificationTarget.ConvertSql(dataRow)).ToList();
        }

        private IEnumerable<Notification> GetCommentsNotificationsForRegisteredUser(RegisteredUser registeredUser)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT notif.id, notif.timestamp, notif.type, " +
                "notif.content_id, r.id, r.username, r.profilePicturePath ");
            queryBuilder.Append("FROM  dbo.Notification AS notif, dbo.RegisteredUser AS r ");
            queryBuilder.Append("WHERE notif.registered_user_id = @Id AND r.id = @Id AND " +
                "notif.type = \'Comment\'");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = registeredUser.Id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows
                    select (Notification)_notificationTarget.ConvertSql(dataRow)).ToList();
        }

        private IEnumerable<Notification> GetMessagesNotificationsForRegisteredUser(RegisteredUser registeredUser)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT notif.id, notif.timestamp, notif.type, " +
                "notif.content_id, r.id, r.username, r.profilePicturePath ");
            queryBuilder.Append("FROM  dbo.Notification AS notif, dbo.RegisteredUser AS r ");
            queryBuilder.Append("WHERE notif.registered_user_id = @Id AND r.id = @Id AND " +
                "notif.type = \'Message\'");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = registeredUser.Id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows
                    select (Notification)_notificationTarget.ConvertSql(dataRow)).ToList();
        }
    }
}