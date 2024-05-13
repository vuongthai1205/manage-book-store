namespace backend;

public interface IStatusHistoryService
{
    Task<StatusHistory> AddStatusHistory(StatusHistoryRequest statusHistoryRequest);
}
