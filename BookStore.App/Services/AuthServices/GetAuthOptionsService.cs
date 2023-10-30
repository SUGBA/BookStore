using BookStore.App.Data.Auth;
using BookStore.App.Services.AuthServices.Interfaces;
using Microsoft.Extensions.Options;

namespace BookStore.App.Services.AuthServices
{
    public class GetAuthOptionsService : IGetAuthOptionsService
    {
        private readonly IOptions<AuthOptions> _options;

        public GetAuthOptionsService(IOptions<AuthOptions> options)
        {
            _options = options;
        }

        public AuthOptions? GetAuthOptions() => _options.Value;
    }
}
