using BookStore.Data.Entity;
using Microsoft.AspNetCore.Http;

namespace BookStore.App.Services.FileService.Interfaces
{
    public interface IFileService
    {
        public Task<bool> AddFile<T>(IFormFile? AnswerFile) where T : IEntity;
    }
}
