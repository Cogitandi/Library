using Library.Core.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Library.Core.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public bool IsBorrowed { get; set; }
        public IList<BookAction> Actions { get; set; }

        /// <summary>
        /// Borrow book by the given user
        /// </summary>
        /// <param name="user">User which borrow book</param>
        public void Borrow(IdentityUser<Guid> user)
        {
            IsBorrowed = true;
            var action = new BookAction()
            {
                Name = BookAction.Action_Borrow,
                Date = DateTime.Now,
                User = user,
            };
            Actions.Add(action);

        }
        /// <summary>
        /// Return book by the given user
        /// </summary>
        /// <param name="user">User which borrowed book</param>
        public void Return(IdentityUser<Guid> user)
        {
            IsBorrowed = false;
            var action = new BookAction()
            {
                Name = BookAction.Action_Return,
                Date = DateTime.Now,
                User = user,
            };
            Actions.Add(action);
        }
        /// <summary>
        /// Get user id which currently borrowed book
        /// </summary>
        /// <returns>User id</returns>
        public string GetBorrowedUserId()
        {
            var lastBorrowAction = Actions
                .Where(x => x.Name.Equals(BookAction.Action_Borrow))
                .OrderByDescending(x => x.Date)
                .FirstOrDefault();
            if (lastBorrowAction == null)
                return "";

            return lastBorrowAction.User.Id.ToString();
        }
    }
}
