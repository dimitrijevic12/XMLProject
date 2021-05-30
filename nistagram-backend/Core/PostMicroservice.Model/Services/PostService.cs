using PostMicroservice.Core.Interface.Repository;
using PostMicroservice.Core.Interface.Service;
using PostMicroservice.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PostMicroservice.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public Post GetById(Guid id)
        {
            return _postRepository.GetById(id);
        }

        public Post Save(Post obj)
        {
            throw new NotImplementedException();
        }

        public Post Edit(Post obj)
        {
            throw new NotImplementedException();
        }

        public Post Delete(Post obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetByUserId(Guid id)
        {
            return _postRepository.GetByUserId(id);
        }
    }
}