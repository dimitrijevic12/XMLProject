using CSharpFunctionalExtensions;
using StoryMicroservice.Core.Interface.Repository;
using StoryMicroservice.Core.Model;
using StoryMicroservice.Core.Model.FileModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryMicroservice.Core.Services
{
    public class StoryService
    {
        private readonly IStoryRepository _storyRepository;

        public StoryService(IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        public Result Create(Story story)
        {
            if (_storyRepository.GetById(story.Id).HasValue) return Result.Failure("Story with that Id already exists.");
            _storyRepository.Save(story);
            return Result.Success(story);
        }

        public string ImageToSave(string path, FileModel file)
        {
            try
            {
                using (Stream stream = new FileStream(path + "\\images\\" + file.FileName, FileMode.Create))
                {
                    file.FormFile.CopyTo(stream);
                }
                return file.FileName;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public byte[] GetImage(string path, string fileName)
        {
            path = path + "\\images\\" + fileName;
            return File.ReadAllBytes(path);
        }
    }
}