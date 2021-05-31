using PostMicroservice.Core.Model;
using System;
using System.Collections.Generic;

namespace PostMicroservice.Core.Interface.Service
{
    public interface IPostService : IService<Post>
    {
        public IEnumerable<Post> GetByUserId(Guid id);

        public byte[] GetImage(string path, string fileName);

        public Post SaveSinglePost(PostSingle post);
    }
}