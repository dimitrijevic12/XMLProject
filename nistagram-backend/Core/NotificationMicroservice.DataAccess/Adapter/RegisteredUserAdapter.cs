using NotificationMicroservice.DataAccess.Adaptee;
using NotificationMicroservice.DataAccess.Target;
using System.Data;

namespace NotificationMicroservice.DataAccess.Adapter
{
    public class RegisteredUserAdapter : ITarget
    {
        private readonly RegisteredUserAdaptee registeredUserAdaptee;

        public RegisteredUserAdapter(RegisteredUserAdaptee registeredUserAdaptee)
        {
            this.registeredUserAdaptee = registeredUserAdaptee;
        }

        public object ConvertSql(DataRow dataRow)
        {
            return registeredUserAdaptee.ConvertSqlDataReaderToRegisteredUser(dataRow);
        }
    }
}