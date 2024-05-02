using System.IdentityModel.Tokens.Jwt;

namespace backend;
public interface IAccountService{
    public Task<Account> AddAccount(AccountRequest accountRequest);
    public Task<Account> AdminAddAccount(AccountRequest accountRequest);
    public Task<IEnumerable<Account>> GetAllAccounts();
    public Task<JwtSecurityToken> AuthenticationAcount(AccountRequest accountRequest);
    public Task<AccountResponse> GetAccount(string username);
    public Task<bool> DeleteAccount(string username);
    public Task<Account> UpdateAccount(string username,AccountUpdateRequest accountRequest);
    public Task<Account> AdminUpdateAccount(string username,AccountRequest accountRequest);
}
