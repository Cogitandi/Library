using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.ViewModels
{
    public class BookViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Tytuł")]
        public string Name { get; set; }
        [DisplayName("Autor")]
        public string Author { get; set; }
        [DisplayName("Status")]
        public string Status { get; set; }
        public string BorrowedUserId { get; set; }
    }
}
