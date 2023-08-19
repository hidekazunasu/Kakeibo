using System.Reflection.Emit;
using System;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace TransactionApi.Controllers;


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
    [HttpGet("/test")]
    public async Task<IActionResult> GetData()
    {
        var data = await _context.Transactions
            .Include(t => t.Category) // カテゴリ情報をIncludeする
            .Select(t => new
            {
                id = t.Id,
                amount = t.Amount,
                date = t.Date,
                Description = t.Description,
                type = t.Type,
                category = t.Category.Name // Categoryプロパティから直接カテゴリ名を取得
            })
            .ToListAsync();

        return Ok(data);
    }


    [HttpPost]
    public async Task<ActionResult> Post(Transaction transaction)
    {
        var maxID = await _context.Transactions.MaxAsync(t => t.Id);
        if (transaction.Id <= maxID)
        {
            return BadRequest("");
        }
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}