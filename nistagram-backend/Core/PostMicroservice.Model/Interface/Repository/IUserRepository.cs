using PostMicroservice.Core.Model;
using System.Collections.Generic;

namespace PostMicroservice.Core.Interface.Repository
{
    public interface IUserRepository : IRepository<RegisteredUser>
    {
        public IEnumerable<RegisteredUser> GetTaggable();
    }
}