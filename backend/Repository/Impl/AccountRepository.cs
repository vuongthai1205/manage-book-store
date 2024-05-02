using Microsoft.EntityFrameworkCore;

namespace backend;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    BookStoreDbContext _db;
    public AccountRepository(BookStoreDbContext _con) : base(_con)
    {
        _db = _con;
    }

    public async Task<bool> DeleteAccountByUsername(string username)
    {
        Account account = await GetAccountByUsername(username);

        if (account == null)
        {
            return false;
        }
        else
        {
            _db.Accounts.Remove(account);
            _db.SaveChanges();
            return true;
        }
    }

    public async Task<Account> GetAccountByUsername(string username)
    {
        Account? account = await _db.Accounts.Include(a => a.Role).SingleOrDefaultAsync(a => a.Username == username);
        if (account == null)
        {
            return null;
        }
        return account;
    }

}
