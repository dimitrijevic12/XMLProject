using CSharpFunctionalExtensions;
using System.Collections.Generic;
using System.IO;

namespace UserMicroservice.Core.Model
{
    public class DocumentImagePath : ValueObject
    {
        private readonly string path;

        private DocumentImagePath(string path)
        {
            this.path = path;
        }

        public static Result<DocumentImagePath> Create(string path)
        {
            if (!File.Exists(path)) return Result.Failure<DocumentImagePath>("Image does not exist on given path");
            return Result.Success(new DocumentImagePath(path));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return path;
        }

        public static implicit operator string(DocumentImagePath DocumentImagePath) => DocumentImagePath.path;
    }
}