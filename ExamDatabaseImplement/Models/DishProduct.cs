using System.ComponentModel.DataAnnotations;

namespace ExamDatabaseImplement.Models
{
    public class DishProduct
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public int ProductId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual Product Product { get; set; }
    }
}
