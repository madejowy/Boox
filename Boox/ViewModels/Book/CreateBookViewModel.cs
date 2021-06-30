using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Boox.ViewModels
{
    public class CreateBookViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int NumberOfPages { get; set; }
    }
}
