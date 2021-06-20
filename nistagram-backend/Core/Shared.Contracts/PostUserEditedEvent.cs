using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts
{
    public class PostUserEditedEvent
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
    }
}