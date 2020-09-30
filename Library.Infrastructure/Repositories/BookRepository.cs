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
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseContext _context;

        public BookRepository(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Asynchronously return book if found or null
        /// </summary>
        /// <param name="id">Book id</param>
        /// <returns></returns>
        public async Task<Book> GetById(Guid id)
        {
            return await _context.Books
                .Include(x => x.Actions)
                .ThenInclude(y=>y.User)
                .FirstOrDefaultAsync(x=>x.Id==id);
        }
        /// <summary>
        /// Asynchronously return collection of all books
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books
                .Include(x => x.Actions)
                .ThenInclude(y => y.User)
                .ToListAsync();
        }
        /// <summary>
        /// Asynchronosuly add a book to the database
        /// </summary>
        /// <param name="book">Book which will be added</param>
        /// <returns></returns>
        public async Task Add(Book book)
        {
            _context.Add(book);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Asynchronosuly remove a book from the database
        /// </summary>
        /// <param name="book">Book which will be removed</param>
        /// <returns></returns>
        public async Task Delete(Book book)
        {
            _context.Remove(book);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Asynchronously update a entity of book in the database
        /// </summary>
        /// <param name="book">Book which wil be updated</param>
        /// <returns></returns>
        public async Task Update(Book book)
        {
            _context.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
