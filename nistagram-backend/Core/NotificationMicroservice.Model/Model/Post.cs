﻿using CSharpFunctionalExtensions;
using System;

namespace NotificationMicroservice.Core.Model
{
    public class Post : Content
    {
        private Post(Guid id) : base(id)
        {
        }

        public static Result<Post> Create(Guid id)
        {
            return Result.Success(new Post(id));
        }
    }
}