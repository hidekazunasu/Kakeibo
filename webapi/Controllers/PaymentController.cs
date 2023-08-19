using System.Reflection.Emit;
using System;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace Payment.Controllers;


[ApiController]
[Route("[controller]")]

public class PaymentMethodController : ControllerBase
{
    private readonly KakeiboContext _context;

    public PaymentMethodController(KakeiboContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        try
        {
            var data = await _context.PaymentMethods.ToListAsync();
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
    [HttpPost]
    public async Task<ActionResult> Post(PaymentMethod payment)
    {
        _context.PaymentMethods.Add(payment);
        _context.SaveChangesAsync();

        return NoContent();
    }


}
