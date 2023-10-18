using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.EF.Context;
using BookStore.EF.Repository.Interfaces;

namespace BookStore.EF.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly BookStoreContext _context;

        public ManagerRepository(BookStoreContext context)
        {
            _context = context;
        }
    }
}
