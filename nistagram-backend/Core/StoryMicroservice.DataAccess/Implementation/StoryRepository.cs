using CSharpFunctionalExtensions;
using MongoDB.Driver;
using StoryMicroservice.Core.DTOs;
using StoryMicroservice.Core.Interface.Repository;
using StoryMicroservice.DataAccess.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoryMicroservice.DataAccess.Implementation
{
    public class StoryRepository : IStoryRepository
    {
        private readonly IMongoCollection<Story> _stories;
        private readonly IUserRepository _userRepository;
        private readonly StoryFactory storyFactory;
        private readonly RegisteredUserFactory userFactory;

        public StoryRepository(IStoryDatabaseSettings settings, IUserRepository userRepository, StoryFactory storyFactory,
            RegisteredUserFactory userFactory)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _stories = database.GetCollection<Story>(settings.StoriesCollectionName);
            this.storyFactory = storyFactory;
            this.userFactory = userFactory;
            _userRepository = userRepository;
        }

        public IEnumerable<Core.Model.Story> GetAll()
        {
            var stories = _stories.Find(story => true).ToList();
            return stories.Select(story => GetById(new Guid(story.Id)).Value);
        }

        public Maybe<Core.Model.Story> GetById(Guid id)
        {
            var storyDTO = _stories.Find<Story>(story => story.Id.Equals(id)).FirstOrDefault();
            if (storyDTO == null) return Maybe<Core.Model.Story>.None;
            var taggedUsers = _userRepository.GetUsersByDTO(storyDTO.TaggedUsers);
            return storyFactory.Create(storyDTO, taggedUsers);
        }

        public Core.Model.Story Save(Core.Model.Story story)
        {
            _stories.InsertOne(storyFactory.Create(story));
            return story;
        }

        public Core.Model.Story Edit(string id, Core.Model.Story storyIn)
        {
            _stories.ReplaceOne(story => story.Id == id, storyFactory.Create(storyIn));
            return storyIn;
        }

        public void Delete(Core.Model.Story storyIn)
        {
            _stories.DeleteOne(story => story.Id.Equals(storyIn.Id));
        }

        public IEnumerable<Core.Model.Story> GetBy(string storyOwnerId, string followingId)
        {
            List<Core.Model.Story> stories = new List<Core.Model.Story>();
            if (!String.IsNullOrWhiteSpace(storyOwnerId))
                stories.AddRange(storyFactory.CreateStories(_stories.Find(story => story.RegisteredUser.Id.Equals(storyOwnerId)).ToList()));
            if (!String.IsNullOrWhiteSpace(followingId))
            {
                var user = _userRepository.GetById(new Guid(followingId)).Value;
                var followingUsers = userFactory.CreateIds(user.Following);
                stories.AddRange(storyFactory.CreateStories(_stories.Find(story => followingUsers.Contains(story.RegisteredUser.Id)).ToList()));
            }
            return stories;
        }
    }
}