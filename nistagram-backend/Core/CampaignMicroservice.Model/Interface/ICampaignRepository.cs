﻿using CampaignMicroservice.Core.Model;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace CampaignMicroservice.Core.Interface
{
    public interface ICampaignRepository
    {
        public void Save(Campaign campaign);

        public void Update(Campaign campaign);

        public void Remove(Guid id);

        public Maybe<Campaign> GetById(Guid id);

        public IEnumerable<Campaign> GetBy(Guid agentId, Guid clientId);
    }
}