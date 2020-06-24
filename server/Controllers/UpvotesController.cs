using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UpvotesController : ControllerBase
  {
    private readonly DataContext _context;

    public UpvotesController(DataContext context)
    {
      _context = context;
    }

    // GET: api/Upvotes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Upvote>>> GetUpvotes()
    {
      return await _context.Upvotes.ToListAsync();
    }

    // GET: api/Upvotes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Upvote>> GetUpvote(long id)
    {
      var upvote = await _context.Upvotes.FindAsync(id);

      if (upvote == null)
      {
        return NotFound();
      }

      return upvote;
    }

    // PUT: api/Upvotes/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUpvote(long id, Upvote upvote)
    {
      if (id != upvote.ID)
      {
        return BadRequest();
      }

      _context.Entry(upvote).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!UpvoteExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Upvotes
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<Upvote>> PostUpvote(Upvote upvote)
    {
      _context.Upvotes.Add(upvote);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetUpvote), new { id = upvote.ID }, upvote);
    }

    // DELETE: api/Upvotes/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Upvote>> DeleteUpvote(long id)
    {
      var upvote = await _context.Upvotes.FindAsync(id);
      if (upvote == null)
      {
        return NotFound();
      }

      _context.Upvotes.Remove(upvote);
      await _context.SaveChangesAsync();

      return upvote;
    }

    private bool UpvoteExists(long id)
    {
      return _context.Upvotes.Any(e => e.ID == id);
    }
  }
}
