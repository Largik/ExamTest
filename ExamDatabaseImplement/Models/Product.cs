using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamDatabaseImplement.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public DateTime DateAdd { get; set; }

        [Required]
        public string PlaceCreate { get; set; }

        [ForeignKey("ProductId")]
        public virtual List<DishProduct> ProductDishs { get; set; } //Many-to-many

        /* [ForeignKey("ProductId")]
         public virtual List<Dish> Dishes { get; set; } */ //One-to-many
    }
}
