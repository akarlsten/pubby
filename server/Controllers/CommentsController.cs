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
  public class CommentsController : ControllerBase
  {
    private readonly PubbyContext _context;

    public CommentsController(PubbyContext context)
    {
      _context = context;
    }

    // GET: api/Comments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
    {
      return await _context.Comments.ToListAsync();
    }

    // GET: api/Comments/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Comment>> GetComment(long id)
    {
      var comment = await _context.Comments.FindAsync(id);

      if (comment == null)
      {
        return NotFound();
      }

      return comment;
    }

    // PUT: api/Comments/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutComment(long id, Comment comment)
    {
      if (id != comment.ID)
      {
        return BadRequest();
      }

      _context.Entry(comment).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CommentExists(id))
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

    // POST: api/Comments
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<Comment>> PostComment(Comment comment)
    {
      _context.Comments.Add(comment);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetComment), new { id = comment.ID }, comment);
    }

    // DELETE: api/Comments/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Comment>> DeleteComment(long id)
    {
      var comment = await _context.Comments.FindAsync(id);
      if (comment == null)
      {
        return NotFound();
      }

      _context.Comments.Remove(comment);
      await _context.SaveChangesAsync();

      return comment;
    }

    private bool CommentExists(long id)
    {
      return _context.Comments.Any(e => e.ID == id);
    }
  }
}
