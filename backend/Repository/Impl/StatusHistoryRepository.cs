namespace backend;

public class StatusHistoryRepository : BaseRepository<StatusHistory>, IStatusHistoryRepository
{
    public StatusHistoryRepository(BookStoreDbContext _con) : base(_con)
    {
    }
}
