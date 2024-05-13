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

        modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "Admin" }, new Role { Id = 2, Name = "User" }, new Role { Id = 3, Name = "Staff" });
        modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus { Id = 1, StatusName = "Chuẩn bị hàng" }, new OrderStatus { Id = 2, StatusName = "Đang giao hàng" }, new OrderStatus { Id = 3, StatusName = "Đã giao hàng" });
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                CategoryId = 1,
                Name = "Lập trình C#",
                CreateAt = new DateTime(2022, 1, 1),
                UpdateAt = new DateTime(2023, 1, 1)
            },
            new Category
            {
                CategoryId = 2,
                Name = "Lập trình Java",
                CreateAt = new DateTime(2022, 2, 1),
                UpdateAt = new DateTime(2023, 2, 1)
            },
            new Category
            {
                CategoryId = 3,
                Name = "Lập trình Python",
                CreateAt = new DateTime(2022, 3, 1),
                UpdateAt = new DateTime(2023, 3, 1)
            },
            new Category
            {
                CategoryId = 4,
                Name = "Lập trình JavaScript",
                CreateAt = new DateTime(2022, 4, 1),
                UpdateAt = new DateTime(2023, 4, 1)
            },
            new Category
            {
                CategoryId = 5,
                Name = "Lập trình Ruby",
                CreateAt = new DateTime(2022, 5, 1),
                UpdateAt = new DateTime(2023, 5, 1)
            },
            new Category
            {
                CategoryId = 6,
                Name = "Lập trình PHP",
                CreateAt = new DateTime(2022, 6, 1),
                UpdateAt = new DateTime(2023, 6, 1)
            },
            new Category
            {
                CategoryId = 7,
                Name = "Lập trình Swift",
                CreateAt = new DateTime(2022, 7, 1),
                UpdateAt = new DateTime(2023, 7, 1)
            },
            new Category
            {
                CategoryId = 8,
                Name = "Lập trình Kotlin",
                CreateAt = new DateTime(2022, 8, 1),
                UpdateAt = new DateTime(2023, 8, 1)
            },
            new Category
            {
                CategoryId = 9,
                Name = "Lập trình Objective-C",
                CreateAt = new DateTime(2022, 9, 1),
                UpdateAt = new DateTime(2023, 9, 1)
            },
            new Category
            {
                CategoryId = 10,
                Name = "Lập trình R",
                CreateAt = new DateTime(2022, 10, 1),
                UpdateAt = new DateTime(2023, 10, 1)
            }
        );
        List<Book> fakeBooks = new List<Book>
        {
            new Book
            {
                BookId = 1,
                Title = "Sách Lập trình C#",
                Author = "Nguyễn Văn A",
                ImageUrl = "https://images.pexels.com/photos/3643828/pexels-photo-3643828.jpeg?cs=srgb&dl=pexels-ena-marinkovic-1814213-3643828.jpg&fm=jpg",
                Description = "Sách hướng dẫn lập trình C# từ cơ bản đến nâng cao.",
                Price = 29000m,
                Quantity = 50,
                CreateAt = new DateTime(2022, 1, 1),
                UpdateAt = new DateTime(2023, 1, 1),
                CategoryId = 1
            },
            new Book
            {
                BookId = 2,
                Title = "Sách Lập trình Java",
                Author = "Trần Văn B",
                ImageUrl = "https://images.pexels.com/photos/3643828/pexels-photo-3643828.jpeg?cs=srgb&dl=pexels-ena-marinkovic-1814213-3643828.jpg&fm=jpg",
                Description = "Sách hướng dẫn lập trình Java cho người mới bắt đầu.",
                Price = 35000m,
                Quantity = 30,
                CreateAt = new DateTime(2022, 2, 1),
                UpdateAt = new DateTime(2023, 2, 1),
                CategoryId = 2
            },
            // Tạo thêm 8 đối tượng Book
            new Book
            {
                BookId = 3,
                Title = "Sách Lập trình Python",
                Author = "Lê Thị C",
                ImageUrl = "https://images.pexels.com/photos/3643828/pexels-photo-3643828.jpeg?cs=srgb&dl=pexels-ena-marinkovic-1814213-3643828.jpg&fm=jpg",
                Description = "Hướng dẫn lập trình Python nâng cao.",
                Price = 39000m,
                Quantity = 25,
                CreateAt = new DateTime(2022, 3, 1),
                UpdateAt = new DateTime(2023, 3, 1),
                CategoryId = 3
            },
            new Book
            {
                BookId = 4,
                Title = "Sách Lập trình JavaScript",
                Author = "Phạm Văn D",
                ImageUrl = "https://images.pexels.com/photos/3643828/pexels-photo-3643828.jpeg?cs=srgb&dl=pexels-ena-marinkovic-1814213-3643828.jpg&fm=jpg",
                Description = "Lập trình JavaScript cơ bản.",
                Price = 24000m,
                Quantity = 40,
                CreateAt = new DateTime(2022, 4, 1),
                UpdateAt = new DateTime(2023, 4, 1),
                CategoryId = 4
            },
            new Book
            {
                BookId = 5,
                Title = "Sách Lập trình Ruby",
                Author = "Hoàng Thị E",
                ImageUrl = "https://images.pexels.com/photos/3643828/pexels-photo-3643828.jpeg?cs=srgb&dl=pexels-ena-marinkovic-1814213-3643828.jpg&fm=jpg",
                Description = "Ruby cơ bản và nâng cao.",
                Price = 42000m,
                Quantity = 35,
                CreateAt = new DateTime(2022, 5, 1),
                UpdateAt = new DateTime(2023, 5, 1),
                CategoryId = 5
            },
            new Book
            {
                BookId = 6,
                Title = "Sách Lập trình PHP",
                Author = "Đặng Văn F",
                ImageUrl = "https://images.pexels.com/photos/3643828/pexels-photo-3643828.jpeg?cs=srgb&dl=pexels-ena-marinkovic-1814213-3643828.jpg&fm=jpg",
                Description = "PHP từ cơ bản đến nâng cao.",
                Price = 37000m,
                Quantity = 20,
                CreateAt = new DateTime(2022, 6, 1),
                UpdateAt = new DateTime(2023, 6, 1),
                CategoryId = 6
            },
            new Book
            {
                BookId = 7,
                Title = "Sách Lập trình Swift",
                Author = "Nguyễn Văn G",
                ImageUrl = "https://images.pexels.com/photos/3643828/pexels-photo-3643828.jpeg?cs=srgb&dl=pexels-ena-marinkovic-1814213-3643828.jpg&fm=jpg",
                Description = "Học lập trình Swift.",
                Price = 45000m,
                Quantity = 25,
                CreateAt = new DateTime(2022, 7, 1),
                UpdateAt = new DateTime(2023, 7, 1),
                CategoryId = 7
            },
            new Book
            {
                BookId = 8,
                Title = "Sách Lập trình Kotlin",
                Author = "Nguyễn Thị H",
                ImageUrl = "https://images.pexels.com/photos/3643828/pexels-photo-3643828.jpeg?cs=srgb&dl=pexels-ena-marinkovic-1814213-3643828.jpg&fm=jpg",
                Description = "Lập trình Kotlin từ A đến Z.",
                Price = 33000m,
                Quantity = 30,
                CreateAt = new DateTime(2022, 8, 1),
                UpdateAt = new DateTime(2023, 8, 1),
                CategoryId = 8
            },
            new Book
            {
                BookId = 9,
                Title = "Sách Lập trình Objective-C",
                Author = "Lê Văn I",
                ImageUrl = "https://images.pexels.com/photos/3643828/pexels-photo-3643828.jpeg?cs=srgb&dl=pexels-ena-marinkovic-1814213-3643828.jpg&fm=jpg",
                Description = "Objective-C cơ bản và nâng cao.",
                Price = 39000m,
                Quantity = 15,
                CreateAt = new DateTime(2022, 9, 1),
                UpdateAt = new DateTime(2023, 9, 1),
                CategoryId = 9
            },
            new Book
            {
                BookId = 10,
                Title = "Sách Lập trình R",
                Author = "Trần Văn J",
                ImageUrl = "https://images.pexels.com/photos/3643828/pexels-photo-3643828.jpeg?cs=srgb&dl=pexels-ena-marinkovic-1814213-3643828.jpg&fm=jpg",
                Description = "R cho dữ liệu.",
                Price = 29000m,
                Quantity = 20,
                CreateAt = new DateTime(2022, 10, 1),
                UpdateAt = new DateTime(2023, 10, 1),
                CategoryId = 10
            }
        };

        // Chèn vào HasData
        modelBuilder.Entity<Book>().HasData(fakeBooks);
        modelBuilder.Entity<Account>().HasData(
            new Account
            {
                Username = "vuongthai",
                Password = "$2a$13$6BjHaarncKGYIgYiBmcg8OVbItdMJuyiXjmuCokUpitoUjbBVvCFy",
                Email = "vuongthai@example.com",
                Avatar = "https://example.com/avatar1.jpg",
                RoleId = 1, // Mã quyền giả định
                Status = "1",
                FirstName = "Nguyễn",
                LastName = "Văn A",
                DateOfBirth = new DateTime(1990, 1, 1),
                Gender = "Nam",
                Address = "Hà Nội",
                PhoneNumber = "0123456789",
                LanguagePreference = "Tiếng Việt",
                CreatedAt = new DateTime(2022, 1, 1),
                UpdatedAt = new DateTime(2023, 1, 1)
            },
            new Account
            {
                Username = "user2",
                Password = "$2a$13$6BjHaarncKGYIgYiBmcg8OVbItdMJuyiXjmuCokUpitoUjbBVvCFy",
                Email = "user2@example.com",
                Avatar = "https://example.com/avatar2.jpg",
                RoleId = 2,
                Status = "1",
                FirstName = "Trần",
                LastName = "Thị B",
                DateOfBirth = new DateTime(1992, 2, 1),
                Gender = "Nữ",
                Address = "TP. Hồ Chí Minh",
                PhoneNumber = "0987654321",
                LanguagePreference = "Tiếng Anh",
                CreatedAt = new DateTime(2022, 2, 1),
                UpdatedAt = new DateTime(2023, 2, 1)
            },
            new Account
            {
                Username = "user3",
                Password = "$2a$13$6BjHaarncKGYIgYiBmcg8OVbItdMJuyiXjmuCokUpitoUjbBVvCFy",
                Email = "user3@example.com",
                Avatar = "https://example.com/avatar3.jpg",
                RoleId = 2,
                Status = "1",
                FirstName = "Phạm",
                LastName = "Văn C",
                DateOfBirth = new DateTime(1994, 3, 1),
                Gender = "Nam",
                Address = "Đà Nẵng",
                PhoneNumber = "0777666555",
                LanguagePreference = "Tiếng Việt",
                CreatedAt = new DateTime(2022, 3, 1),
                UpdatedAt = new DateTime(2023, 3, 1)
            },
            new Account
            {
                Username = "staff",
                Password = "$2a$13$6BjHaarncKGYIgYiBmcg8OVbItdMJuyiXjmuCokUpitoUjbBVvCFy",
                Email = "staff@example.com",
                Avatar = "https://example.com/avatar3.jpg",
                RoleId = 3,
                Status = "1",
                FirstName = "Phạm",
                LastName = "Văn C",
                DateOfBirth = new DateTime(1994, 3, 1),
                Gender = "Nam",
                Address = "Đà Nẵng",
                PhoneNumber = "0777666555",
                LanguagePreference = "Tiếng Việt",
                CreatedAt = new DateTime(2022, 3, 1),
                UpdatedAt = new DateTime(2023, 3, 1)
            }
        );
    }

}
