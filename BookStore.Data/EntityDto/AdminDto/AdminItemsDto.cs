namespace BookStore.Data.EntityDto.AdminDto
{
    public class AdminItemsDto<T>
    {
        public List<T> Items { get; set; } = new();

        public T ActiveItem { get; set; }

        public bool IsCreated { get; set; }

        public string IsCreatedMessage
        {
            get { return IsCreated ? "Создание элемента" : "Изменение элемента"; }
        }
    }
}
