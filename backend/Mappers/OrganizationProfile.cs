using AutoMapper;
namespace backend;
public class OrganizationProfile : Profile
{
	public OrganizationProfile()
	{
		CreateMap<Book, BookRequest>();
		CreateMap<BookRequest, Book>();
		CreateMap<Category, CategoryRequest>();
		CreateMap<CategoryRequest, Category>();

		CreateMap<Account, AccountRequest>();
        CreateMap<AccountRequest, Account>();
        CreateMap<Account, AccountUpdateRequest>();
        CreateMap<AccountUpdateRequest, Account>();
        CreateMap<Account, AccountResponse>();
        CreateMap<AccountResponse, Account>();

		CreateMap<Comment, CommentRequest>();
		CreateMap<CommentRequest, Comment>();

		CreateMap<Order, OrderRequest>();
		CreateMap<OrderRequest, Order>();
		CreateMap<OrderDetail, OrderDetailRequest>();
		CreateMap<OrderDetailRequest, OrderDetail>();
		CreateMap<Order, OrderResponse>();
		CreateMap<OrderResponse, Order>();

		CreateMap<StatusHistory, StatusHistoryResponse>();
		CreateMap<StatusHistoryResponse, StatusHistory>();
	}
}