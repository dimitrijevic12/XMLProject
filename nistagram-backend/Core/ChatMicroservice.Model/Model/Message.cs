using CSharpFunctionalExtensions;
using System;

namespace ChatMicroservice.Core.Model
{
    public class Message
    {
        private readonly Guid id;
        private readonly DateTime timeStamp;
        private readonly MessageContent messageContent;
        private readonly Chat chat;

        public Message(Guid id, DateTime timeStamp, MessageContent messageContent, Chat chat)
        {
            this.id = id;
            this.timeStamp = timeStamp;
            this.messageContent = messageContent;
            this.chat = chat;
        }

        public static Result<Message> Create(Guid id, DateTime timeStamp, MessageContent messageContent, Chat chat)
        {
            return Result.Success(new Message(id, timeStamp, messageContent, chat));
        }
    }
}