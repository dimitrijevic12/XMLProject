using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts
{
    public class StoryUserEditedEvent
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImagePath { get; set; }
        public Boolean IsPrivate { get; set; }
        public Boolean IsAcceptingTags { get; set; }
        public IEnumerable<StoryUserEditedEvent> Following { get; set; }
        public IEnumerable<StoryUserEditedEvent> Followers { get; set; }
    }
}