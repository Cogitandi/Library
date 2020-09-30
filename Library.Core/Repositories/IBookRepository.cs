using Library.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface IBookRepository
    {
        Task<Book> GetById(Guid Id);
        Task<IEnumerable<Book>> GetAll();
        Task Add(Book book);
        Task Delete(Book book);
        Task Update(Book book);
    }
}
