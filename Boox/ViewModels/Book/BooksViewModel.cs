using Boox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boox.ViewModels
{
    public class BooksViewModel
    {
        public ICollection<Book> Books { get; set; }
        public string SearchPhrase { get; set; }
    }
}
