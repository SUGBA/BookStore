using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.EF.Context;
using BookStore.EF.Repository.Interfaces;

namespace BookStore.EF.Repository
{
    public class NewsRepositrory : INewsRepositrory
    {
        private readonly BookStoreContext _context;

        public NewsRepositrory(BookStoreContext context)
        {
            _context = context;
        }
    }
}
