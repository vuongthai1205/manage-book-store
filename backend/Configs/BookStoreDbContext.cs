using Microsoft.EntityFrameworkCore;

namespace backend;

public class BookStoreDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderStatus> OrderStatus { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<StatusHistory> StatusHistories { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().Property(e => e.CreateAt).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<Book>().Property(e => e.UpdateAt).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<Account>().Property(e => e.CreatedAt).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<Account>().Property(e => e.UpdatedAt).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<Category>().Property(e => e.CreateAt).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<Category>().Property(e => e.UpdateAt).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<Comment>().Property(e => e.CreateAt).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<Comment>().Property(e => e.UpdateAt).HasDefaultValueSql("getdate()");

        modelBuilder.Entity<StatusHistory>().Property(e => e.CreateAt).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<StatusHistory>().Property(e => e.UpdateAt).HasDefaultValueSql("getdate()");

        modelBuilder.Entity<Order>().Property(e => e.CreateAt).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<Order>().Property(e => e.UpdateAt).HasDefaultValueSql("getdate()");

        modelBuilder.Entity<OrderDetail>().Property(e => e.CreateAt).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<OrderDetail>().Property(e => e.UpdateAt).HasDefaultValueSql("getdate()");

        modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "Admin" });
        modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = "User" });
        modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = "Staff" });

        modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus { Id = 1, StatusName="Chuẩn bị hàng" });
        modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus { Id = 2, StatusName="Đang giao hàng" });
        modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus { Id = 3, StatusName="Đã giao hàng" });
    }

}
