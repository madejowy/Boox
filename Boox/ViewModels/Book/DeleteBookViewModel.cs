using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boox.ViewModels
{
    public class DeleteBookViewModel
    {
        public int BookId { get; set; }
        public string Message { get; set; }
        public DeleteBookViewModel()
        {
        }
        public DeleteBookViewModel(int id, string message = "")
        {
            BookId = id;
            Message = message;
        }
    }
}
