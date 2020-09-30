using Library.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface IBookActionRepository
    {
        Task<IEnumerable<BookAction>> GetByUserId(Guid Id);
    }
}
