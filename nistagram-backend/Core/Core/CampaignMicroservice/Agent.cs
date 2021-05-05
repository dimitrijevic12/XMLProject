using CSharpFunctionalExtensions;
using System;

namespace Core.CampaignMicroservice
{
    public class Agent
    {
        private readonly Guid id;

        private Agent(Guid id)
        {
            this.id = id;
        }

        public static Result<Agent> Create(Guid id)
        {
            return Result.Success(new Agent(id));
        }
    }
}