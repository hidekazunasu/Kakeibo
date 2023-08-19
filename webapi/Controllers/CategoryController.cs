using System.Reflection.Emit;
using System;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace webapi.Controllers;


[ApiController]
[Route("[controller]")]

public class CategoryController : ControllerBase
{
    private readonly KakeiboContext _context;

    public CategoryController(KakeiboContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        try
        {
            var data = await _context.Categories.ToListAsync();
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
    public async Task<ActionResult> Post(Category _category)
    {
        var list = await _context.Categories.ToListAsync();
        long maxid = 0;
        foreach (var  item in list)
        {
            maxid = maxid < item.Id ?item.Id: maxid;
            
        }
        _category.Id = maxid + 1;
        _context.Categories.Add(_category);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("id")]

    public async Task<ActionResult> Delete(long id)
    {
        var data = await _context.Categories.FindAsync(id);

        if(data ==null) {return NotFound();}

        _context.Categories.Remove(data);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }

}