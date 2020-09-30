using Microsoft.AspNetCore.Identity;
using System;

namespace Library.Core.Domain
{
    public class BookAction
    {
        public static string Action_Borrow = "Borrow";
        public static string Action_Return = "Return";

        public Guid Id { get; set; }
        public Book Book { get; set; }
        public IdentityUser<Guid> User { get; set; } // User which do action
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
}
