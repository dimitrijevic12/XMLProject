using NotificationMicroservice.DataAccess.Adaptee;
using NotificationMicroservice.DataAccess.Target;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationMicroservice.DataAccess.Adapter
{
    internal class NotificationOptionsAdapter : ITarget
    {
        private readonly NotificationOptionsAdaptee notificationOptionsAdaptee;

        public NotificationOptionsAdapter(NotificationOptionsAdaptee notificationOptionsAdaptee)
        {
            this.notificationOptionsAdaptee = notificationOptionsAdaptee;
        }

        public object ConvertSql(DataRow dataRow)
        {
            return notificationOptionsAdaptee.ConvertSqlDataReaderToNotificationOptions(dataRow);
        }
    }
}