using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMicroservice.Core.Model;

namespace UserMicroservice.DataAccess.Adaptee
{
    public class UserModelAdaptee
    {
        public UserModel ConvertSqlDataReaderToUserModel(DataRow dataRow)
        {
            UserModel user = new UserModel();
            user.Id = Guid.Parse(dataRow[0].ToString());
            user.Password = dataRow[15].ToString();
            user.Username = dataRow[1].ToString();
            user.Role = dataRow[13].ToString();

            return user;
        }
    }
}