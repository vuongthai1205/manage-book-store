using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

namespace backend

{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(
             this IServiceCollection services, IConfiguration config)
        {

            return services;
        }

        public static IServiceCollection AddMyDependencyGroup(
             this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IRabbitMQService, RabbitMQService>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
            services.AddScoped<IStatusHistoryRepository, StatusHistoryRepository>();
            services.AddScoped<IStatusHistoryService, StatusHistoryService>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            return services;
        }

        public static IServiceCollection AddODataConfig(
            this IServiceCollection services)
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Book>("Books");

            modelBuilder.EntitySet<Comment>("Comments");
            modelBuilder.EntitySet<Account>("Accounts");
            modelBuilder.EntitySet<OrderResponse>("Orders");
            services.AddControllers().AddOData(
                options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(100).AddRouteComponents(
                    "odata",
                    modelBuilder.GetEdmModel()));
            return services;
        }
    }
}