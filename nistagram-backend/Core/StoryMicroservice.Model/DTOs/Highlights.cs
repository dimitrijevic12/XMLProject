﻿using System.Collections.Generic;

namespace StoryMicroservice.Core.DTOs
{
    public class Highlights
    {
        public string Guid { get; set; }

        public string HighlightName { get; set; }
        public List<Story> Stories { get; set; }
        public RegisteredUser RegisteredUser { get; set; }
    }
}