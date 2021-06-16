using System.Data;

namespace NotificationMicroservice.DataAccess.Target
{
    public interface ITarget
    {
        public object ConvertSql(DataRow dataRow);
    }
}