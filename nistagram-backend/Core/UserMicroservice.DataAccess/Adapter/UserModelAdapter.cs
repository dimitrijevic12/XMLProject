using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMicroservice.DataAccess.Adaptee;
using UserMicroservice.DataAccess.Target;

namespace UserMicroservice.DataAccess.Adapter
{
    public class UserModelAdapter : ITarget
    {
        private readonly UserModelAdaptee userModelAdaptee;

        public UserModelAdapter(UserModelAdaptee userModelAdaptee)
        {
            this.userModelAdaptee = userModelAdaptee;
        }

        public object ConvertSql(DataRow dataRow)
        {
            return userModelAdaptee.ConvertSqlDataReaderToUserModel(dataRow);
        }
    }
}