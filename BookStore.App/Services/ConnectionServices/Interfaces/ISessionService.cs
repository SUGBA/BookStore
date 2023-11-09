using System.Security.Cryptography;

namespace BookStore.App.Services.ConnectionServices.Interfaces
{
    public interface ISessionService
    {
        /// <summary>
        /// Установка IsCreated в false
        /// </summary>
        /// <param name="context"></param>
        public void ClearSelectedItem(HttpContext context);

        /// <summary>
        /// Установка IsCreated в true
        /// </summary>
        /// <param name="context"></param>
        public void SetSelectedItem(HttpContext context, int id);

        /// <summary>
        /// Получить значение IsChange из сессии
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public int GetId(HttpContext context);
    }
}
