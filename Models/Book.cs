using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potter_kata.Models
{
    public class Book
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required double SinglePrice { get; set; }
        
        public int Quantity { get; set; } = 0;
    }
}
