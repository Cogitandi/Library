using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.ViewModels
{
    public class ActionViewModel
    {
        [DisplayName("Rodzaj")]
        public string ActionName { get; set; }
        [DisplayName("Tytuł książki")]
        public string BookTitle { get; set; }
        [DisplayName("Data")]
        public DateTime Date { get; set; }
    }
}
