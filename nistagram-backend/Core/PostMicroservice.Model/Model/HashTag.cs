using CSharpFunctionalExtensions;

namespace PostMicroservice.Core.Model
{
    public class HashTag
    {
        private readonly HashTagText hashTagText;

        private HashTag(HashTagText hashTagText)
        {
            this.hashTagText = hashTagText;
        }

        public static Result<HashTag> Create(HashTagText hashTagText)
        {
            return Result.Success(new HashTag(hashTagText));
        }
    }
}