using System.IO;
using BookStore.Admin.Entity;
using BookStore.App.Services.FileService.Interfaces;
using BookStore.Catalog.Entity;
using BookStore.Data.Entity;
using BookStore.News.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookStore.App.Services.FileService
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _appEnvironment;

        private const string _directoryPath = "/images";

        public FileService(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public async Task<bool> AddFile<T>(IFormFile? AnswerFile) where T : IEntity
        {
            if (CheclFile(AnswerFile))
            {
                var path = PathCreater(typeof(T), AnswerFile!.FileName);
                if (path is not null)
                {
                    FileMode mode = Directory.Exists(path) ? FileMode.CreateNew : FileMode.Open;

                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, mode))
                    {
                        await AnswerFile.CopyToAsync(fileStream);
                    }
                    return true;
                }
            }
            return false;
        }

        private string? PathCreater(Type T, string fileName)
        {
            if (T == typeof(StoreEntity))
                return $"{_directoryPath}/catalogImages/{fileName}";
            if (T == typeof(NewsEntity))
                return $"{_directoryPath}/newsImages/{fileName}";
            return null;
        }

        private bool CheclFile(IFormFile? AnswerFile)
        {
            return AnswerFile != null && AnswerFile.ContentType == "image/png";
        }
    }
}
