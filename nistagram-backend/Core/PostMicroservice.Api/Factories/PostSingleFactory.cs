using PostMicroservice.Api.DTOs;
using System.Collections.Generic;

namespace PostMicroservice.Api.Factories
{
    public class PostSingleFactory
    {
        private readonly RegisteredUserFactory registeredUserFactory;
        private readonly LocationFactory locationFactory;

        public PostSingleFactory(RegisteredUserFactory registeredUserFactory, LocationFactory locationFactory)
        {
            this.registeredUserFactory = registeredUserFactory;
            this.locationFactory = locationFactory;
        }

        public PostSingle Create(Core.Model.PostSingle post)
        {
            return new PostSingle
            {
                Id = post.Id,
                TimeStamp = post.TimeStamp,
                Description = post.Description,
                RegisteredUser = registeredUserFactory.Create(post.RegisteredUser),
                Likes = new List<RegisteredUser>(),
                Dislikes = new List<RegisteredUser>(),
                Location = locationFactory.Create(post.Location),
                HashTags = new List<string>(),
                ContentPath = post.ContentPath
            };
        }
    }
}