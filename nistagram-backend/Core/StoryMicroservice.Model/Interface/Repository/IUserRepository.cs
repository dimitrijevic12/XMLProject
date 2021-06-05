using StoryMicroservice.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryMicroservice.Core.Interface.Repository
{
    public interface IUserRepository : IRepository<Core.Model.RegisteredUser>
    {
        public IEnumerable<Core.Model.RegisteredUser> GetUsersById(List<string> ids);

        public IEnumerable<Core.Model.RegisteredUser> GetUsersByDTO(List<RegisteredUser> users);

        public IEnumerable<Core.Model.RegisteredUser> GetBy(string isTaggable);
    }
}