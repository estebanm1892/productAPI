
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Wishlist> Wishlists { get; set; }
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurar el tipo de datos de Price
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");

        // Datos iniciales de categorías
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Books" }
        );

        // Datos iniciales de productos
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop", Description = "A high-end laptop.", Price = 999.99m, CategoryId = 1 },
            new Product { Id = 2, Name = "Smartphone", Description = "A latest model smartphone.", Price = 499.99m, CategoryId = 1 },
            new Product { Id = 3, Name = "C# Programming", Description = "A comprehensive guide to C# programming.", Price = 29.99m, CategoryId = 2 }
        );

        // Datos iniciales de usuarios
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "User1" },
            new User { Id = 2, Name = "User2" }
        );

        // Datos iniciales de Wishlists (listas de deseos) usando solo claves foráneas
        modelBuilder.Entity<Wishlist>().HasData(
            new Wishlist { Id = 1, ProductId = 1, UserId = 1 }, // Laptop en la lista de deseos de User1
            new Wishlist { Id = 2, ProductId = 2, UserId = 2 }  // Smartphone en la lista de deseos de User2
        );
    }

}
