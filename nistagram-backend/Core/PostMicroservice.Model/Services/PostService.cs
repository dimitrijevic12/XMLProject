using PostMicroservice.Core.Interface.Repository;
using PostMicroservice.Core.Interface.Service;
using PostMicroservice.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace PostMicroservice.Core.Services
{
    public class PostService
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

        public Post Save(Post post)
        {
            return _postRepository.Save(post);
        }

        public Post Edit(Post post)
        {
            throw new NotImplementedException();
        }

        public Post Delete(Post post)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetByUserId(Guid id)
        {
            return _postRepository.GetBy(id, "", "");
        }

        public byte[] GetImage(string path, string fileName)
        {
            path = path + "\\images\\" + fileName;
            return File.ReadAllBytes(path);
        }

        public Post SaveSinglePost(PostSingle post)
        {
            return _postRepository.SaveSinglePost(post);
        }
    }
}