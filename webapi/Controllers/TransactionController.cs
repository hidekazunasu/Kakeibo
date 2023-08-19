using System.Reflection.Emit;
using System;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace Transaction.Controllers;


[ApiController]
[Route("[controller]")]

public class TransactionController : ControllerBase
{
    private readonly KakeiboContext _context;

    public TransactionController(KakeiboContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        try
        {
            var data = await _context.Transactions.ToListAsync();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("データが見つかりません。");
            }
        }
        catch (Exception ex)
        {
            return BadRequest("エラーが発生しました。" + ex.Message);
        }
    }
}