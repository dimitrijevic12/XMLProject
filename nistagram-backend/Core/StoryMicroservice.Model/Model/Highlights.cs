using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace StoryMicroservice.Core.Model
{
    public class Highlights
    {
        private readonly Guid id;
        private readonly HighlightName highlightName;
        private readonly IEnumerable<Story> stories;

        public Highlights(Guid id, HighlightName highlightName, IEnumerable<Story> stories)
        {
            this.id = id;
            this.highlightName = highlightName;
            this.stories = stories;
        }

        public static Result<Highlights> Create(Guid id, HighlightName highlightName, IEnumerable<Story> stories)
        {
            return Result.Success(new Highlights(id, highlightName, stories));
        }
    }
}