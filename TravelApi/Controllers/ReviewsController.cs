using TravelApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace TravelApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReviewsController : ControllerBase
  {
    private TravelApiContext _db;

    public ReviewsController(TravelApiContext db)
    {
      _db = db;
    }

    // GET api/reviews
    [HttpGet]
    public async Task<List<Review>> Get(string author, int locationId, int minimumRating)
    {
      IQueryable<Review> query = _db.Reviews.AsQueryable();

      if (author != null)
      {
        query = query.Where(entry => entry.Author == author);
      }

      if (locationId != 0)
      {
        query = query.Where(entry => entry.LocationId == locationId);
      }

      if (minimumRating > 0)
      {
        query = query.Where(entry => entry.Rating >= minimumRating);
      }

      return await query.ToListAsync();
    }

    // POST api/reviews
    [HttpPost]
    public async Task<ActionResult> Post(Review review)
    {
      _db.Reviews.Add(review);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetReview), new { id = review.ReviewId }, review);
    }

    // GET: api/Reviews/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> GetReview(int id)
    {
      Review review = await _db.Reviews.FindAsync(id);

      if (review == null)
      {
        return NotFound();
      }

      return review;
    }

    // PUT: api/Reviews/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, string user ,Review review)
    {
      if (id != review.ReviewId)
      {
        return BadRequest();
      }

      if (user != review.Author)
      {
        return BadRequest();
      }

      _db.Entry(review).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ReviewExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return CreatedAtAction(nameof(GetReview), new { id = review.ReviewId }, review);
    }
    private bool ReviewExists(int id)
    {
      return _db.Reviews.Any(e => e.ReviewId == id);
    }

    // DELETE: api/Reviews/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteReview(int id, string user)
    {
      Review review = await _db.Reviews.FindAsync(id);
      if (review == null)
      {
        return NotFound();
      }

      if (user != review.Author)
      {
        return BadRequest();
      }

      _db.Reviews.Remove(review);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}