using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using NotificationMicroservice.Core.Model;
using NotificationMicroservice.Core.Services;
using Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationMicroservice.Api.Consumers
{
    public class ReportUserEditedEventConsumer : IConsumeAsync<ReportUserEditedEvent>
    {
        private readonly RegisteredUserService userService;
        private readonly IBus _bus;

        public ReportUserEditedEventConsumer(RegisteredUserService userService, IBus bus)
        {
            this.userService = userService;
            _bus = bus;
        }

        public async Task ConsumeAsync(ReportUserEditedEvent message, CancellationToken cancellationToken = default)
        {
            var result = await userService.CreateEditAsync(Convert(message));
            if (result.IsSuccess)
            {
                /* await _bus.PubSub.PublishAsync(new ReportUserEditedEvent
                 {
                     Id = message.Id,
                     Username = message.Username
                 });*/
            }
            else
            {
                /*await _bus.PubSub.PublishAsync(new UnsuccessfulNotificationUserRegistrationEvent
                {
                    Id = message.Id,
                });*/
            }
        }

        private RegisteredUser Convert(ReportUserEditedEvent message)
        {
            return RegisteredUser.Create(message.Id,
                                           Username.Create(message.Username).Value,
                                           NotificationOptions.Create(message.Id, true, true, true, true, true).Value,
                                           ProfilePicturePath.Create("").Value).Value;
        }
    }
}