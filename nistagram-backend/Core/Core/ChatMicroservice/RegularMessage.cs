using CSharpFunctionalExtensions;
using System;

namespace Core.ChatMicroservice
{
    public class RegularMessage : Message
    {
        public RegularMessage(Guid id, DateTime timeStamp, MessageContent messageContent, Chat chat) : base(id, timeStamp, messageContent, chat)
        {
        }

        public static new Result<RegularMessage> Create(Guid id, DateTime timeStamp, MessageContent messageContent, Chat chat)
        {
            return Result.Success(new RegularMessage(id, timeStamp, messageContent, chat));
        }
    }
}