using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace backend;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService accountService;
    public AccountController(IAccountService accountService)
    {
        this.accountService = accountService;
    }
    [HttpGet]
    [Authorize]
    [EnableQuery]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Account> accounts = await accountService.GetAllAccounts();
        return Ok(accounts);
    }

    [HttpGet("current-user")]
    [Authorize]
    public async Task<IActionResult> Get()
    {
        string? username = User.FindFirst(ClaimTypes.Name)?.Value;
        if (string.IsNullOrEmpty(username))
        {
            return BadRequest("Username is missing or empty.");
        }

        AccountResponse account = await accountService.GetAccount(username);
        if (account == null)
        {
            return NotFound(); // Return 404 if account is not found
        }

        return Ok(account); // Return 200 with account data
    }


    [HttpPost("admin")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AdminAddAccount(AccountRequest accountRequest)
    {
        Account account = await accountService.AdminAddAccount(accountRequest);
        return Created(nameof(account), account);
    }

    [HttpPost]
    public async Task<IActionResult> Register(AccountRequest accountRequest)
    {
        Account account = await accountService.AddAccount(accountRequest);
        return Created(nameof(account), account);
    }

    [HttpPut("{username}")]
    [Authorize]
    public async Task<IActionResult> UpdateAccount(string username, AccountUpdateRequest accountRequest)
    {
        Account account = await accountService.UpdateAccount(username, accountRequest);
        return Ok(account);
    }

    [HttpPut("admin/{username}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AdminUpdateAccount(string username, AccountRequest accountRequest)
    {
        Account account = await accountService.AdminUpdateAccount(username, accountRequest);
        return Ok(account);
    }

    [HttpDelete("{username}")]
    [Authorize]
    public async Task<IActionResult> DeleteAccount(string username)
    {
        bool account = await accountService.DeleteAccount(username);
        if (account == true)
        {

            return NoContent();
        }
        return BadRequest();
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAccount(AccountRequest accountRequest)
    {
        var checkLogin = await accountService.AuthenticationAcount(accountRequest);
        if (checkLogin is not null)
        {
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(checkLogin),
                expiration = checkLogin.ValidTo
            });
        }
        return Unauthorized();
    }

}
