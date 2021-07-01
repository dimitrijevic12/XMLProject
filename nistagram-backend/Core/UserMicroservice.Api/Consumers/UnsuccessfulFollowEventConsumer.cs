using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UserMicroservice.Core.Interface.Repository;
using UserMicroservice.Core.Services;

namespace UserMicroservice.Api.Consumers
{
    public class UnsuccessfulFollowEventConsumer : IConsumeAsync<UnsuccessfulFollowEvent>
    {
        private readonly UserService userService;
        private readonly IUserRepository _userRepository;
        private readonly IBus _bus;

        public UnsuccessfulFollowEventConsumer(UserService userService, IBus bus, IUserRepository userRepository)
        {
            this.userService = userService;
            _userRepository = userRepository;
            _bus = bus;
        }

        public async Task ConsumeAsync(UnsuccessfulFollowEvent message, CancellationToken cancellationToken = default)
        {
            await userService.RejectFollowAsync(message.FollowedById, message.FollowingId, "Unsuccessful following atempt!");
        }
    }
}