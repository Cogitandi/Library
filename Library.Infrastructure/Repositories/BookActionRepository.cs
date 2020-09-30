using Library.Core;
using Library.Core.Domain;
using Library.Core.Repositories;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class BookActionRepository : IBookActionRepository
    {
        private readonly DatabaseContext _context;

        public BookActionRepository(DatabaseContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Asynchronously return all book actions associated with the user
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        public async Task<IEnumerable<BookAction>> GetByUserId(Guid id)
        {
            return await _context.BookActions
                .Where(x=>x.User.Id==id)
                .Include(x => x.Book)
                .ToListAsync();
        }
    }
}
