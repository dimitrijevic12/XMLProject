using CSharpFunctionalExtensions;
using System;

namespace ChatMicroservice.Core.Model
{
    public class Content : MessageContent
    {
        private readonly Guid id;
        private readonly DateTime timestamp;

        public Content(Guid id, DateTime timestamp)
        {
            this.id = id;
            this.timestamp = timestamp;
        }

        public static Result<Content> Create(Guid id, DateTime timestamp)
        {
            return Result.Success(new Content(id, timestamp));
        }
    }
}