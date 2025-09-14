using Microsoft.EntityFrameworkCore;
using Models;
namespace DAL
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseSqlServer("Server=DESKTOP-T12FKAO\\SQLEXPRESS; Database=FlowerShop_Db; Trusted_Connection=true; TrustServerCertificate=Yes");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            // User - Order отношение

            modelBuilder.Entity<Order>()

                .HasOne(o => o.User)

                .WithMany(u => u.Orders)

                .HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()

                .HasOne(r => r.User)

                .WithMany(u => u.Reviews)

                .HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()

                .HasOne(r => r.Order)

                .WithMany(r=>r.Reviews)

                .HasForeignKey(r => r.OrderId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductCategory>()
             .HasKey(pc => new { pc.ProductId, pc.CategoryId });
            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);

            modelBuilder.Entity<ProductColor>()
           .HasKey(pc => new { pc.ProductId, pc.ColorId });

            modelBuilder.Entity<ProductColor>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductColors)
                .HasForeignKey(pc => pc.ProductId);
            modelBuilder.Entity<ProductColor>()
                .HasOne(pc => pc.Color)
                .WithMany(c => c.ProductColors)
                .HasForeignKey(pc => pc.ColorId);


            modelBuilder.Entity<OrderDetails>()

                .HasOne(od => od.Order)

                .WithMany(o => o.OrderDetails)

                .HasForeignKey(od => od.OrderId);

           
            modelBuilder.Entity<OrderDetails>()

                .HasOne(od => od.Product)

                .WithMany()

                .HasForeignKey(od => od.ProductId);
        }

    }
}
