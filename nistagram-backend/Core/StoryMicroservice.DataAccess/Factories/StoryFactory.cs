using StoryMicroservice.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Story = StoryMicroservice.Core.DTOs.Story;

namespace StoryMicroservice.DataAccess.Factories
{
    public class StoryFactory
    {
        private readonly RegisteredUserFactory registeredUserFactory;
        private readonly LocationFactory locationFactory;
        private readonly HashTagFactory hashTagFactory;

        public StoryFactory(RegisteredUserFactory registeredUserFactory, LocationFactory locationFactory, HashTagFactory hashTagFactory)
        {
            this.registeredUserFactory = registeredUserFactory;
            this.locationFactory = locationFactory;
            this.hashTagFactory = hashTagFactory;
        }

        public Story Create(Core.Model.Story story)
        {
            return new Story
            {
                Id = story.Id.ToString(),
                TimeStamp = story.TimeStamp,
                Description = story.Description,
                RegisteredUser = registeredUserFactory.Create(story.RegisteredUser),
                Location = locationFactory.Create(story.Location),
                TaggedUsers = registeredUserFactory.CreateUsers(story.TaggedUsers),
                HashTags = hashTagFactory.CreateHashTags(story.HashTags),
                ContentPath = story.ContentPath.ToString(),
                Duration = story.Duration,
                Type = story.GetType().Name
            };
        }

        public Core.Model.Story Create(Story story, IEnumerable<Core.Model.RegisteredUser> taggedUsers)
        {
            return Core.Model.Story.Create(new Guid(story.Id), ContentPath.Create(story.ContentPath).Value,
                story.TimeStamp,
                Duration.Create(story.Duration).Value, Description.Create(story.Description).Value, registeredUserFactory.Create(story.RegisteredUser,
                new List<Core.Model.RegisteredUser>(), new List<Core.Model.RegisteredUser>(), new List<Core.Model.RegisteredUser>(),
                new List<Core.Model.RegisteredUser>(), new List<Core.Model.RegisteredUser>(), new List<Core.Model.RegisteredUser>()),
                locationFactory.Create(story.Location), taggedUsers,
                hashTagFactory.CreateHashTags(story.HashTags)).Value;
        }

        public List<Story> CreateStories(IEnumerable<Core.Model.Story> stories)
        {
            return stories.Select(story => Create(story)).ToList();
        }

        public IEnumerable<Core.Model.Story> CreateStories(List<Story> stories)
        {
            return stories.Select(story => Create(story, new List<Core.Model.RegisteredUser>())).ToList();
        }
    }
}