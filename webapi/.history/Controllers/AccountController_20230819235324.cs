using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace Accountwebapi.Controllers;

[ApiController]
[Route("[controller]")]

public class AccountyController : ControllerBase
{
    private readonly KakeiboContext _context;

    public AccountyController(KakeiboContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var accounty = await _context.Accounts.ToListAsync();
        return Ok(accounty);
    }
    [HttpPost]
    public async Task<IActionResult> Post(Account account)
    {
        _context.Accounts.Add(account);
        _context.SaveChangesAsync();

        return Ok(account);
    }
}