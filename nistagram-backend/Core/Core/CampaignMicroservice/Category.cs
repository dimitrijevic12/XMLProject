﻿using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace Core.CampaignMicroservice
{
    public class Category : ValueObject
    {
        private readonly string name;

        private Category(string name)
        {
            this.name = name;
        }

        public static Result<Category> Create(string name)
        {
            if (String.IsNullOrWhiteSpace(name)) return Result.Failure<Category>("Category cannot be empty, or contain only white spaces");
            if (name.Length > 20) return Result.Failure<Category>("Category cannot contain more than 20 characters");
            return Result.Success(new Category(name));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return name;
        }

        public static implicit operator string(Category category) => category.name;
    }
}