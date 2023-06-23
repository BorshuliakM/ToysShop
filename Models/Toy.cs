using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToysShop.Models
{
    public class Toy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Producer { get; set; }

        [Required]
        [Display(Name = "ListPrice")]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Price for 1-10")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Price for 10+")]
        public double Price10 { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set;}
       // public string ImageUrl { get; set; }
    }
}
