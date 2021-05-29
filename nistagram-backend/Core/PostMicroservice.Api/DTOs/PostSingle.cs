using System;
using System.Collections.Generic;

namespace PostMicroservice.Api.DTOs
{
    public class PostSingle
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Description { get; set; }
        public RegisteredUser RegisteredUser { get; set; }
        public IEnumerable<RegisteredUser> Likes { get; set; }
        public IEnumerable<RegisteredUser> Dislikes { get; set; }
        public Location Location { get; set; }
        public IEnumerable<string> HashTags { get; set; }
        public string ContentPath { get; set; }
    }
}