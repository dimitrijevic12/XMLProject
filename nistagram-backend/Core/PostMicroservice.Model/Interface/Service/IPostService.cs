using PostMicroservice.Core.Model;
using PostMicroservice.Core.Model.File;
using System;
using System.Collections.Generic;
using System.IO;

namespace PostMicroservice.Core.Interface.Service
{
    public interface IPostService : IService<Post>
    {
        public IEnumerable<Post> GetByUserId(Guid id);

        public byte[] GetImage(string path, string fileName);

        public Post SaveSinglePost(PostSingle post);

        string ImageToSave(string path, FileModel file);

        public void Like(Guid id, Guid userId);

        public void Dislike(Guid id, Guid userId);

        public void CommentPost(Guid postId, Comment comment);
    }
}