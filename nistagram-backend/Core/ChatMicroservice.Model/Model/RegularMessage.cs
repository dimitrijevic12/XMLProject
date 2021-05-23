using CSharpFunctionalExtensions;
using System;

namespace ChatMicroservice.Core.Model
{
    public class RegularMessage : Message
    {
        public RegularMessage(Guid id, DateTime timeStamp, MessageContent messageContent, RegisteredUser messageReceiver, RegisteredUser messageSender) : base(id, timeStamp, messageContent, messageReceiver, messageSender)
        {
        }

        public static new Result<RegularMessage> Create(Guid id, DateTime timeStamp, MessageContent messageContent, RegisteredUser messageReceiver, RegisteredUser messageSender)
        {
            return Result.Success(new RegularMessage(id, timeStamp, messageContent, messageReceiver, messageSender));
        }
    }
}