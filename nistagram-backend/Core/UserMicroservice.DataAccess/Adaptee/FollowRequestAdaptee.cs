﻿using System;
using System.Collections.Generic;
using System.Data;
using UserMicroservice.Core.Model;

namespace UserMicroservice.DataAccess.Adaptee
{
    public class FollowRequestAdaptee
    {
        public FollowRequest ConvertSqlDataReaderToFollowRequest(DataRow dataRow)
        {
            RegisteredUser requestsFollow = RegisteredUser.Create(Guid.Parse(dataRow[2].ToString()),
                                    Username.Create(dataRow[3].ToString()).Value,
                                    EmailAddress.Create(dataRow[4].ToString()).Value,
                                    FirstName.Create(dataRow[5].ToString()).Value,
                                    LastName.Create(dataRow[6].ToString()).Value,
                                    DateTime.Parse(dataRow[7].ToString()),
                                    PhoneNumber.Create(dataRow[8].ToString()).Value,
                                    Gender.Create(dataRow[9].ToString()).Value,
                                    WebsiteAddress.Create(dataRow[10].ToString()).Value,
                                    Bio.Create(dataRow[11].ToString()).Value,
                                    bool.Parse(dataRow[12].ToString()),
                                    bool.Parse(dataRow[13].ToString()),
                                    bool.Parse(dataRow[14].ToString()),
                                    Password.Create(dataRow[17].ToString()).Value,
                                    ProfileImagePath.Create(dataRow[18].ToString()).Value,
                                    new List<RegisteredUser>(),
                                    new List<RegisteredUser>(),
                                    new List<RegisteredUser>(),
                                    new List<RegisteredUser>(),
                                    new List<RegisteredUser>(),
                                    new List<RegisteredUser>(),
                                    new List<RegisteredUser>(),
                                    new List<RegisteredUser>()).Value;

            RegisteredUser receivesFollow = RegisteredUser.Create(Guid.Parse(dataRow[19].ToString()),
                                    Username.Create(dataRow[20].ToString()).Value,
                                    EmailAddress.Create(dataRow[21].ToString()).Value,
                                    FirstName.Create(dataRow[22].ToString()).Value,
                                    LastName.Create(dataRow[23].ToString()).Value,
                                    DateTime.Parse(dataRow[24].ToString()),
                                    PhoneNumber.Create(dataRow[25].ToString()).Value,
                                    Gender.Create(dataRow[26].ToString()).Value,
                                    WebsiteAddress.Create(dataRow[27].ToString()).Value,
                                    Bio.Create(dataRow[28].ToString()).Value,
                                    bool.Parse(dataRow[29].ToString()),
                                    bool.Parse(dataRow[30].ToString()),
                                    bool.Parse(dataRow[31].ToString()),
                                    Password.Create(dataRow[34].ToString()).Value,
                                    ProfileImagePath.Create(dataRow[35].ToString()).Value,
                                    new List<RegisteredUser>(),
                                    new List<RegisteredUser>(),
                                    new List<RegisteredUser>(),
                                    new List<RegisteredUser>(),
                                    new List<RegisteredUser>(),
                                    new List<RegisteredUser>(),
                                    new List<RegisteredUser>(),
                                    new List<RegisteredUser>()).Value;

            return FollowRequest.Create(Guid.Parse(dataRow[0].ToString()),
                            DateTime.Parse(dataRow[1].ToString()),
                            requestsFollow,
                            receivesFollow).Value;
        }
    }
}