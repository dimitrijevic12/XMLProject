using CSharpFunctionalExtensions;
using System;

namespace Core.ChatMicroservice
{
    internal class Campaign : Content
    {
        private Campaign(Guid id, DateTime timestamp) : base(id, timestamp)
        {
        }

        public static Result<Campaign> Create(Guid id, DateTime timestamp)
        {
            return Result.Success(new Campaign(id, timestamp));
        }
    }
}