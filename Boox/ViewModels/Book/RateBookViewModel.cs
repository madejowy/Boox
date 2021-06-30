using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Boox.ViewModels
{
    public class RateBookViewModel : CreateBookViewModel
    {
        [Range(1,5)]
        public int Rating { get; set; }
    }
}
