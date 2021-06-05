using CSharpFunctionalExtensions;
using MongoDB.Driver;
using StoryMicroservice.Core.DTOs;
using StoryMicroservice.Core.Interface.Repository;
using StoryMicroservice.DataAccess.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryMicroservice.DataAccess.Implementation
{
    public class HighlightRepository : IHighlightRepositry
    {
        private readonly IMongoCollection<Highlights> _highlights;
        private readonly HighlightFactory highlightFactory;

        public HighlightRepository(IStoryDatabaseSettings settings, HighlightFactory highlightFactory)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _highlights = database.GetCollection<Highlights>(settings.HighlightsCollectionName);
            this.highlightFactory = highlightFactory;
        }

        public void Delete(Core.Model.Highlights obj)
        {
            throw new NotImplementedException();
        }

        public Core.Model.Highlights Edit(string id, Core.Model.Highlights obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Model.Highlights> GetAll()
        {
            throw new NotImplementedException();
        }

        public Maybe<Core.Model.Highlights> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Core.Model.Highlights Save(Core.Model.Highlights highlight)
        {
            _highlights.InsertOne(highlightFactory.Create(highlight));
            return highlight;
        }

        public IEnumerable<Core.Model.Highlights> GetBy(string ownerId)
        {
            List<Core.Model.Highlights> highlights = new List<Core.Model.Highlights>();
            if (!String.IsNullOrWhiteSpace(ownerId))
            {
                highlights = highlightFactory.CreateHighlights(_highlights.Find(highlight => highlight.RegisteredUser.Id.Equals(ownerId)).ToList())
                    .ToList();
            }
            return highlights;
        }
    }
}