using System.Security.Cryptography;

namespace BookStore.App.Services.ConnectionServices.Interfaces
{
    public interface ISessionService
    {
        /// <summary>
        /// Установка IsChange в true
        /// </summary>
        /// <param name="context"></param>
        public void SetChangeStatus(HttpContext context);

        /// <summary>
        /// Установка IsChange в false
        /// </summary>
        /// <param name="context"></param>
        public void SetCeateStatus(HttpContext context);

        /// <summary>
        /// Получить значение IsChange из сессии
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool GetStatus(HttpContext context);
    }
}
