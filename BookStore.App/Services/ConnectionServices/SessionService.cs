using System.Text.Json;
using BookStore.App.Services.ConnectionServices.Interfaces;

namespace BookStore.App.Services.ConnectionServices
{
    public class SessionService : ISessionService
    {
        private const string ChangeName = "IsChange";

        public void SetCeateStatus(HttpContext context) => Set<bool>(context, ChangeName, true);

        public void SetChangeStatus(HttpContext context) => Set<bool>(context, ChangeName, false);

        private void Set<T>(HttpContext context, string key, T value)
        {
            context.Session.SetString(key, JsonSerializer.Serialize<T>(value));
        }

        private T? Get<T>(HttpContext context, string key)
        {
            var result = context.Session.GetString(key);
            return result == null ? default(T) : JsonSerializer.Deserialize<T>(result);
        }

    }
}
