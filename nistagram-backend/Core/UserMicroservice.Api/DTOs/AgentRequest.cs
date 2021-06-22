using System;

namespace UserMicroservice.Api.DTOs
{
    public class AgentRequest
    {
        public Guid Id { get; set; }
        public bool IsApproved { get; set; }
        public RegisteredUser RegisteredUser { get; set; }
    }
}