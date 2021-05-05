using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace Core.ChatMicroservice
{
    public class Chat
    {
        private readonly Guid id;
        private readonly IEnumerable<RegisteredUser> users;

        private Chat(Guid id, IEnumerable<RegisteredUser> users)
        {
            this.id = id;
            this.users = users;
        }

        public static Result<Chat> Create(Guid id, IEnumerable<RegisteredUser> users)
        {
            return Result.Success(new Chat(id, users));
        }
    }
}