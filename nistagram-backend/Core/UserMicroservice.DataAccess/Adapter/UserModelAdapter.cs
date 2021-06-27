﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMicroservice.Core.Model;
using UserMicroservice.DataAccess.Adaptee;
using UserMicroservice.DataAccess.Target;

namespace UserMicroservice.DataAccess.Adapter
{
    public class UserModelAdapter
    {
        private readonly UserModelAdaptee userModelAdaptee;

        public UserModelAdapter(UserModelAdaptee userModelAdaptee)
        {
            this.userModelAdaptee = userModelAdaptee;
        }

        public object ConvertSql(DataRow dataRow, IEnumerable<RegisteredUser> blockedUsers,
            IEnumerable<RegisteredUser> blockedByUsers, IEnumerable<RegisteredUser> mutedUsers,
            IEnumerable<RegisteredUser> mutedByUsers, IEnumerable<RegisteredUser> following,
            IEnumerable<RegisteredUser> followers, IEnumerable<RegisteredUser> myCloseFriends,
            IEnumerable<RegisteredUser> closeFriendsTo)
        {
            return userModelAdaptee.ConvertSqlDataReaderToUserModel(dataRow, blockedUsers,
                blockedByUsers, mutedUsers, mutedByUsers, following, followers, myCloseFriends, closeFriendsTo);
        }
    }
}