using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryMicroservice.Api.DTOs
{
    public class RegisteredUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Boolean isPrivate { get; set; }
        public Boolean isAcceptingTags { get; set; }
    }
}