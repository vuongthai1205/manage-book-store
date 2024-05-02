using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

namespace backend;

public class AccountService : IAccountService
{
    private readonly IAccountRepository accountRepository;
    private readonly IMapper mapper;
    private readonly IConfiguration _configuration;
    public AccountService(IAccountRepository _accountRepository, IMapper _mapper, IConfiguration configuration)
    {
        accountRepository = _accountRepository;
        mapper = _mapper;
        _configuration = configuration;
    }
    public async Task<Account> AddAccount(AccountRequest accountRequest)
    {
        Account account = mapper.Map<Account>(accountRequest);
        account.RoleId = 2;
        string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(account.Password, 13);
        account.Password = passwordHash;
        return await accountRepository.AddAsync(account);
    }

    public async Task<Account> AdminAddAccount(AccountRequest accountRequest)
    {
        Account account = mapper.Map<Account>(accountRequest);
        string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(account.Password, 13);
        account.Password = passwordHash;
        return await accountRepository.AddAsync(account);
    }

    public async Task<Account> AdminUpdateAccount(string username, AccountRequest accountRequest)
    {
        Account account = await accountRepository.GetAccountByUsername(username);
        // nếu như mà password là rỗng thì để lại cái password cũ và password bằng password cũ cũng để lại password cũ
        accountRequest.Password = accountRequest.Password.IsNullOrEmpty() ? account.Password : BCrypt.Net.BCrypt.EnhancedHashPassword(accountRequest.Password, 13);
        mapper.Map(accountRequest, account);

        return await accountRepository.UpdateAsync(account);
    }

    public async Task<JwtSecurityToken> AuthenticationAcount(AccountRequest accountRequest)
    {
        // Lấy tài khoản từ cơ sở dữ liệu dựa trên tên người dùng
        Account account = await accountRepository.GetAccountByUsername(accountRequest.Username);

        // Kiểm tra xem tài khoản có tồn tại và mật khẩu có khớp không
        if (account != null && BCrypt.Net.BCrypt.EnhancedVerify(accountRequest.Password, account.Password))
        {
            if (account.Status != "1")
            {
                throw new Exception("Tài khoản đang chờ được duyệt, vui lòng đợi...");
            }
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, account.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, account.Role!.Name)
                };
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token; // Đăng nhập thành công
        }
        else
        {
            return null; // Đăng nhập thất bại
        }
    }

    public async Task<bool> DeleteAccount(string username)
    {
        return await accountRepository.DeleteAccountByUsername(username);
    }

    public async Task<AccountResponse> GetAccount(string username)
    {
        Account account = await accountRepository.GetAccountByUsername(username);
        AccountResponse accountResponse = mapper.Map<Account, AccountResponse>(account);
        return accountResponse;
    }

    public async Task<IEnumerable<Account>> GetAllAccounts()
    {
        return await accountRepository.GetAllAsync();
    }

    public async Task<Account> UpdateAccount(string username, AccountUpdateRequest accountRequest)
    {
        Account account = await accountRepository.GetAccountByUsername(username);
        mapper.Map(accountRequest, account);
        return await accountRepository.UpdateAsync(account);
    }
}
