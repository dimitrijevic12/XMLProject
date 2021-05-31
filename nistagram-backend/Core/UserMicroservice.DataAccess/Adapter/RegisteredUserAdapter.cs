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
    internal class RegisteredUserAdapter : ITarget
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