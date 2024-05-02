namespace backend;

public interface IAccountRepository : IRepository<Account>
{
    public Task<Account> GetAccountByUsername(string username);
    public Task<bool> DeleteAccountByUsername(string username);
}
