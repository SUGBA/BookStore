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

        private string GetDefaultPath() => $"{_directoryPath}/shreImage/logo.png";

        public async Task<string> AddAndGetPath<T>(IFormFile? AnswerFile) where T : IEntity
        {
            if (CheclFile(AnswerFile))
            {
                var path = PathCreater(typeof(T), AnswerFile!.FileName);
                if (path is not null)
                {
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await AnswerFile.CopyToAsync(fileStream);
                    }
                    return path;
                }
            }
            return GetDefaultPath();
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
            return AnswerFile != null && (AnswerFile.ContentType == "image/png" || AnswerFile.ContentType == "image/jpeg");
        }
    }
}
