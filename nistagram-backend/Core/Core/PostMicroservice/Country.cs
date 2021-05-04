using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace Core.PostMicroservice
{
    public class Country : ValueObject
    {
        private readonly string name;

        private Country(string name)
        {
            this.name = name;
        }

        public static Result<Country> Create(string name)
        {
            if (String.IsNullOrWhiteSpace(name)) return Result.Failure<Country>("Country cannot be empty, or contain only white spaces");
            if (name.Length > 50) return Result.Failure<Country>("Country cannot contain more than 50 characters");
            return Result.Success(new Country(name));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return name;
        }

        public static implicit operator string(Country Country) => Country.name;
    }
}