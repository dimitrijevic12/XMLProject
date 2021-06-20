using CSharpFunctionalExtensions;
using EasyNetQ;
using Shared.Contracts;
using StoryMicroservice.Core.Interface.Repository;
using StoryMicroservice.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryMicroservice.Core.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBus _bus;

        public UserService(IUserRepository userRepository, IBus bus)
        {
            _userRepository = userRepository;
            _bus = bus;
        }

        public async Task<Result> CreateRegistrationAsync(RegisteredUser registeredUser)
        {
            return Create(registeredUser);
        }

        public Task RejectRegistrationAsync(Guid registeredUserId, string reason)
        {
            _userRepository.Delete(registeredUserId);

            return Task.CompletedTask;
        }

        public Result Create(RegisteredUser registeredUser)
        {
            if (_userRepository.GetById(registeredUser.Id).HasValue) return Result.Failure("Users with that Id already exists.");
            if (_userRepository.GetByUsername(registeredUser.Username).HasValue) return Result.Failure("Users with that username already exists.");
            _userRepository.Save(registeredUser);
            return Result.Success(registeredUser);
        }

        public async Task<Result> EditRegistrationAsync(RegisteredUser registeredUser)
        {
            return Edit(registeredUser.Id.ToString(), registeredUser);
        }

        public Result Edit(string id, RegisteredUser registeredUser)
        {
            if (!_userRepository.GetById(registeredUser.Id).Value.Username.ToString().Equals(registeredUser.Username))
            {
                if (_userRepository.GetByUsername(registeredUser.Username).HasValue) return Result.Failure("There is already user with that username");
            }
            _userRepository.Edit(id, registeredUser);
            return Result.Success(registeredUser);
        }

        private List<string> CreateIds(IEnumerable<Core.Model.RegisteredUser> registeredUsers)
        {
            var test = registeredUsers.Select(registeredUser => registeredUser.Id.ToString()).ToList();
            return test;
        }

        public Result AddCloseFriend(string id, string closeFriendId)
        {
            var closeFriend = _userRepository.GetById(new Guid(closeFriendId)).Value;
            var user = _userRepository.GetById(new Guid(id)).Value;
            if (user.MyCloseFriends.Contains(closeFriend))
                return Result.Failure("Users is already a close friend.");
            var closeFriends = new List<Core.Model.RegisteredUser>(user.MyCloseFriends);
            closeFriends.Add(closeFriend);
            var closeFriendsTo = new List<Core.Model.RegisteredUser>(closeFriend.CloseFriendTo);
            closeFriendsTo.Add(user);
            _userRepository.Edit(closeFriendId, Core.Model.RegisteredUser.Create(closeFriend.Id, closeFriend.Username, closeFriend.FirstName,
                closeFriend.LastName, closeFriend.IsPrivate, closeFriend.IsAcceptingTags, closeFriend.ProfilePicturePath,
                closeFriend.BlockedByUsers, closeFriend.BlockedByUsers, closeFriend.Following,
                closeFriend.Followers, closeFriend.MyCloseFriends, closeFriendsTo).Value);
            _userRepository.Edit(id, Core.Model.RegisteredUser.Create(user.Id, user.Username, user.FirstName, user.LastName, user.IsPrivate,
                user.IsAcceptingTags, user.ProfilePicturePath, user.BlockedByUsers, user.BlockedByUsers, user.Following,
                user.Followers, closeFriends, user.CloseFriendTo).Value);
            return Result.Success("User successfully added to close friends");
        }
    }
}