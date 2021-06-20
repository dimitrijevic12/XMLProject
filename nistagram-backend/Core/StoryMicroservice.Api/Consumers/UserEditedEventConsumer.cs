using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Shared.Contracts;
using StoryMicroservice.Core.Interface.Repository;
using StoryMicroservice.Core.Model;
using StoryMicroservice.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoryMicroservice.Api.Consumers
{
    public class UserEditedEventConsumer : IConsumeAsync<UserEditedEvent>
    {
        private readonly UserService userService;
        private readonly IUserRepository _userRepository;
        private readonly IBus _bus;

        public UserEditedEventConsumer(UserService userService, IBus bus, IUserRepository userRepository)
        {
            this.userService = userService;
            _userRepository = userRepository;
            _bus = bus;
        }

        public async Task ConsumeAsync(UserEditedEvent message, CancellationToken cancellationToken = default)
        {
            var result = await userService.EditRegistrationAsync(Convert(message));
            if (result.IsSuccess)
            {
                await _bus.PubSub.PublishAsync(new StoryUserEditedEvent
                {
                    Id = new Guid(message.Id),
                    Username = message.Username,
                    FirstName = message.FirstName,
                    LastName = message.LastName,
                    IsPrivate = message.IsPrivate,
                    IsAcceptingTags = message.IsAcceptingTags,
                    ProfileImagePath = message.ProfilePicturePath.ToString(),
                    Following = Convert(_userRepository.GetUsersById(message.Following)),
                    Followers = Convert(_userRepository.GetUsersById(message.Followers)),
                });
            }
            else
            {
                await _bus.PubSub.PublishAsync(new UnsuccessfulStoryUserRegistrationEvent
                {
                    Id = new Guid(message.Id),
                });
            }
        }

        private IEnumerable<StoryUserEditedEvent> Convert(IEnumerable<Core.Model.RegisteredUser> users)
        {
            return users.Select(registeredUser => new StoryUserEditedEvent
            {
                Id = registeredUser.Id,
                Username = registeredUser.Username,
                FirstName = registeredUser.FirstName,
                LastName = registeredUser.LastName,
                ProfileImagePath = registeredUser.ProfilePicturePath,
                IsPrivate = registeredUser.IsPrivate,
                IsAcceptingTags = registeredUser.IsAcceptingTags,
            }).ToList();
        }

        public List<string> CreateIds(IEnumerable<UserRegisteredEvent> registeredUsers)
        {
            var test = registeredUsers.Select(registeredUser => registeredUser.Id.ToString()).ToList();
            return test;
        }

        public List<RegisteredUser> CreateUsers(List<string> registeredUsersIds)
        {
            var test = registeredUsersIds.Select(registeredUserId => _userRepository.GetById(new Guid(registeredUserId)).Value).ToList();
            return test;
        }

        private RegisteredUser Convert(UserEditedEvent message)
        {
            return RegisteredUser.Create(new Guid(message.Id),
                                           Username.Create(message.Username).Value,
                                           FirstName.Create(message.FirstName).Value,
                                           LastName.Create(message.LastName).Value,
                                           message.IsPrivate,
                                           message.IsAcceptingTags,
                                           ContentPath.Create(message.ProfilePicturePath).Value,
                                           CreateUsers(message.BlockedUsers),
                                           CreateUsers(message.BlockedByUsers),
                                           CreateUsers(message.Following),
                                           CreateUsers(message.Followers),
                                           CreateUsers(message.MyCloseFriends),
                                           CreateUsers(message.CloseFriendTo)).Value;
        }
    }
}