using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Admin.Entity;

namespace BookStore.Data.EntityDto.AdminDto
{
    public class AdminItemsDto<T>
    {
        public List<T> Items { get; set; } = new();

        public T ActiveItem { get; set; }
    }
}
