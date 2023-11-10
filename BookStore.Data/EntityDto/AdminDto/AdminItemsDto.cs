using Microsoft.AspNetCore.Http;

namespace BookStore.Data.EntityDto.AdminDto
{
    public class AdminItemsDto<T>
    {
        public List<BaseAdminItemDto> Items { get; set; } = new();

        public T ActiveItem { get; set; }

        public IFormFile? File { get; set; }

        public int SelectedId { get; set; }

        public string IsCreatedMessage
        {
            get { return SelectedId == default(int) ? "Создание элемента" : "Изменение элемента"; }
        }
    }
}
