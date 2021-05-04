using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace Core.PostMicroservice
{
    public class PostAlbum
    {
        private readonly Guid id;
        private readonly ContentPath contentPath;
        private readonly DateTime timeStamp;
        private Description description;
        private RegisteredUser registeredUser;

        private PostAlbum(Guid id, ContentPath contentPath, DateTime timeStamp, Description description,
            RegisteredUser registeredUser)
        {
            this.id = id;
            this.contentPath = contentPath;
            this.timeStamp = timeStamp;
            this.description = description;
            this.registeredUser = registeredUser;
        }

        public static Result<PostAlbum> Create(Guid id, ContentPath contentPath, DateTime timeStamp,
            Description description, RegisteredUser registeredUser)
        {
            return Result.Success(new PostAlbum(id, contentPath, timeStamp, description, registeredUser));
        }
    }
}