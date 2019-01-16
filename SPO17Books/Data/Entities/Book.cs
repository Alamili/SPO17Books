using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPO17Books.Data.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(75), Required]
        public string Title { get; set; }
        [MaxLength(450)]
        public string UserId { get; set; }
    }
}
