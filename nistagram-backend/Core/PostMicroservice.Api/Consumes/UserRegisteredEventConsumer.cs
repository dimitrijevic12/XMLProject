using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using PostMicroservice.Core.Model;
using PostMicroservice.Core.Services;
using Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PostMicroservice.Api.Consumes
{
    public class UserRegisteredEventConsumer : IConsumeAsync<UserRegisteredEvent>
    {
        private readonly UserService userService;
        private readonly IBus _bus;

        public UserRegisteredEventConsumer(UserService userService, IBus bus)
        {
            this.userService = userService;
            _bus = bus;
        }

        public async Task ConsumeAsync(UserRegisteredEvent message, CancellationToken cancellationToken = default)
        {
            var result = await userService.CreateRegistrationAsync(Convert(message));
            if (result.IsSuccess)
            {
                await _bus.PubSub.PublishAsync(new PostUserRegisteredEvent
                {
                    Id = message.Id.ToString(),
                    Username = message.Username,
                    FirstName = message.FirstName,
                    LastName = message.LastName,
                    IsPrivate = message.IsPrivate,
                    IsAcceptingTags = message.IsAcceptingTags,
                    ProfilePicturePath = message.ProfileImagePath.ToString(),
                    BlockedByUsers = new List<string>(),
                    BlockedUsers = new List<string>(),
                    Following = CreateIds(message.Following),
                    Followers = CreateIds(message.Followers),
                    MyCloseFriends = new List<string>(),
                    CloseFriendTo = new List<string>(),
                });
            }
            else
            {
                await _bus.PubSub.PublishAsync(new UnsuccessfulPostUserRegistrationEvent
                {
                    Id = message.Id,
                });
            }
        }

        public List<string> CreateIds(IEnumerable<UserRegisteredEvent> registeredUsers)
        {
            var test = registeredUsers.Select(registeredUser => registeredUser.Id.ToString()).ToList();
            return test;
        }

        private RegisteredUser Convert(UserRegisteredEvent message)
        {
            return RegisteredUser.Create(message.Id,
                                           Username.Create(message.Username).Value,
                                           FirstName.Create(message.FirstName).Value,
                                           LastName.Create(message.LastName).Value,
                                           ProfileImagePath.Create(message.ProfileImagePath).Value,
                                           message.IsPrivate,
                                           message.IsAcceptingTags,
                                           new List<RegisteredUser>(),
                                           new List<RegisteredUser>(),
                                           new List<RegisteredUser>(),
                                           new List<RegisteredUser>()).Value;
        }
    }
}