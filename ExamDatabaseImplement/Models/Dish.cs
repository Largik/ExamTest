using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamDatabaseImplement.Models
{
    public class Dish
    {
        public int Id { get; set; }

       // public int ProductId { get; set; } //One-to-many

        [Required]
        public string TypeDish { get; set; }

        [Required]
        public DateTime DateImplement { get; set; }

        [ForeignKey("DishId")]
        public virtual List<DishProduct> DishProducts { get; set; } //Many-to-many

       // public virtual Product Product { get; set; }  //One-to-many
    }
}
