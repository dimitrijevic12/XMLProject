using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace Core.PostMicroservice
{
    public class Street : ValueObject
    {
        private readonly string name;

        private Street(string name)
        {
            this.name = name;
        }

        public static Result<Street> Create(string name)
        {
            if (String.IsNullOrWhiteSpace(name)) return Result.Failure<Street>("Street cannot be empty, or contain only white spaces");
            if (name.Length > 50) return Result.Failure<Street>("Street cannot contain more than 50 characters");
            return Result.Success(new Street(name));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return name;
        }

        public static implicit operator string(Street Street) => Street.name;
    }
}