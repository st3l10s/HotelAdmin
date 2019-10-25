using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Repositories;
using WebApi.Persistence.Contexts;

namespace WebApi.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelAdminContext _context;

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public UnitOfWork(HotelAdminContext context)
        {
            _context = context;
        }
    }
}
