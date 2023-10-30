using BookStore.App.Data.Auth;

namespace BookStore.App.Services.AuthServices.Interfaces
{
    public interface IGetAuthOptionsService
    {
        public AuthOptions? GetAuthOptions();
    }
}
