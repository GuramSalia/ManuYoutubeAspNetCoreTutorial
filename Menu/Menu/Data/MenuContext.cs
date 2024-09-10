using Microsoft.EntityFrameworkCore;
using Menu.Models;

//GS


namespace Menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions options) : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<DishIngredient>()
                .HasKey(di => new
                    {
                        di.DishId,
                        di.IngredientId
                    }
                );

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
                    new Dish { Id = 1, Name = "Margarita", ImageUrl = "https://images.app.goo.gl/zjHGS6R4K736Pjmf8", Price = 7.5 },
                    new Dish { Id = 2, Name = "Salami", ImageUrl = "https://images.app.goo.gl/my55dUpRWRWzE2Zq9", Price = 9.5 }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                    new Ingredient { Id = 1, Name = "Tomato Souce" },
                    new Ingredient { Id = 2, Name = "Mozzarella" },
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
