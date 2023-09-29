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
  public class LocationsController : ControllerBase
  {
    private TravelApiContext _db;

    public LocationsController(TravelApiContext db)
    {
      _db = db;
    }

    // GET api/locations
    [HttpGet]
    public async Task<List<Location>> Get(string country, int reviewId)
    {
      IQueryable<Location> query = _db.Locations.AsQueryable();

      if (country != null)
      {
        query = query.Where(entry => entry.Country == country);
      }

      return await query.ToListAsync();
    }

    // POST api/locations
    [HttpPost]
    public async Task<ActionResult> Post(Location location)
    {
      _db.Locations.Add(location);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetLocation), new { id = location.LocationId }, location);
    }

    // GET: api/Locations/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Location>> GetLocation(int id)
    {
      Location location = await _db.Locations.FindAsync(id);

      if (location == null)
      {
        return NotFound();
      }

      return location;
    }

    // PUT: api/Locations/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Location location)
    {
      if (id != location.LocationId)
      {
        return BadRequest();
      }

      _db.Entry(location).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!LocationExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return CreatedAtAction(nameof(GetLocation), new { id = location.LocationId }, location);
    }
    private bool LocationExists(int id)
    {
      return _db.Locations.Any(e => e.LocationId == id);
    }

    // DELETE: api/Location/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLocation(int id)
    {
      Location location = await _db.Locations.FindAsync(id);
      if (location == null)
      {
        return NotFound();
      }

      _db.Locations.Remove(location);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}