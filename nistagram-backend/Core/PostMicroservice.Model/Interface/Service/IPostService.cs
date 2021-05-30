using PostMicroservice.Core.Model;
using System;
using System.Collections.Generic;

namespace PostMicroservice.Core.Interface.Service
{
    public interface IPostService : IService<Post>
    {
        public IEnumerable<Post> GetByUserId(Guid id);
    }
}