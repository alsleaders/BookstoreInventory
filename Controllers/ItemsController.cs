using System;
using System.Collections.Generic;
using System.Linq;
using BookModel.Model;
using BookstoreInventory.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookstoreinventory.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ItemsController : ControllerBase
  {
    // GET api/all
    [HttpGet]
    public ActionResult<List<Model>> Get([FromQuery]int? LocationId)
    {
      var db = new DatabaseContext();
      // make unauthorized if invalid location
      if (LocationId == null)
      {
        return Unauthorized();
      }
      var place = db.Location.FirstOrDefault(f => f.Id == LocationId);
      if (place == null)
      {
        return new List<Model>();
      }
      else
      {
        var AllBooks = db.Books.Where(i => i.LocationId == place.Id);
        return AllBooks.ToList();
      }

    }

    // POST api/all
    [HttpPost]

    public ActionResult<Model> Post([FromBody]Model somethingToRead, [FromQuery]int? LocationId)
    {
      if (LocationId == null)
      {
        return Unauthorized();
      }
      var db = new DatabaseContext();
      // does that location exist, if not make it
      var place = db.Location.FirstOrDefault(f => f.Id == LocationId.GetValueOrDefault());
      if (place == null)
      {
        place = new LocationModel
        {
          Id = LocationId.GetValueOrDefault()
        };
        db.Location.Add(place);
      }
      db.SaveChanges();
      // now add the book
      somethingToRead.LocationId = place.Id;
      db.Books.Add(somethingToRead);
      db.SaveChanges();
      return somethingToRead;

    }

    // Get api/individual
    [HttpGet("{Name}")]
    public ActionResult<Model> GetOne(string Name, [FromQuery]int? LocationId)
    {
      var db = new DatabaseContext();
      var where = db.Books.Where(i => i.LocationId == LocationId.GetValueOrDefault()).FirstOrDefault(w => w.Name == Name);
      return where;

    }

    // Put api/individual
    // update name and/or price and/or sku and/or NuminStock and/or DateOrdered
    [HttpPut("{Name}")]

    public ActionResult<Model> UpdateOne(string Name, [FromBody]Model rhino, [FromQuery]int? LocationId)
    {
      var db = new DatabaseContext();
      var hippo = db.Books
        .Where(i => i.LocationId == LocationId.GetValueOrDefault())
        .FirstOrDefault(f => f.Name == Name);
      hippo.Name = rhino.Name;
      hippo.Price = rhino.Price;
      hippo.SKU = rhino.SKU;
      hippo.Description = rhino.Description;
      hippo.NuminStock = rhino.NuminStock;
      hippo.DateOrdered = rhino.DateOrdered;
      hippo.Author = rhino.Author;
      hippo.Completed = rhino.Completed;
      db.SaveChanges();
      return hippo;
    }

    // Delete api/individual
    [HttpDelete("{id}")]

    public ActionResult DeleteBook(int Id, [FromQuery]int? LocationId)
    {
      var db = new DatabaseContext();
      var deletedBook = db.Books.Where(i => i.LocationId == LocationId.GetValueOrDefault()).FirstOrDefault(f => f.Id == Id);
      if (deletedBook == null)
      {
        return NotFound();
      }
      else
      {
        db.Books.Remove(deletedBook);
        db.SaveChanges();
        return Ok();
      }
    }
  }
}