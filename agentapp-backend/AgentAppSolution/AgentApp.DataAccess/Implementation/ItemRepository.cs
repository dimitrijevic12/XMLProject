using AgentApp.Core.Interface.Repository;
using AgentApp.Core.Model;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentApp.DataAccess.Implementation
{
    public class ItemRepository : Repository, IItemRepository
    {
        public ItemRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item Edit(Item obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetAll()
        {
            throw new NotImplementedException();
        }

        public Maybe<Item> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item Save(Item obj)
        {
            throw new NotImplementedException();
        }
    }
}