using PostMicroservice.Core.Model;
using System;
using System.Collections.Generic;

namespace PostMicroservice.Core.Interface.Repository
{
    public interface IPostRepository : IRepository<Post>
    {
        public IEnumerable<Post> GetByUserId(Guid id);
    }
}