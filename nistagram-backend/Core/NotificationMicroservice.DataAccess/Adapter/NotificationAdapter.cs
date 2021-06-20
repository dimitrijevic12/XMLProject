using NotificationMicroservice.DataAccess.Adaptee;
using NotificationMicroservice.DataAccess.Target;
using System.Data;

namespace NotificationMicroservice.DataAccess.Adapter
{
    public class NotificationAdapter : ITarget
    {
        private readonly NotificationAdaptee notificationAdaptee;

        public NotificationAdapter(NotificationAdaptee notificationAdaptee)
        {
            this.notificationAdaptee = notificationAdaptee;
        }

        public object ConvertSql(DataRow dataRow)
        {
            return notificationAdaptee.ConvertSqlDataReaderToNotification(dataRow);
        }
    }
}