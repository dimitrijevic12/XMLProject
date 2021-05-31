using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMicroservice.Core.Model;

namespace UserMicroservice.Core.Interface.Repository
{
    public interface IUserRepository : IRepository<RegisteredUser>
    {
        public Maybe<RegisteredUser> GetByUsername(String username);
    }
}