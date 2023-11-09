using System.Text.Json;
using BookStore.App.Services.ConnectionServices.Interfaces;

namespace BookStore.App.Services.ConnectionServices
{
    public class SessionService : ISessionService
    {
        private const string ChangeName = "IsCreated";

        public int GetId(HttpContext context) => Get<int>(context, ChangeName);

        public void ClearSelectedItem(HttpContext context) => Set<int>(context, ChangeName, default(int));

        public void SetSelectedItem(HttpContext context, int id) => Set<int>(context, ChangeName, id);

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
