using CSharpFunctionalExtensions;
using MongoDB.Driver;
using StoryMicroservice.Core.DTOs;
using StoryMicroservice.Core.Interface.Repository;
using StoryMicroservice.DataAccess.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoryMicroservice.DataAccess.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<RegisteredUser> _users;
        private readonly RegisteredUserFactory userFactory;

        public UserRepository(IStoryDatabaseSettings settings, RegisteredUserFactory userFactory)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<RegisteredUser>(settings.RegisteredUsersCollectionName);
            this.userFactory = userFactory;
        }

        public void Delete(Core.Model.RegisteredUser obj)
        {
            throw new NotImplementedException();
        }

        public Core.Model.RegisteredUser Edit(string id, Core.Model.RegisteredUser obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Model.RegisteredUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public Maybe<Core.Model.RegisteredUser> GetById(Guid id)
        {
            var userDTO = _users.Find<RegisteredUser>(user => user.Id.Equals(id)).FirstOrDefault();
            var blockedByUsers = GetUsersById(userDTO.BlockedByUsers);
            var blockedUsers = GetUsersById(userDTO.BlockedUsers);
            var followers = GetUsersById(userDTO.Followers);
            var following = GetUsersById(userDTO.Following);
            var closeFriendTo = GetUsersById(userDTO.CloseFriendTo);
            var MyCloseFriends = GetUsersById(userDTO.MyCloseFriends);
            return userFactory.Create(userDTO,
                blockedUsers, blockedByUsers, followers, following, closeFriendTo, MyCloseFriends);
        }

        public Core.Model.RegisteredUser Save(Core.Model.RegisteredUser user)
        {
            _users.InsertOne(userFactory.Create(user));
            return user;
        }

        public IEnumerable<Core.Model.RegisteredUser> GetUsersById(List<string> ids)
        {
            return userFactory.CreateUsers(_users.Find(user => ids.Contains(user.Id)).ToList());
        }

        public IEnumerable<Core.Model.RegisteredUser> GetUsersByDTO(List<RegisteredUser> users)
        {
            var test = users.Select(user => user.Id);
            return userFactory.CreateUsers(_users.Find(user => test.Contains(user.Id)).ToList());
        }
    }
}