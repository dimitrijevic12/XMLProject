using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Api.DTOs;

namespace UserMicroservice.Api.Factories
{
    public class AgentRequestFactory
    {
        private readonly RegisteredUserFactory registeredUserFactory;

        public AgentRequestFactory(RegisteredUserFactory registeredUserFactory)
        {
            this.registeredUserFactory = registeredUserFactory;
        }

        public AgentRequest Create(Core.Model.AgentRequest agentRequest)
        {
            return new AgentRequest
            {
                Id = agentRequest.Id,
                IsApproved = agentRequest.IsApproved,
                RegisteredUser = registeredUserFactory.Create(agentRequest.RegisteredUser)
            };
        }

        public IEnumerable<AgentRequest> CreateAgentRequests(IEnumerable<Core.Model.AgentRequest> agentRequests)
        {
            return agentRequests.Select(agentRequest => Create(agentRequest)).ToList();
        }
    }
}