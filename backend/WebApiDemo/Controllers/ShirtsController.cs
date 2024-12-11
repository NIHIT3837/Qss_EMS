using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApiDemo.Models;
using WebApiDemo.Data;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public ShirtsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        // 1. GET: api/shirts
        [HttpGet]
        public ActionResult<IEnumerable<Shirt>> GetAllShirts()
        {
            return Ok(db.Shirts.ToList()); // Returns all shirts
        }

        // 2. GET: api/shirts/{id}
        [HttpGet("{id}")]
        public ActionResult<Shirt> GetShirtById(int id)
        {
            var shirt = db.Shirts.Find(id);
            if (shirt == null)
            {
                return NotFound(); // If shirt not found
            }
            return Ok(shirt); // Return the found shirt
        }

        // 3. POST: api/shirts
        [HttpPost]
        public ActionResult<Shirt> CreateShirt(Shirt newShirt)
        {
            if (newShirt == null)
            {
                return BadRequest();
            }

            var existingShirt = db.Shirts.FirstOrDefault(s =>
                s.Brand == newShirt.Brand &&
                s.Gender == newShirt.Gender &&
                s.Color == newShirt.Color &&
                s.Size == newShirt.Size);

            if (existingShirt != null)
            {
                return BadRequest();
            }

            db.Shirts.Add(newShirt);
            db.SaveChanges();

            return CreatedAtAction(nameof(GetShirtById), new { id = newShirt.ShirtId }, newShirt); // Return the created shirt
        }

        // 4. PUT: api/shirts/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateShirt(int id, Shirt updatedShirt)
        {
            if (id != updatedShirt.ShirtId)
            {
                return BadRequest();
            }

            var shirt = db.Shirts.Find(id);
            if (shirt == null)
            {
                return NotFound();
            }

            shirt.Brand = updatedShirt.Brand;
            shirt.Gender = updatedShirt.Gender;
            shirt.Color = updatedShirt.Color;
            shirt.Size = updatedShirt.Size;
            db.SaveChanges();

            return NoContent(); // Return HTTP 204 No Content after successful update
        }

        // 5. DELETE: api/shirts/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteShirt(int id)
        {
            var shirt = db.Shirts.Find(id);

            if (shirt == null)
            {
                return NotFound();
            }

            db.Shirts.Remove(shirt);
            db.SaveChanges();

            return Ok(shirt);
        }
    }
}