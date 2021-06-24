using CampaignMicroservice.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace CampaignService.DataAccess.Adaptee
{
    public class RegisteredUserAdaptee
    {
        /*public RegisteredUser ConvertSqlDataReaderToRegisteredUser(DataRow dataRow)
        {
            return RegisteredUser.Create(
                    id: Guid.Parse(dataRow[0].ToString().Trim()),
                    username: Username.Create(dataRow[1].ToString().Trim()).Value,
                    firstName: FirstName.Create(dataRow[2].ToString().Trim()).Value,
                    lastName: LastName.Create(dataRow[3].ToString().Trim()).Value,
                    dateOfBirth: DateTime.Parse(dataRow[4].ToString().Trim()),
                    gender: Gender.Create(dataRow[5].ToString().Trim()).Value,
                    blockedByAgents: new List<Agent>(),
                    blockedAgents: new List<Agent>(),
                    followsAgents: new List<Agent>()).Value;
        }*/
    }
}