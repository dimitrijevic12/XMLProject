using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace PostMicroservice.Core.Model
{
    public class PostAlbum
    {
        private readonly Guid id;
        private readonly List<ContentPath> contentPaths;
        private readonly DateTime timeStamp;
        private Description description;
        private RegisteredUser registeredUser;
        private readonly IEnumerable<RegisteredUser> likes;
        private readonly IEnumerable<RegisteredUser> dislikes;
        private readonly IEnumerable<Comment> comments;
        private readonly Location location;

        private PostAlbum(Guid id, List<ContentPath> contentPaths, DateTime timeStamp, Description description,
            RegisteredUser registeredUser, IEnumerable<RegisteredUser> likes,
            IEnumerable<RegisteredUser> dislikes, IEnumerable<Comment> comments, Location location)
        {
            this.id = id;
            this.contentPaths = contentPaths;
            this.timeStamp = timeStamp;
            this.description = description;
            this.registeredUser = registeredUser;
            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = comments;
            this.location = location;
        }

        public static Result<PostAlbum> Create(Guid id, List<ContentPath> contentPaths, DateTime timeStamp, Description description,
            RegisteredUser registeredUser, IEnumerable<RegisteredUser> likes,
            IEnumerable<RegisteredUser> dislikes, IEnumerable<Comment> comments, Location location)
        {
            return Result.Success(new PostAlbum(id, contentPaths, timeStamp, description,
                                registeredUser, likes, dislikes, comments, location));
        }
    }
}