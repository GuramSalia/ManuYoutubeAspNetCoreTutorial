using Menu2.Models;
using Microsoft.EntityFrameworkCore;

namespace Menu2.Data
{
    public class Menu2Context : DbContext
    {
        public Menu2Context(DbContextOptions<Menu2Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<DishIngredient>()
                .HasKey(di => new { di.DishId, di.IngredientId });

            modelBuilder
                .Entity<DishIngredient>()
                .HasOne(di => di.Dish)
                .WithMany(d => d.DishIngredients)
                .HasForeignKey(di => di.DishId);

            modelBuilder
                .Entity<DishIngredient>()
                .HasOne(di => di.Ingredient)
                .WithMany(i => i.DishIngredients)
                .HasForeignKey(di => di.IngredientId);

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Margarita", ImageURL = "https://gourmetkitchen.ie/wp-content/uploads/2023/10/R-1-1.jpeg", Price = 7.5 },
                new Dish { Id = 2, Name = "Salami", ImageURL = "https://therecipecritic.com/wp-content/uploads/2022/12/salami_pizza-1.jpg", Price = 9.5 }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Tomato Sauce" },
                new Ingredient { Id = 2, Name = "Mozzarrella" },
                new Ingredient { Id = 3, Name = "Salami" }
            );

            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngredientId = 1 },
                new DishIngredient { DishId = 1, IngredientId = 2 },
                new DishIngredient { DishId = 2, IngredientId = 1 },
                new DishIngredient { DishId = 2, IngredientId = 2 },
                new DishIngredient { DishId = 2, IngredientId = 3 }
            );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}
