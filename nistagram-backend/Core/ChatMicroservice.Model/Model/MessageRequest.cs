using CSharpFunctionalExtensions;
using System;

namespace ChatMicroservice.Core.Model
{
    public class MessageRequest : Message
    {
        private readonly bool isApproved;

        public MessageRequest(Guid id, DateTime timeStamp, MessageContent messageContent, Chat chat, bool isApproved) : base(id, timeStamp, messageContent, chat)
        {
            this.isApproved = isApproved;
        }

        public static Result<MessageRequest> Create(Guid id, DateTime timeStamp, MessageContent messageContent, Chat chat, bool isApproved)
        {
            return Result.Success(new MessageRequest(id, timeStamp, messageContent, chat, isApproved));
        }
    }
}