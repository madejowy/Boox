using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Boox.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int NumberOfPages { get; set; }
        [Required]
        public bool IsReaded { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
    }
}
