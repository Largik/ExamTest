using ExamDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamDatabaseImplement
{
    public class ExamDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
                base.OnConfiguring(optionsBuilder);
            }
        }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<DishProduct> DishProducts { get; set; } //Many-to-many
    }
}
